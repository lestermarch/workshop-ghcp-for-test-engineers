# Evidence guide

For each Copilot-assisted activity, copy `evidence/templates/AI-ACTIVITY-TEMPLATE.md` and complete the required fields. Include exact commands and observed output; distinguish not run, passed, failed, and skipped. Do not paste secrets, real user data, or sensitive work content.

Use the three synthetic examples under `evidence/examples/` to practise accepted, amended, and rejected decisions. `evidence/traceability.csv` links requirements, risks, source evidence, tests, and evidence IDs. Run `python scripts/validate_traceability.py` after edits.

For browser exploration, copy `evidence/templates/BROWSER-OBSERVATION-TEMPLATE.md`. Link the page/action/input to any screenshot under `TestResults/BrowserArtifacts`, trace `.zip`, requirement, risk, resulting test, and human decision. These generated browser artifacts are local/CI evidence and are intentionally ignored by Git.

The guided participant flow and scorecard are under [workshop/resources](workshop/resources/observation-worksheet.md). Local progress and participant scratch files are ignored; copy only reviewed evidence into the repository's shared traceability files.
