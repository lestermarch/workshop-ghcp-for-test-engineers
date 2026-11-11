# Explore state transitions

## Objective
Build an observed state-transition model by interacting with the running application.
## Required context and areas
Explore available draft, rejected, approved, submitted, expired, or equivalent states using synthetic seed/new records.
## Change constraints
Browser-only for the first pass. Do not infer missing states, alter data outside the local demo, or read source before writing observations.
## Response format
State/action/precondition/observed result/next visible state/audit evidence/uncertainty; then candidate tests and SME questions.
## Assumptions
Mark states that cannot be reached and distinguish disabled UI from server-enforced restriction.
## Validation and evidence
Repeat key transitions in a fresh record. After documenting the observed model, inspect source and compare implementation. Record exact actions and artifacts; do not change code.
