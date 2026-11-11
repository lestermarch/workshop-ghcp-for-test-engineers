using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Microsoft.Playwright;

namespace LegacyNoticeManager.EndToEndTests;

public sealed class BrowserApplicationFixture : IAsyncLifetime
{
    private readonly object _outputLock = new();
    private readonly StringBuilder _applicationOutput = new();
    private Process? _application;
    private IPlaywright? _playwright;
    private string? _databasePath;

    public string RepositoryRoot { get; private set; } = "";
    public string BaseUrl { get; private set; } = "";
    public string ArtifactDirectory { get; private set; } = "";
    public IBrowser Browser { get; private set; } = null!;

    public async Task InitializeAsync()
    {
        RepositoryRoot = FindRepositoryRoot();
        ArtifactDirectory = Path.Combine(RepositoryRoot, "TestResults", "BrowserArtifacts");
        var port = GetAvailablePort();
        BaseUrl = $"http://127.0.0.1:{port}";
        _databasePath = Path.Combine(Path.GetTempPath(), $"notice-e2e-{Guid.NewGuid():N}.db");
        var appAssemblyPath = Path.Combine(
            RepositoryRoot,
            "src",
            "LegacyNoticeManager",
            "bin",
            new DirectoryInfo(AppContext.BaseDirectory).Parent!.Name,
            Path.GetFileName(Path.TrimEndingDirectorySeparator(AppContext.BaseDirectory)),
            "LegacyNoticeManager.dll");

        var startInfo = new ProcessStartInfo("dotnet")
        {
            WorkingDirectory = RepositoryRoot,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        };
        startInfo.ArgumentList.Add(appAssemblyPath);
        startInfo.Environment["ASPNETCORE_URLS"] = BaseUrl;
        startInfo.Environment["ConnectionStrings__NoticeDatabase"] = $"Data Source={_databasePath}";

        _application = new Process { StartInfo = startInfo, EnableRaisingEvents = true };
        _application.OutputDataReceived += AppendApplicationOutput;
        _application.ErrorDataReceived += AppendApplicationOutput;
        if (!_application.Start())
        {
            throw new InvalidOperationException("The local ASP.NET Core process did not start.");
        }

        _application.BeginOutputReadLine();
        _application.BeginErrorReadLine();
        await WaitForApplicationAsync();

        _playwright = await Playwright.CreateAsync();
        var headless = !string.Equals(Environment.GetEnvironmentVariable("E2E_HEADLESS"), "false", StringComparison.OrdinalIgnoreCase);
        var slowMo = int.TryParse(Environment.GetEnvironmentVariable("E2E_SLOW_MO_MS"), out var configuredSlowMo)
            ? Math.Max(0, configuredSlowMo)
            : 0;
        Browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = headless,
            SlowMo = slowMo
        });
    }

    public async Task DisposeAsync()
    {
        if (Browser is not null)
        {
            await Browser.CloseAsync();
        }
        _playwright?.Dispose();

        if (_application is not null)
        {
            if (!_application.HasExited)
            {
                _application.Kill(entireProcessTree: true);
                await _application.WaitForExitAsync();
            }
            _application.Dispose();
        }

        if (_databasePath is not null && File.Exists(_databasePath))
        {
            File.Delete(_databasePath);
        }
    }

    public string GetApplicationOutput()
    {
        lock (_outputLock)
        {
            return _applicationOutput.ToString();
        }
    }

    private async Task WaitForApplicationAsync()
    {
        using var client = new HttpClient { Timeout = TimeSpan.FromSeconds(1) };
        var deadline = DateTime.UtcNow.AddSeconds(20);
        while (DateTime.UtcNow < deadline)
        {
            if (_application!.HasExited)
            {
                throw new InvalidOperationException($"The application exited during startup.{Environment.NewLine}{GetApplicationOutput()}");
            }

            try
            {
                using var response = await client.GetAsync($"{BaseUrl}/Notices");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return;
                }
            }
            catch (HttpRequestException)
            {
            }
            catch (TaskCanceledException)
            {
            }

            await Task.Delay(250);
        }

        throw new TimeoutException($"The application did not become ready at {BaseUrl}.{Environment.NewLine}{GetApplicationOutput()}");
    }

    private void AppendApplicationOutput(object sender, DataReceivedEventArgs args)
    {
        if (args.Data is null) return;
        lock (_outputLock)
        {
            _applicationOutput.AppendLine(args.Data);
        }
    }

    private static string FindRepositoryRoot()
    {
        for (var directory = new DirectoryInfo(AppContext.BaseDirectory); directory is not null; directory = directory.Parent)
        {
            if (File.Exists(Path.Combine(directory.FullName, "LegacyNoticeManager.sln")) &&
                File.Exists(Path.Combine(directory.FullName, "src", "LegacyNoticeManager", "LegacyNoticeManager.csproj")))
            {
                return directory.FullName;
            }
        }

        throw new DirectoryNotFoundException("Could not locate the Legacy Notice Manager repository root.");
    }

    private static int GetAvailablePort()
    {
        using var listener = new TcpListener(IPAddress.Loopback, 0);
        listener.Start();
        return ((IPEndPoint)listener.LocalEndpoint).Port;
    }
}
