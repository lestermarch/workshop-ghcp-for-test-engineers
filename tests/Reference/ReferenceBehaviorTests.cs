using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.RegularExpressions;
using LegacyNoticeManager.Data;
using LegacyNoticeManager.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LegacyNoticeManager.ReferenceTests;

public class ReferenceBehaviorTests
{
    [Fact]
    [Trait("TestId", "TEST-REF-01")]
    public async Task Lowercase_region_search_does_not_match_seeded_title()
    {
        using var factory = new ReferenceApplicationFactory();
        var client = factory.CreateClient();

        var response = await client.GetAsync("/Notices?search=north");
        var page = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.DoesNotContain("Temporary buoy relocation", page);
    }

    [Fact]
    [Trait("TestId", "TEST-REF-02")]
    public async Task Approved_notice_cannot_be_edited()
    {
        using var factory = new ReferenceApplicationFactory();
        var response = await factory.CreateClient().GetAsync("/Notices/Edit/1");

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    [Trait("TestId", "TEST-REF-03")]
    public async Task Draft_notice_export_is_rejected()
    {
        using var factory = new ReferenceApplicationFactory();
        var response = await factory.CreateClient().GetAsync("/Notices/Export/2");

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    [Trait("TestId", "TEST-REF-04")]
    public async Task Same_day_expiry_is_accepted_by_create_action()
    {
        using var factory = new ReferenceApplicationFactory();
        var client = factory.CreateClient();
        var form = await client.GetAsync("/Notices/Create");
        var token = await ReadAntiforgeryToken(form);
        using var content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            ["__RequestVerificationToken"] = token,
            ["Title"] = "Same-day reference case",
            ["Description"] = "Synthetic boundary example.",
            ["Region"] = "North",
            ["Severity"] = "Low",
            ["EffectiveDate"] = "2026-12-01",
            ["ExpiryDate"] = "2026-12-01",
            ["Owner"] = "Reference test"
        });

        var response = await client.PostAsync("/Notices/Create", content);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        using var scope = factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<NoticeDbContext>();
        Assert.Contains(await db.Notices.ToListAsync(), n => n.Title == "Same-day reference case");
    }

    [Fact]
    [Trait("TestId", "TEST-REF-05")]
    public async Task Approval_changes_status_without_a_matching_audit_event()
    {
        using var factory = new ReferenceApplicationFactory();
        var client = factory.CreateClient();
        var details = await client.GetAsync("/Notices/Details/2");
        var token = await ReadAntiforgeryToken(details);
        using var content = new FormUrlEncodedContent(new Dictionary<string, string> { ["__RequestVerificationToken"] = token });

        var response = await client.PostAsync("/Notices/Approve/2", content);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        using var scope = factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<NoticeDbContext>();
        Assert.Equal("Approved", (await db.Notices.FindAsync(2))!.Status);
        Assert.DoesNotContain(await db.AuditRecords.Where(a => a.NoticeId == 2).ToListAsync(), a => a.Event.Contains("Approved"));
    }

    [Fact]
    [Trait("TestId", "TEST-REF-06")]
    public async Task Stale_context_update_overwrites_the_first_context_change()
    {
        using var factory = new ReferenceApplicationFactory();
        _ = factory.CreateClient();
        using var scope = factory.Services.CreateScope();
        var options = scope.ServiceProvider.GetRequiredService<DbContextOptions<NoticeDbContext>>();
        await using var first = new NoticeDbContext(options);
        await using var second = new NoticeDbContext(options);
        var firstCopy = await first.Notices.FindAsync(3);
        var secondCopy = await second.Notices.FindAsync(3);

        firstCopy!.Owner = "First synthetic editor";
        await first.SaveChangesAsync();
        secondCopy!.Owner = "Second synthetic editor";
        await second.SaveChangesAsync();

        await using var verify = new NoticeDbContext(options);
        Assert.Equal("Second synthetic editor", (await verify.Notices.FindAsync(3))!.Owner);
    }

    [Fact]
    [Trait("TestId", "TEST-REF-07")]
    public async Task Register_search_input_has_no_explicit_label()
    {
        using var factory = new ReferenceApplicationFactory();
        var page = await factory.CreateClient().GetStringAsync("/Notices");

        Assert.Contains("placeholder=\"Search title or region\"", page);
        Assert.DoesNotContain("for=\"search\"", page);
    }

    [Fact]
    [Trait("TestId", "TEST-REF-08")]
    public void Emergency_publication_date_uses_effective_date_without_lead()
    {
        var notice = new Notice { Region = "Outer Reach", EffectiveDate = new DateTime(2026, 12, 1), Emergency = true };

        Assert.Equal(new DateTime(2026, 12, 1), notice.PublicationDate());
    }

    [Fact]
    [Trait("TestId", "TEST-REF-09")]
    public void Data_annotations_reject_title_below_minimum_length()
    {
        var notice = new Notice { Title = "Tiny", Region = "North", Severity = "Low" };
        var results = new List<ValidationResult>();

        var valid = Validator.TryValidateObject(notice, new ValidationContext(notice), results, validateAllProperties: true);

        Assert.False(valid);
        Assert.Contains(results, result => result.MemberNames.Contains(nameof(Notice.Title)));
    }

    private static async Task<string> ReadAntiforgeryToken(HttpResponseMessage response)
    {
        var html = await response.Content.ReadAsStringAsync();
        var match = Regex.Match(html, "name=\"__RequestVerificationToken\" type=\"hidden\" value=\"([^\"]+)\"");
        Assert.True(match.Success, "The MVC form should include an antiforgery token.");
        return match.Groups[1].Value;
    }
}

public sealed class ReferenceApplicationFactory : WebApplicationFactory<Program>
{
    private readonly string _databasePath = Path.Combine(Path.GetTempPath(), $"notice-reference-{Guid.NewGuid():N}.db");

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var existing = services.SingleOrDefault(x => x.ServiceType == typeof(DbContextOptions<NoticeDbContext>));
            if (existing is not null) services.Remove(existing);
            services.AddDbContext<NoticeDbContext>(options => options.UseSqlite($"Data Source={_databasePath}"));
        });
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        if (disposing)
        {
            SqliteConnection.ClearAllPools();
            if (File.Exists(_databasePath)) File.Delete(_databasePath);
        }
    }
}
