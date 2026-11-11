# 02 — Recover business rules

## Objective
Create candidate rules by comparing implementation, tests, UI, seed data, comments, and baseline documentation.
## Required context and areas
Inspect `src/LegacyNoticeManager`, `tests`, and `docs/baseline`.
## Change constraints
Documentation only. Do not change behaviour or choose between conflicting sources.
## Response format
For every candidate: REQ ID, rule, source path/line, confidence, conflict, impact, SME question, review status. Separate observed code behaviour from policy.
## Assumptions
List assumptions and explain which evidence would confirm them.
## Validation and evidence
Check citations and ID uniqueness; do not claim a rule is confirmed by tests alone. Update requirements template and evidence record with commands actually run.
