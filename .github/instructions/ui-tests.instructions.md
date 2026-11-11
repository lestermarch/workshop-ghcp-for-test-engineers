---
applyTo: "tests/EndToEnd/**/*.cs"
---
# UI tests

Applies to Playwright browser tests. The E2E fixture starts a local app with a temporary SQLite database, and each scenario gets an isolated browser context. Use accessible roles/names and avoid arbitrary sleeps. Failure captures belong under ignored `TestResults/BrowserArtifacts`; distinguish skipped from passed. Do not claim WCAG conformance from automation. Update the browser observation record and traceability evidence.
