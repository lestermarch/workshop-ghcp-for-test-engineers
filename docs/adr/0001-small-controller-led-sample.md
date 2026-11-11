# ADR 0001: Keep the baseline controller-led

- **Status:** Accepted for workshop baseline
- **Context:** The exercise needs behaviour that can be discovered in one short session.
- **Decision:** Keep the workflow in a compact MVC controller and use SQLite/EF Core for local persistence. Do not introduce production infrastructure.
- **Consequences:** Some separation-of-concerns and validation gaps are intentional teaching material. Any later refactor should be narrow and backed by characterisation tests.
