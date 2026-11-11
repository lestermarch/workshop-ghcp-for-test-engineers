# Example reference test-gap analysis

| Gap | Priority | Recommended evidence |
|---|---|---|
| Approval does not record an audit event | High | Integration test checks state and audit rows; confirm audit policy first |
| Date boundary and local-time semantics | High | Characterisation tests for equal dates, midnight, and configured time zone |
| High severity description rule on edit/approval | High | Create/edit/approval integration tests with missing description |
| Search case and whitespace | Medium | Search integration tests across title and region |
| Stale concurrent edit | Medium | Persistence test with two contexts and an explicit conflict policy |
| Accessible field errors | Medium | Browser/manual keyboard check plus semantic assertions |
| Export CSV quoting and formula-safe content | Medium | Unit tests for quoting and safe export formatting |

Priorities are examples for discussion; teams should justify them against impact and likelihood.

The facilitator-only `tests/Reference` project contains passing characterization examples for search, state restriction, export restriction, a date boundary, audit omission, stale updates, a form label, emergency timing, and model validation. These tests describe current behavior; they do not declare every behavior desirable.
