# Generate Playwright test from observation

## Objective
Turn one verified browser observation into the minimum useful automated test.
## Required context and areas
Use an observation record, its source/evidence, candidate requirement/risk, and `tests/EndToEnd`.
## Change constraints
Test-only unless the user separately requests an application fix. Do not change production code just to pass the test.
## Response format
Evidence summary; requirement status; ambiguity; test level/locator rationale; test code and changed files; exact run result; screenshot/trace; traceability; follow-up.
## Assumptions
If no authoritative expected result exists, write a characterization test or defer an normative assertion for SME review.
## Validation and evidence
Run the focused Playwright test, capture actual outcome, update `evidence/traceability.csv` and the browser activity record. Do not claim a fix from a green test alone.
