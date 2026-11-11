# Lab 09 — Investigate, review, and record evidence

**Estimated duration:** 17 minutes
**All terminal commands:** run from the repository root unless a task says otherwise.

## Purpose

Use the test result and browser evidence to make a reviewable human decision, update traceability, and record unresolved questions without treating Copilot's recommendation as authority.

## Learning objectives

- Reproduce and classify a browser-test result.
- Inspect screenshot, trace, report, documentation, and implementation in evidence-first order.
- Accept, amend, reject, or defer a Copilot output.
- Record a requirement/risk/test/evidence link and exact validation outcome.

## Starting state

Lab 08 has a focused result and, if it failed, saved artifacts. Keep the participant app data synthetic. Do not read facilitator answers until the facilitator authorises the comparison.

## Files involved

`TestResults/BrowserArtifacts/`, `TestResults/E2E/index.html`, `evidence/templates/BROWSER-OBSERVATION-TEMPLATE.md`, `evidence/templates/AI-ACTIVITY-TEMPLATE.md`, `evidence/requirements.csv`, `evidence/risks.csv`, `evidence/traceability.csv`, and `scripts/validate_traceability.py`.

## Tasks

1. **Terminal — reproduce:** rerun only the focused test from Lab 08. Record the exact command and outcome.
2. **Open:** inspect the failure output, screenshot, trace, and report before opening application source. For the standard Debug build, PowerShell can use `pwsh tests\EndToEnd\bin\Debug\net10.0\playwright.ps1 show-trace TestResults\BrowserArtifacts\<scenario>.zip`; Bash can use `bash tests/EndToEnd/bin/Debug/net10.0/playwright.sh show-trace TestResults/BrowserArtifacts/<scenario>.zip`. Replace `<scenario>` with the actual trace filename. If that script or trace viewer is unavailable, record the limitation and inspect the screenshot and test output.
3. **Open:** after recording a hypothesis, inspect the relevant participant documentation and then the smallest relevant source/test area. Verify whether your expected result has an authoritative source.
4. **Copilot — review:** use **Evidence and Governance Reviewer** or **Change Reviewer** with the prompt below. Provide the test result and redacted/synthetic evidence only.
5. **Human decision:** choose one classification: product appears incorrect; test appears incorrect; test data or environment issue; expected behaviour is ambiguous; further investigation required. Then choose accept, accept with amendments, reject, or defer for SME input.
6. **Evidence:** complete both the browser observation template and the AI activity template. Record exact commands, outputs, artifact paths, reviewer, assumptions, and unresolved questions.
7. **Traceability:** draft a requirement, risk, test, and evidence link for the new test. After a human approves the row, add it to the repository CSVs using the existing columns. Run `python scripts/validate_traceability.py`; it should resolve the new test ID and evidence record. If the team does not approve the test or expected requirement, record the deferral rather than inventing a requirement.
8. **Review:** inspect `git diff --` for the intended test and evidence paths. Keep or reset the new participant-created test with `python scripts/reset_workshop.py LAB-08 --confirm`. For approved traceability edits, remove only your own rows if you choose to reset; do not restore whole evidence files that contain other work.

## Copyable prompts

```text
Review this browser-test result as a testing peer. Do not modify code or evidence. First classify the likely cause as product behaviour, test logic, test data/environment, ambiguity, or further investigation. Use the screenshot/trace or result details I provide, but do not claim to have opened artifacts you cannot access. Separate observed facts, hypotheses, expected behaviour sources, and unresolved questions. Recommend the smallest next investigation and identify what human or SME decision is needed. A passing test does not prove the requirement is correct.

Test result and command:
[paste exact result]

Observation and evidence paths:
[paste synthetic observation and local artifact paths]

Requirement/risk context:
[paste only approved participant-facing context]
```
See the [Lab 09 prompt review card](../resources/PROMPT-REVIEW-CARDS.md#lab-09-failure-review).

## Expected observations

Evidence can strengthen or weaken a hypothesis but does not establish a business rule by itself. Some failures should be fixed in the test, some require environment repair, and some should be deferred for product/SME input.

## Validation checkpoint

Complete [Checkpoint LAB-09](../checkpoints/lab-09.md). The decision is human-owned, evidence fields are complete, and traceability references resolve after approved rows are added.

## Discussion questions

- What evidence changed your first impression?
- Did Copilot recommend a change that you should not accept yet?
- What remains unknown after the test passes or fails?
- What evidence would be required before a production change?

## Troubleshooting

If no artifacts exist because the test passed, use the opt-in demonstration only when the facilitator approves; its failure is intentional and not a product defect. PowerShell: set `$env:E2E_CAPTURE_FAILURE = "true"`, run `.\scripts\e2e.ps1 -Mode headless`, then remove the variable with `Remove-Item Env:E2E_CAPTURE_FAILURE`; the script reports an expected test failure without closing the terminal. Bash: run `E2E_CAPTURE_FAILURE=true bash scripts/e2e.sh headless`; the command returns a non-zero test result. If the report is missing, run `.\scripts\e2e.ps1 -Mode report` or `bash scripts/e2e.sh report` after an E2E run that created a TRX file.

## Optional challenge

**Extend:** add a peer review checklist to the evidence record and ask another participant to challenge one assumption.

## Completion criteria

The result is classified, the human decision and evidence are recorded, and any accepted traceability changes pass the validator. No speculative application fix is made.

## Next lab

Continue to [Lab 10 — Apply the approach to your context](lab-10-apply-the-approach-to-your-context.md).
