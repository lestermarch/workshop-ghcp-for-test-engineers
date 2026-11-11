# Facilitator answer guidance

**Facilitator-only.** This is a map to existing answer material, not a participant checklist. Outcomes are teaching prompts, not exhaustive truth. Accept defensible alternatives with evidence and explicit uncertainty.

## Seeded issue mapping

Use `reference-outcomes/seeded-issues.csv` for details and `reference-outcomes/ANSWER-KEY.md` for narrative guidance. Open only after participants have recorded their own evidence.

| Issue | Topic | Useful lab |
|---|---|---|
| ISSUE-01 | Expiry/effective-date boundary and policy ambiguity | 01, 07–09 |
| ISSUE-02 | Create/edit validation consistency | 07–09 |
| ISSUE-03 | Date/time assumptions | 01, 07–09 |
| ISSUE-04 | State transitions and approval prerequisites | 07–09 |
| ISSUE-05 | Error handling and exposed diagnostics | 07–09 |
| ISSUE-06 | Auditability of approval | 07–09 |
| ISSUE-07 | Duplicate-title normalisation | 07–09 |
| ISSUE-08 | Search semantics | 01, 07–09 |
| ISSUE-09 | Accessible labels and validation feedback | 07–09 |
| ISSUE-10 | CSV escaping and formula interpretation | 07–09 |
| ISSUE-11 | Operational event observability | 02, 09–10 |
| ISSUE-12 | Stale updates and concurrency | 07–10 |
| ISSUE-13 | Partial documentation versus implementation | 01–04, 09 |
| ISSUE-14 | Missing unit boundary coverage | 01, 04, 08 |
| ISSUE-15 | Missing integration coverage | 01, 04, 08 |
| ISSUE-16 | Browser journey coverage | 01, 07–09 |

## Worked “do not accept the first recommendation” example

If Copilot sees the partial statement “Expiry should normally be later than the effective date” and recommends changing the equal-date condition to reject same-day expiry, do not accept that as a policy decision. Ask participants to locate the exact implementation and documentation, label the difference as an ambiguity, and request a policy owner. A characterisation test can capture what the code currently does, but cannot approve that behaviour.

If Copilot proposes changing application code immediately after a failure, the correct workshop response is to pause, inspect browser evidence, classify the likely cause, verify the expected-result source, and ask a human reviewer. A test failure alone is not permission to change product behaviour.

## Assessment guidance

- Prefer evidence and a clear statement of uncertainty over matching a predetermined answer.
- A good test proposal has a named user-visible behavior, test-level rationale, and an expected-result source or explicit ambiguity.
- A rejected community asset is a successful supply-chain decision if the review is documented.
- Do not accept broad test additions, invented requirements, or security/accessibility claims without appropriate review.
