---
name: workshop-reset
description: Restore tracked demo baseline files safely while preserving participant evidence.
---
# Workshop reset

Confirm the repository root and inspect pending changes. Explain that reset restores tracked `src/`, `tests/`, `samples/`, and `docs/baseline/` only, and preserves `evidence/`. Obtain explicit user confirmation before running the reset script. Do not delete untracked files, evidence, reference outcomes, or the whole repository. After confirmation use `scripts/reset-baseline.ps1` or `.sh`, then inspect status and rerun baseline tests. If the working tree is not a Git checkout, stop and explain the limitation.
