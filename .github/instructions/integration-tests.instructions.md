---
applyTo: "tests/Integration/**/*.cs"
---
# Integration tests

Applies to HTTP, MVC, persistence, and state-transition tests. Use isolated synthetic SQLite data and avoid external services. Do not rely on shared mutable state or ordering. Check both response and persisted effects. Preserve uncertainties as questions rather than hard-coding guesses. Run `dotnet test tests/Integration`; add requirement/risk/test/evidence traceability.
