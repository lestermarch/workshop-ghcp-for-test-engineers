# 17 — Propose safe refactoring

## Objective
Recommend one narrow refactor that preserves observed behaviour.
## Required context and areas
Inspect the target code, characterisation tests, linked rule/risk, and current working-tree changes.
## Change constraints
Proposal first. Do not combine unrelated cleanup or alter business rules. Require rollback steps.
## Response format
Scope; behaviour to preserve; tests needed first; proposed edits; out-of-scope; rollback; validation.
## Assumptions
List unverified expectations and stop for SME input if behaviour is ambiguous.
## Validation and evidence
Run no claims without command output. If implementation is requested, run focused and relevant broader checks and record evidence.
