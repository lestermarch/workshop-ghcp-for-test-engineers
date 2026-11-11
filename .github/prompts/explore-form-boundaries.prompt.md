# Explore form boundaries

## Objective
Observe form behaviour across invalid, boundary, and repeated inputs before source inspection.
## Required context and areas
Start the local app and use browser tools to exercise blank input, minimum/maximum lengths, just-inside/outside values, whitespace, unusual but valid characters, dates, invalid date combinations, duplicate values, and repeated submission.
## Change constraints
Browser-only and read-only with respect to source. Use synthetic values and do not submit real data.
## Response format
For each case: page/control, input, client-visible response, server-visible response, navigation/state, evidence, and unknown expected policy.
## Assumptions
Do not assume client validation equals server validation or that current behaviour is correct.
## Validation and evidence
Capture results and screenshot/trace references. Only after observations, compare selected cases to source and label discrepancies. No code change.
