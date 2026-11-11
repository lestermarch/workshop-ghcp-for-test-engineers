---
name: safe-legacy-refactoring
description: Plan a narrow legacy refactor using characterisation tests, explicit rollback, and post-change verification.
---
# Safe legacy refactoring

1. State the observable behaviour and source evidence.
2. Add and run characterisation tests before refactoring.
3. Define a narrow change boundary, out-of-scope behaviour, and rollback step.
4. Avoid changing policy or combining unrelated cleanup.
5. Run focused and broader relevant tests after the change; compare outcomes.
6. Update docs, traceability, evidence, and residual risks.

Stop for SME decision if desired behaviour is unclear. Never infer safety from a passing generated test suite alone.
