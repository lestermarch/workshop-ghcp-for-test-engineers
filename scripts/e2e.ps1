param(
    [ValidateSet("headless", "headed", "debug", "report")]
    [string]$Mode = "headless"
)

$ErrorActionPreference = "Stop"
$root = Split-Path -Parent $PSScriptRoot
Push-Location $root
try {
    if ($Mode -eq "report") {
        python scripts\create_e2e_report.py
        if ($LASTEXITCODE -ne 0) { throw "Could not create the E2E report." }
        return
    }

    $env:E2E_HEADLESS = if ($Mode -eq "headless") { "true" } else { "false" }
    if ($Mode -eq "debug") { $env:E2E_DEBUG = "true" } else { Remove-Item Env:E2E_DEBUG -ErrorAction SilentlyContinue }
    dotnet test tests\EndToEnd\LegacyNoticeManager.EndToEndTests.csproj --logger "trx;LogFileName=e2e.trx" --results-directory TestResults\E2E
    $testExitCode = $LASTEXITCODE
    python scripts\create_e2e_report.py
    if ($LASTEXITCODE -ne 0) { throw "Could not create the E2E report." }
    if ($testExitCode -ne 0) { throw "E2E tests failed with exit code $testExitCode; the report was generated." }
}
finally {
    Pop-Location
}
