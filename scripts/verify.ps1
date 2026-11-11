$ErrorActionPreference = "Stop"
$root = Split-Path -Parent $PSScriptRoot
Push-Location $root
try {
    dotnet restore LegacyNoticeManager.sln
    if ($LASTEXITCODE -ne 0) { throw "dotnet restore failed." }
    dotnet build LegacyNoticeManager.sln --no-restore
    if ($LASTEXITCODE -ne 0) { throw "dotnet build failed." }
    .\scripts\install-playwright.ps1
    if ($LASTEXITCODE -ne 0) { throw "Playwright browser installation failed." }
    dotnet test LegacyNoticeManager.sln --no-build --collect:"XPlat Code Coverage" --logger "console;verbosity=minimal"
    if ($LASTEXITCODE -ne 0) { throw "dotnet test failed." }
    dotnet test tests\Reference\LegacyNoticeManager.ReferenceTests.csproj --collect:"XPlat Code Coverage" --logger "console;verbosity=minimal"
    if ($LASTEXITCODE -ne 0) { throw "Reference characterization tests failed." }
    dotnet format LegacyNoticeManager.sln --verify-no-changes --no-restore
    if ($LASTEXITCODE -ne 0) { throw "dotnet format check failed." }
    dotnet format tests\Reference\LegacyNoticeManager.ReferenceTests.csproj --verify-no-changes --no-restore
    if ($LASTEXITCODE -ne 0) { throw "Reference test formatting check failed." }
    python scripts/validate_repository.py
    if ($LASTEXITCODE -ne 0) { throw "Repository validation failed." }
    python scripts/check_workshop.py
    if ($LASTEXITCODE -ne 0) { throw "Workshop validation failed." }
    python scripts/validate_traceability.py
    if ($LASTEXITCODE -ne 0) { throw "Traceability validation failed." }
    python scripts/check_workshop_readiness.py
    if ($LASTEXITCODE -ne 0) { throw "Workshop readiness check failed." }
    python scripts/check_secrets.py
    if ($LASTEXITCODE -ne 0) { throw "Secret hygiene check failed." }
}
finally {
    Pop-Location
}
