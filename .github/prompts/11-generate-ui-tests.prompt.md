# 11 — Generate UI tests

## Objective
Add at most one robust Playwright test for a high-value user journey or accessibility behaviour.
## Required context and areas
Inspect views, routes, existing E2E tests, local startup instructions, and gap analysis.
## Change constraints
Keep scope small; do not add arbitrary sleeps or rely on external services.
## Response format
User value; accessible locator choice; prerequisites; test; changed files; run outcome.
## Assumptions
Distinguish browser/server unavailable from test pass; automation is not WCAG proof.
## Validation and evidence
Run with local app/Chromium when available; record exact command, pass/fail/skip, and residual manual checks.
