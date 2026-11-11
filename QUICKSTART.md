# Quickstart

## Prerequisites

- .NET 10 SDK (the repository pins the 10.0 feature band in `global.json`).
- Python 3 for the repository validation scripts.
- Git for reset exercises.
- PowerShell 7 (`pwsh`) on Windows to run the Playwright browser installer.
- Playwright Chromium for browser tests; install with `.\scripts\install-playwright.ps1` or `bash scripts/install-playwright.sh`.

Run the portable readiness check first, from the repository root:

```shell
python scripts/workshop_ready.py
```

On Bash, use `python3` instead of `python`.
It reports pass, warning, and fail results with remediation. The `--deep` option also runs the facilitator reference suite, so save it until after the exercise; it runs E2E only when Chromium is detected. Copilot account, IDE rollout, and MCP-tool availability must be checked manually.

## Start the application

From the repository root:

```powershell
dotnet restore
dotnet run --project .\src\LegacyNoticeManager
```

Use the local HTTP or HTTPS address printed in the terminal. The first run creates a local SQLite database named `notices.db`; do not commit it. The seed records are synthetic. Ctrl+C stops the app.

To select a separate database path, set `ConnectionStrings__NoticeDatabase`, for example:

```powershell
$env:ConnectionStrings__NoticeDatabase = "Data Source=$PWD\workshop-notices.db"
```

## Run validation

```powershell
dotnet test .\tests\Unit
dotnet test .\tests\Integration
dotnet test .\tests\EndToEnd
```

The E2E fixture starts and stops the application and its temporary SQLite database automatically. `.\scripts\e2e.ps1 -Mode headed` runs visibly; `-Mode debug` opens the Playwright Inspector; `-Mode report` rebuilds the HTML summary from the latest TRX result. The opt-in `E2E_CAPTURE_FAILURE=true` test intentionally fails to demonstrate screenshots and traces.

After the exercise, facilitators can run `dotnet test .\tests\Reference` and `.\scripts\verify.ps1`. The verification command includes the facilitator characterisation suite, browser installation, coverage collection, formatting, traceability, workshop readiness, and repository hygiene checks.

## Begin the workshop

Read [workshop/README.md](workshop/README.md), then complete Labs 00–10 using each checkpoint. Track local progress with `python scripts/workshop_progress.py show`. Record findings using the templates in `workshop/resources/` and `evidence/templates/`. Do not consult `reference-outcomes/` or `workshop/facilitator/` until the facilitator says to do so.
