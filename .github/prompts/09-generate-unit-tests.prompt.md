# 09 — Generate unit tests

## Objective
Add focused xUnit coverage for a deterministic rule or boundary.
## Required context and areas
Inspect the model/rule implementation and existing unit-test patterns.
## Change constraints
Change tests only unless explicitly asked otherwise. Keep data local, deterministic, and explicit; avoid over-mocking.
## Response format
Behaviour under test, assumptions, test cases, changed files, test-level rationale, result.
## Assumptions
Clarify whether expected behaviour is observed legacy behaviour or an approved requirement.
## Validation and evidence
Run `dotnet test tests/Unit`; report actual result and update traceability/evidence.
