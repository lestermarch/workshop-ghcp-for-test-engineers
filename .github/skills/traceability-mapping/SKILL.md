---
name: traceability-mapping
description: Maintain human-readable links between recovered requirements, source evidence, risks, tests, results, and decisions.
---
# Traceability mapping

Use stable unique IDs and update `evidence/traceability.csv`. Link every assertion to source evidence; requirement to risk; risk to test; test result to an evidence record; and proposed change to a human review decision. Blank means unknown, not zero risk. Never invent a resolution. Run `python scripts/validate_traceability.py` and explain semantic links that a script cannot verify.
