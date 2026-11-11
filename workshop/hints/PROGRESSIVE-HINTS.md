# Progressive facilitator hints

Reveal one hint at a time; do not jump to the answer key.

1. Compare the prose in `docs/baseline/` with the model and controller.
2. Trace the create and edit POST actions side by side.
3. List every action that changes `Status`; check which also writes an audit row.
4. Try equal dates, leading/trailing spaces, and case variants using synthetic values.
5. Search for values derived from local machine time and ask what date-only means.
6. Follow one request from Razor form through controller to SQLite, then identify what a second simultaneous update would do.
7. Inspect labels, validation messages, output contexts, and export formatting separately. A finding in one output context does not imply another is vulnerable.
8. For each candidate fix, ask for a failing characterisation test and an explicit policy decision.
