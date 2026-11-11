# Repository instructions for GitHub Copilot

- Understand the application before proposing or making changes. Cite repository paths and line locations when explaining observed behaviour.
- Separate observed facts, inference, and policy assumptions. List ambiguity and questions requiring subject-matter-expert input.
- Prefer small, reviewable changes and preserve baseline behaviour unless a change is explicitly requested.
- For a seeded behaviour, add a characterisation test before correcting it. Explain why the test level is appropriate.
- Include negative and boundary cases where relevant; test behaviour rather than implementation detail.
- Do not silently change business rules or treat comments, docs, or passing tests as authoritative policy.
- Update requirement/risk/test/evidence traceability when a rule or test changes.
- Keep all content synthetic. Never add production data, credentials, secrets, or unsafe exploit examples.
- Treat generated outputs as drafts requiring human review. Record accepted, amended, rejected, or deferred decisions.
- Preserve the workshop's educational value; do not broadly refactor during discovery tasks.
- Flag security, accessibility, privacy, and governance concerns without claiming a scanner proves assurance.
- Use UK English in prose and follow existing naming and documentation conventions.
- Run relevant validation commands, report exactly what was run and its actual outcome, and do not claim success based only on inspection.
- Consult the nearest `AGENTS.md` and applicable path-specific instructions.
