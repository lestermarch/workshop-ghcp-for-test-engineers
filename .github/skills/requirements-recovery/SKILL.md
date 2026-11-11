---
name: requirements-recovery
description: Recover candidate requirements from code, tests, comments, UI, data, and existing documentation while preserving uncertainty.
---
# Requirements recovery

Inspect code, tests, comments, rendered UI, schema/seed data, and existing documentation. For each candidate, record a stable REQ ID, precise statement, source and location, confidence, conflict status, impact, SME question, and review status. Classify as confirmed observed behaviour, inferred requirement, conflict, assumption, or unresolved question. Passing tests prove only that observed implementation currently behaves as asserted. Do not silently choose between sources. Validate citations and use `docs/templates/recovered-requirements.md`.
