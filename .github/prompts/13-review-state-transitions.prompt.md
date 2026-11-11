# 13 — Review state transitions

## Objective
Map allowed and implemented notice transitions and side effects.
## Required context and areas
Inspect all actions that read or write `Status`, audit writes, views, tests, and docs.
## Change constraints
Do not change transitions or presume undocumented states invalid.
## Response format
Transition table with current state/action/preconditions/next state/audit/route evidence; gaps; candidate tests.
## Assumptions
Separate implementation from policy and label unsupported transitions as questions.
## Validation and evidence
Cross-check every state mutation and record exact commands actually run.
