# Explore application in browser

## Objective
Explore the live application as a black-box tester and produce a first-pass journey map.
## Required context and areas
Start the application using `dotnet run --project src/LegacyNoticeManager`; use available browser navigation, accessibility snapshot, click, type, and keyboard tools. Do not read implementation code initially. Use README/QUICKSTART only for setup.
## Change constraints
Read-only; synthetic data only; no source inspection until browser observations are recorded.
## Response format
Journey map; timestamped/action observations; possible problems classified as observed/suspected/usability/accessibility/ambiguity/candidate requirement/SME question; candidate tests; evidence references; unanswered questions.
## Assumptions
State whether browser interactions were actually performed. Separate observed results from expected results and interpretation.
## Validation and evidence
Repeat key observations in a fresh browser context when practical. Capture screenshot/test-artifact paths where supported. Save findings using `evidence/templates/BROWSER-OBSERVATION-TEMPLATE.md`. Do not modify code.
