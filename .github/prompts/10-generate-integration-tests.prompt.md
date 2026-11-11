# 10 — Generate integration tests

## Objective
Cover one important MVC/HTTP/persistence/state boundary.
## Required context and areas
Inspect controller route, database setup, integration-test host, and linked requirement/risk.
## Change constraints
Test-only change. Isolate synthetic SQLite data and avoid external dependencies.
## Response format
Boundary and rationale; setup; positive/negative case; persisted effects; assumptions; result.
## Assumptions
Do not make database current behaviour authoritative policy.
## Validation and evidence
Run `dotnet test tests/Integration`; verify isolation and record exact output and trace links.
