using System.Runtime.CompilerServices;
using Microsoft.Playwright;
using Xunit.Abstractions;

namespace LegacyNoticeManager.EndToEndTests;

public abstract class BrowserTestBase(BrowserApplicationFixture application, ITestOutputHelper output)
{
    protected BrowserApplicationFixture Application { get; } = application;

    protected async Task RunBrowserScenarioAsync(
        Func<IPage, Task> scenario,
        [CallerMemberName] string scenarioName = "browser-scenario")
    {
        Directory.CreateDirectory(Application.ArtifactDirectory);
        var artifactName = string.Concat(scenarioName.Select(character =>
            char.IsLetterOrDigit(character) || character is '-' or '_' ? character : '-'));

        await using var context = await Application.Browser.NewContextAsync(new BrowserNewContextOptions
        {
            AcceptDownloads = true,
            ViewportSize = new ViewportSize { Width = 1360, Height = 900 }
        });
        context.SetDefaultTimeout(10_000);
        context.SetDefaultNavigationTimeout(15_000);
        await context.Tracing.StartAsync(new TracingStartOptions
        {
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });

        var page = await context.NewPageAsync();
        try
        {
            if (string.Equals(Environment.GetEnvironmentVariable("E2E_DEBUG"), "true", StringComparison.OrdinalIgnoreCase))
            {
                await page.PauseAsync();
            }

            await scenario(page);
            await context.Tracing.StopAsync();
        }
        catch (Exception testFailure)
        {
            var screenshotPath = Path.Combine(Application.ArtifactDirectory, $"{artifactName}.png");
            var tracePath = Path.Combine(Application.ArtifactDirectory, $"{artifactName}.zip");
            try
            {
                await page.ScreenshotAsync(new PageScreenshotOptions { Path = screenshotPath, FullPage = true });
                await context.Tracing.StopAsync(new TracingStopOptions { Path = tracePath });
                output.WriteLine($"Browser evidence: screenshot={screenshotPath}; trace={tracePath}");
            }
            catch (Exception evidenceFailure)
            {
                output.WriteLine($"Browser evidence capture failed: {evidenceFailure.Message}");
                output.WriteLine($"Original test failure: {testFailure.Message}");
            }

            throw;
        }
    }
}
