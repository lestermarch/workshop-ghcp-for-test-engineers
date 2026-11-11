# Traceability

The human-readable source of truth is `evidence/traceability.csv`. IDs use stable prefixes: `REQ-`, `RISK-`, `TEST-`, `ISSUE-`, and `EV-`. A row links a candidate requirement to its source, risk, test, and evidence. Leave unknown links blank and record the reason; never invent a link to satisfy validation.

Validate references with:

```shell
python scripts/validate_traceability.py
```

Add test IDs to the CSV before adding assertions. Evidence files must be named using their `EV-` identifiers under `evidence/`.
