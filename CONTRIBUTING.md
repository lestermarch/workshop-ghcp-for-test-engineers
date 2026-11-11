# Contributing

Contributions should preserve the workshop's synthetic scope and the baseline's educational value.

1. Explain the behaviour or workshop gap and cite evidence.
2. Keep changes narrow; do not silently repair seeded behaviours.
3. Add or update tests before changing a seeded behaviour, and link them to requirements or risks in `evidence/traceability.csv`.
4. Record AI assistance and human review in an evidence record.
5. Run `scripts/verify.ps1` (PowerShell) or `scripts/verify.sh` (Bash) and report the exact outcome.
6. Never add real data, credentials, unsafe demonstration payloads, or a claim that automated checks prove compliance.

Use the pull-request template. If a business rule is uncertain, request subject-matter-expert review instead of resolving it by assumption.
