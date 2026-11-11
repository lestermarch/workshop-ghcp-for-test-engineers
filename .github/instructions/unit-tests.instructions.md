---
applyTo: "tests/Unit/**/*.cs"
---
# Unit tests

Applies to isolated tests of deterministic rules. Use meaningful behaviour names, clear arrange/act/assert sections, and boundary cases when justified. Avoid broad mocks and implementation-only assertions. First characterise legacy behaviour; do not fix production code inside a test task. Run `dotnet test tests/Unit` and record results. Map each material test to a requirement or risk in `evidence/traceability.csv`.
