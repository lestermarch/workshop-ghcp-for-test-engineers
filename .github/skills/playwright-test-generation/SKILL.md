---
name: playwright-test-generation
description: Generate isolated, resilient .NET Playwright tests from observed Legacy Notice Manager behaviour.
---
# Playwright test generation

Use the live app first. Follow xUnit and `BrowserTestBase` in `tests/EndToEnd`. Create one new browser context per test; let the fixture start/stop the app and use unique synthetic data. Prefer role/label/name locators and web-first assertions. Avoid arbitrary sleeps, fixed shared state, and CSS/DOM selectors unless no semantic locator exists. Use deterministic inputs and explain assumptions. On failure, capture screenshot and trace in ignored `TestResults/BrowserArtifacts`; on success, stop/discard trace. Add a TestId and traceability row for each scenario. Run focused E2E and related regression tests; distinguish failure from skipped.
