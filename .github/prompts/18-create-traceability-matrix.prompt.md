# 18 — Create traceability matrix

## Objective
Link recovered requirements to source, risks, tests, results, evidence, and review decisions.
## Required context and areas
Inspect requirements, risk, test inventory, evidence records, source, and `evidence/traceability.csv`.
## Change constraints
Update traceability data only; do not fabricate missing IDs or links.
## Response format
Matrix with unresolved links and owners; duplicate or broken references; next actions.
## Assumptions
Blank references mean unknown; explain why they are unknown.
## Validation and evidence
Run `python scripts/validate_traceability.py`; report actual result and add an activity record.
