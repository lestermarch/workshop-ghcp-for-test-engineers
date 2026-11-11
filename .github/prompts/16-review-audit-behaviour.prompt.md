# 16 — Review audit behaviour

## Objective
Map state-changing operations to stored audit events and identify accountability gaps.
## Required context and areas
Inspect `AuditRecord`, `NoticeDbContext`, all state-changing controller actions, and tests.
## Change constraints
Do not alter audit semantics before the event requirements are agreed.
## Response format
Action/event/actor/time/data table; gaps; privacy concerns; candidate tests; SME questions.
## Assumptions
Do not assume `ApprovedAt` is a sufficient audit record.
## Validation and evidence
Check actual persistence code and run only relevant tests; update risk and evidence links.
