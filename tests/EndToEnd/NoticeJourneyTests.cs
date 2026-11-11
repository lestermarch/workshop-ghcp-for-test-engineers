using System.IO;
using Microsoft.Playwright;
using Xunit.Abstractions;

namespace LegacyNoticeManager.EndToEndTests;

public sealed class FailureEvidenceDemoFactAttribute : FactAttribute
{
    public FailureEvidenceDemoFactAttribute()
    {
        if (!string.Equals(Environment.GetEnvironmentVariable("E2E_CAPTURE_FAILURE"), "true", StringComparison.OrdinalIgnoreCase))
        {
            Skip = "Set E2E_CAPTURE_FAILURE=true to run the intentional screenshot/trace capture demonstration.";
        }
    }
}

public class NoticeJourneyTests(BrowserApplicationFixture application, ITestOutputHelper output)
    : BrowserTestBase(application, output), IClassFixture<BrowserApplicationFixture>
{
    [Fact]
    [Trait("TestId", "TEST-E2E-01")]
    public async Task Participant_can_create_edit_approve_and_export_a_notice()
    {
        await RunBrowserScenarioAsync(async page =>
        {
            var title = $"Browser journey {Guid.NewGuid():N}";
            var effectiveDate = DateOnly.FromDateTime(DateTime.Today).AddDays(10).ToString("yyyy-MM-dd");
            var expiryDate = DateOnly.FromDateTime(DateTime.Today).AddDays(30).ToString("yyyy-MM-dd");

            await page.GotoAsync($"{Application.BaseUrl}/Notices");
            await page.GetByRole(AriaRole.Link, new() { Name = "Create a notice" }).ClickAsync();
            await page.GetByLabel("Title").FillAsync(title);
            await page.GetByLabel("Region").SelectOptionAsync("North");
            await page.GetByLabel("Severity").SelectOptionAsync("High");
            await page.GetByLabel("EffectiveDate").FillAsync(effectiveDate);
            await page.GetByLabel("ExpiryDate").FillAsync(expiryDate);
            await page.GetByRole(AriaRole.Button, new() { Name = "Save draft" }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Listitem)
                .Filter(new() { HasText = "A description is required for high-severity notices." }))
                .ToBeVisibleAsync();

            await page.GetByLabel("Description").FillAsync("Synthetic description supplied after validation.");
            await page.GetByRole(AriaRole.Button, new() { Name = "Save draft" }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { Name = title })).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator("p").First).ToContainTextAsync("Draft");
            await Assertions.Expect(page.GetByText("Created", new() { Exact = false })).ToBeVisibleAsync();

            await page.GetByRole(AriaRole.Link, new() { Name = "Edit" }).ClickAsync();
            await page.GetByLabel("Description").FillAsync("Updated by the synthetic browser journey.");
            await page.GetByRole(AriaRole.Button, new() { Name = "Save changes" }).ClickAsync();
            await Assertions.Expect(page.GetByText("Updated by the synthetic browser journey.")).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Edited", new() { Exact = false })).ToBeVisibleAsync();

            await page.GetByRole(AriaRole.Button, new() { Name = "Approve" }).ClickAsync();
            await Assertions.Expect(page.Locator("p").First).ToContainTextAsync("Approved");
            var download = await page.RunAndWaitForDownloadAsync(async () =>
                await page.GetByRole(AriaRole.Link, new() { Name = "Export summary" }).ClickAsync());
            await using var stream = await download.CreateReadStreamAsync();
            using var reader = new StreamReader(stream);
            var csv = await reader.ReadToEndAsync();
            Assert.Contains(title, csv);
        });
    }

    [Fact]
    [Trait("TestId", "TEST-E2E-02")]
    public async Task Search_observation_records_case_sensitive_region_matching()
    {
        await RunBrowserScenarioAsync(async page =>
        {
            await page.GotoAsync($"{Application.BaseUrl}/Notices");
            var search = page.Locator("input[name='search']");
            await search.FillAsync("north");
            await search.PressAsync("Enter");

            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Notice register" })).ToBeVisibleAsync();
            Assert.DoesNotContain("Temporary buoy relocation", await page.ContentAsync());
        });
    }

    [Fact]
    [Trait("TestId", "TEST-E2E-03")]
    public async Task Participant_can_reject_a_notice_and_review_the_audit_history()
    {
        await RunBrowserScenarioAsync(async page =>
        {
            await page.GotoAsync($"{Application.BaseUrl}/Notices/Details/2");
            await page.GetByLabel("Rejection reason").FillAsync("Synthetic review requires a clearer description.");
            await page.GetByRole(AriaRole.Button, new() { Name = "Reject" }).ClickAsync();

            await Assertions.Expect(page.Locator("p").First).ToContainTextAsync("Rejected");
            await Assertions.Expect(page.GetByText("Rejected: Synthetic review requires a clearer description.")).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { Name = "Edit" })).ToBeVisibleAsync();
        });
    }

    [FailureEvidenceDemoFact]
    public async Task Failure_evidence_capture_demo()
    {
        await RunBrowserScenarioAsync(async page =>
        {
            await page.GotoAsync($"{Application.BaseUrl}/Notices");
            Assert.Fail("Intentional demonstration failure: inspect the screenshot and Playwright trace.");
        });
    }
}
