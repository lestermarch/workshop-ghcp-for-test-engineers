# Legacy Notice Manager

A fully synthetic ASP.NET Core MVC application and workshop for practising AI-assisted legacy application testing. It contains no customer data or production dependencies. The starting application is intentionally incomplete and imperfect; that is the point of the exercise.

## What the application does

The fictional notice workflow creates, validates, approves or rejects, searches, and exports navigational notices. It also keeps a small audit history. The application is a teaching sample, not a maritime or safety system.

## Run it

Prerequisite: .NET 10 SDK. From the repository root:

```shell
dotnet restore
dotnet run --project src/LegacyNoticeManager
```

Open the local URL printed by ASP.NET Core. SQLite creates `notices.db` in the working directory on first run and loads synthetic seed records. See [QUICKSTART.md](QUICKSTART.md) for Windows, PowerShell, and test instructions.

## Run tests and checks

```shell
dotnet test tests/Unit
dotnet test tests/Integration
dotnet test tests/EndToEnd
```

After the exercise, facilitators can run `dotnet test tests/Reference`. This characterisation suite is deliberately not included in the participant baseline solution.

The E2E fixture starts the app with a temporary SQLite database and launches Chromium automatically. Install Chromium once with `.\scripts\install-playwright.ps1` (PowerShell) or `bash scripts/install-playwright.sh` (Bash). Use `.\scripts\e2e.ps1 -Mode headed`, `-Mode debug`, or `-Mode report`; on Bash use `bash scripts/e2e.sh headed`, `debug`, or `report`. Failure screenshots and traces are written to ignored `TestResults/BrowserArtifacts/`; the offline HTML report is `TestResults/E2E/index.html`. See [TEST-STRATEGY.md](TEST-STRATEGY.md). After the exercise, facilitators can run `./scripts/verify.sh` or `./scripts/verify.ps1`; these install Chromium and run the reference and headless E2E suites too.

## Start the Copilot demonstration

Follow [GOLDEN-PATH.md](GOLDEN-PATH.md), then use the prompts under `.github/prompts`. Copilot customisations and surface limitations are described in [COPILOT-CUSTOMISATION-GUIDE.md](COPILOT-CUSTOMISATION-GUIDE.md). Begin with discovery, not code generation. Treat every generated output as a draft and record a human decision.

The headline live exercise is black-box exploration in the browser, followed by one observed workflow test, a deliberate failure-artifact review, and a human decision. Start with `.github/prompts/explore-application-in-browser.prompt.md`; do not reveal facilitator outcomes to participants.

## Participant material

- [Workshop](WORKSHOP.md), [golden path](GOLDEN-PATH.md), [test strategy](TEST-STRATEGY.md)
- Baseline legacy notes in `docs/baseline/`
- Blank documentation templates in `docs/templates/`
- Evidence guidance and blank records in `evidence/`
- `KNOWN-ISSUES.md` provides participant-safe scope and limitations

## Facilitator-only material

`reference-outcomes/`, `tests/Reference`, `workshop/facilitator/`, and `workshop/hints/` contain facilitator guidance or exercise outcomes. They are publicly visible in this repository; participants should avoid them until after the relevant exercise. This separation is a convention, not a security boundary.

## Reset

Run `scripts/reset-baseline.ps1` or `scripts/reset-baseline.sh` from a Git checkout. The scripts ask before restoring tracked application and sample files; they preserve `evidence/`. See [GOVERNANCE.md](GOVERNANCE.md).

## Limitations

This is a compact workshop proof of concept. It has no authentication, role management, production-grade audit guarantees, or operational monitoring. The seed data and business rules are fictional. Automated tests and scanners are evidence, not proof of correctness, accessibility, or security.
