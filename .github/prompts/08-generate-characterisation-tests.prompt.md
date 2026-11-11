# 08 — Generate characterisation tests

## Objective
Capture one surprising legacy behaviour before any correction.
## Required context and areas
Inspect target source, adjacent tests, risk/requirement, and `tests/Unit` or `tests/Integration`.
## Change constraints
Test-only change. Do not change production code or encode an unapproved policy as desired behaviour.
## Response format
Observed behavior; uncertainty; test-level rationale; proposed test; changed files; exact validation result.
## Assumptions
Label the test as characterisation of current behaviour, not endorsement.
## Validation and evidence
Run the focused test before proposing a fix; record pass/fail and map the test to source/risk/evidence.
