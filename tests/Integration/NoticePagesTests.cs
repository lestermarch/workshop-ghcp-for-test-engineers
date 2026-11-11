using LegacyNoticeManager.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LegacyNoticeManager.IntegrationTests;

public class NoticePagesTests : IClassFixture<NoticeApplicationFactory>
{
    private readonly HttpClient _client;

    public NoticePagesTests(NoticeApplicationFactory factory) => _client = factory.CreateClient();

    [Fact]
    [Trait("TestId", "TEST-INT-01")]
    public async Task Notice_register_displays_synthetic_seed_record()
    {
        var response = await _client.GetAsync("/Notices");
        var page = await response.Content.ReadAsStringAsync();

        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("Temporary buoy relocation", page);
        Assert.Contains("fictional training application", page);
    }

    [Fact]
    [Trait("TestId", "TEST-INT-02")]
    public async Task Approved_notice_can_be_exported()
    {
        var response = await _client.GetAsync("/Notices/Export/1");
        var csv = await response.Content.ReadAsStringAsync();

        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("Temporary buoy relocation", csv);
    }
}

public sealed class NoticeApplicationFactory : WebApplicationFactory<Program>
{
    private readonly string _databasePath = Path.Combine(Path.GetTempPath(), $"notice-demo-{Guid.NewGuid():N}.db");

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
