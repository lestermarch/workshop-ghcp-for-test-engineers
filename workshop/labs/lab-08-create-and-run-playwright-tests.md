# Lab 08 — Create and run Playwright tests

**Estimated duration:** 22 minutes
**All terminal commands:** run from the repository root unless a task says otherwise.

## Purpose

Convert one Lab 07 browser observation into the smallest useful automated test, run it in isolated Chromium, and classify the result without automatically changing production code.

## Learning objectives

- Link a test idea to an observation and requirement/risk evidence.
- Choose accessible, resilient locators and a focused test level.
- Inspect generated test code before executing it.
- Run headed or headless tests and inspect screenshots/traces when relevant.

## Starting state

Lab 07 has a completed observation. Chromium is installed. No approved app-code change is assumed.

## Files involved

`.github/agents/playwright-test-engineer.agent.md`, `.github/prompts/generate-playwright-test-from-observation.prompt.md`, `.github/instructions/ui-tests.instructions.md`, `tests/EndToEnd/BrowserApplicationFixture.cs`, `tests/EndToEnd/BrowserTestBase.cs`, `tests/EndToEnd/NoticeJourneyTests.cs`, and `evidence/traceability.csv`.

## Tasks

1. **Copilot — agent:** select **Playwright Test Engineer** or paste the agent definition into Chat. Supply your observation, its evidence source, the applicable requirement/risk if known, and the new test file path `tests/EndToEnd/ParticipantPlaywrightTests.cs`.
2. **Copilot — test generation:** use `generate-playwright-test-from-observation.prompt.md`. Require the agent to state a test-level rationale, locator strategy, expected behaviour source, uncertainty, and exact command. Prohibit edits outside the new test file.
3. **Inspect:** before running, compare the code with `NoticeJourneyTests.cs`. Check that it:
   - starts from the isolated fixture and synthetic data;
   - uses a unique title or fixture-provided stable data;
   - uses roles, labels, or other justified semantic locators;
   - uses condition-based assertions, not arbitrary sleep;
   - tests the observation rather than implementation details;
   - does not make an unsupported policy assertion.
4. **Edit:** add the reviewed scenario as a separate test in `ParticipantPlaywrightTests.cs`. Give it a new test trait such as `TEST-E2E-04`; do not duplicate an existing ID.
5. **Terminal — repository root:** run the focused test by its class name:

   ```shell
   dotnet test tests/EndToEnd --filter "FullyQualifiedName~ParticipantPlaywrightTests"
   ```

   For a visible run, use `.\scripts\e2e.ps1 -Mode headed` in PowerShell or `bash scripts/e2e.sh headed` in Bash. Use `debug` only if the facilitator environment supports an interactive display.
6. **Observe:** save the exact test result. On failure inspect the generated screenshot and `.zip` trace in `TestResults/BrowserArtifacts`; the HTML summary is `TestResults/E2E/index.html` when run through the script.
7. **Human decision:** classify the result as product appears incorrect, test appears incorrect, test data or environment issue, expected behaviour is ambiguous, or further investigation required. Do not ask Copilot to change application code automatically.

## Copyable prompts

```text
Turn the following browser observation into one focused .NET Playwright/xUnit test for this repository. Do not edit application code or existing tests. First state the observed behaviour, evidence, expected behaviour source (or ambiguity), smallest useful test, locator strategy, and why the test level is appropriate. Then propose code only for `tests/EndToEnd/ParticipantPlaywrightTests.cs`, following the fixture and assertion patterns in `NoticeJourneyTests.cs`. Use synthetic unique data, semantic locators, and condition-based assertions. Include a negative or boundary assertion only if the observation or requirement supports it. Give the exact focused test command. Do not claim the test passed until it has been run.

Observation and evidence:
[paste your Lab 07 observation; remove any sensitive data]
```
See the [Lab 08 prompt review card](../resources/PROMPT-REVIEW-CARDS.md#lab-08-test-generation).

## Expected observations

Tests can fail because of the app, the test, data, environment, or ambiguity. A failing assertion is evidence about the observed execution, not proof that the product is wrong. The fixture starts the app and temporary database; the separately running Lab 07 app is not required for this test.

## Validation checkpoint

Complete [Checkpoint LAB-08](../checkpoints/lab-08.md). The focused test is discovered and executed; if it fails, classify and preserve the artifacts instead of hiding the result.

## Discussion questions

- Does the assertion test user-visible behaviour?
- What source supports the expected result?
- Was a CSS locator necessary, and why?
- Which classification fits the result?

## Troubleshooting

For a compile error, compare the fixture signatures and restore the exact namespace/usings. For a missing Chromium error, rerun the documented installer. For flaky behavior, inspect the trace and remove arbitrary sleeps; do not increase timeouts without evidence.

## Optional challenge

**Apply:** add one independent test for a different state transition, then ensure its test ID and evidence record are traceable.

## Completion criteria

The test was inspected before execution, focused execution result is captured, and its outcome is classified by a human. No application edit was made without a separate evidence-based decision.

## Next lab

Continue to [Lab 09 — Investigate, review, and record evidence](lab-09-investigate-review-and-record-evidence.md).
