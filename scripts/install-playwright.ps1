$ErrorActionPreference = "Stop"
$root = Split-Path -Parent $PSScriptRoot
Push-Location $root
try {
    dotnet build tests\EndToEnd\LegacyNoticeManager.EndToEndTests.csproj
    if ($LASTEXITCODE -ne 0) { throw "E2E project build failed." }
    $script = Join-Path $root "tests\EndToEnd\bin\Debug\net10.0\playwright.ps1"
    if (-not (Test-Path $script)) { throw "Playwright installer not found at $script." }
    pwsh -NoLogo -NoProfile -File $script install chromium
    if ($LASTEXITCODE -ne 0) { throw "Playwright Chromium installation failed." }
}
finally {
    Pop-Location
}
