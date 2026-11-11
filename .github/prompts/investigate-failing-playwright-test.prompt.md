# Investigate failing Playwright test

## Objective
Reproduce and classify a failing browser test without reflexively changing its assertion.
## Required context and areas
Use test output, application logs, screenshot/trace artifacts, exact journey, and linked requirement/risk.
## Change constraints
Investigate first. Do not edit application code or weaken the test until evidence and expected behaviour are reviewed.
## Response format
Reproduction; UI state; artifact findings; likely category (application/test/environment/data/ambiguity); requirement evidence; smallest next action; reviewer decision needed.
## Assumptions
Separate tool failure and startup failure from product behaviour.
## Validation and evidence
Run the same focused test once to reproduce. Record commands/results and artifact paths; rerun only after the correction is understood and agreed.
