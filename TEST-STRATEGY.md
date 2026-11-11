# Test strategy

The participant baseline remains intentionally small. Unit tests cover a few common model behaviours; integration tests exercise the MVC register and SQLite seed. The Playwright suite adds three high-value browser scenarios for create/validation/edit/approval/export, search observation, and rejection/audit history. Its fixture starts the app automatically with a unique temporary SQLite database and uses an isolated context per test.

Facilitator-only characterization examples live in `tests/Reference`, outside the participant solution so the initial suite stays deliberately limited. These examples capture current surprises and must not be mistaken for approved requirements.

## Commands

```shell
dotnet test tests/Unit --collect:"XPlat Code Coverage"
dotnet test tests/Integration --collect:"XPlat Code Coverage"
dotnet test tests/EndToEnd
.\scripts\e2e.ps1 -Mode headed
.\scripts\e2e.ps1 -Mode debug
.\scripts\e2e.ps1 -Mode report
```

Install Chromium once with `scripts/install-playwright.ps1` or `scripts/install-playwright.sh`. The app fixture uses a temporary DB and automatically tears it down. Tests capture a full-page screenshot and a Playwright trace on failure in `TestResults/BrowserArtifacts`; the HTML summary generated from TRX is `TestResults/E2E/index.html`. Use the generated Playwright script's `show-trace` command to inspect a `.zip` trace. The intentional failure demonstration is skipped unless `E2E_CAPTURE_FAILURE=true` is set.

Tests use semantic locators, isolated browser contexts, unique titles, and condition-based waits. Headless mode is the default; `E2E_HEADLESS=false` enables headed execution and `E2E_DEBUG=true` pauses in the inspector. No video is recorded. Do not treat a skipped browser test as a pass, and do not treat any browser automation as accessibility conformance.

The follow-along workshop for turning a browser observation into a test is in [Lab 07](workshop/labs/lab-07-explore-the-application-in-a-browser.md), [Lab 08](workshop/labs/lab-08-create-and-run-playwright-tests.md), and [Lab 09](workshop/labs/lab-09-investigate-review-and-record-evidence.md). Participants inspect a test before running it and make a human classification before any application change.

Coverage is a diagnostic baseline, not a quality target. Prioritise boundary, state transition, error, audit, persistence, date, accessibility, privacy, and concurrency behaviours by risk. Reference examples in `reference-outcomes/` are facilitator material.
