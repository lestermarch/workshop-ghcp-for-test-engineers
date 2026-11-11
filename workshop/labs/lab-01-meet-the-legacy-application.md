# Lab 01 — Meet the legacy application

**Estimated duration:** 10 minutes
**All terminal commands:** run from the repository root unless a task says otherwise.

## Purpose

Build a first impression from the running app and partial documentation before asking a specialist agent or inspecting the facilitator answer key.

## Learning objectives

- Complete the primary notice journey as a user.
- Record observable behaviour separately from expectations and guesses.
- Compare initial test expectations with the actual baseline suite.

## Starting state

Lab 00 is complete. Start the app using the disposable database path recorded there, or use an existing local app URL supplied by the facilitator.

## Files involved

`README.md`, `docs/baseline/OVERVIEW.md`, `docs/baseline/BUSINESS-RULES.md`, `tests/Unit/NoticeBaselineTests.cs`, `tests/Integration/NoticePagesTests.cs`, `tests/EndToEnd/NoticeJourneyTests.cs`, and [the observation worksheet](../resources/observation-worksheet.md).

## Tasks

1. **Browser:** follow a notice from the register to details. Open the create form, try an incomplete submission, then complete enough fields to continue. Try editing, approval or rejection, and export where available. Do not use any facilitator answer file.
2. **Observe:** use synthetic values only. Record each action and the result in a copy of the [observation worksheet](../resources/observation-worksheet.md). Do not label an unexpected result a defect until you have a requirement source.
3. **Open:** read the three listed baseline documents and note what remains unclear.
4. **Terminal — repository root:**

   ```shell
   dotnet test tests/Unit --collect:"XPlat Code Coverage"
   dotnet test tests/Integration --collect:"XPlat Code Coverage"
   dotnet test tests/EndToEnd
   ```

   **Observe:** list what each suite exercises and locate the generated `coverage.cobertura.xml` files under each test project's `TestResults` folder. Coverage indicates executed code, not requirement coverage or test quality. Record actual results.
5. **Copilot — prompt:** use the following in a fresh Chat. Do not select a specialist agent yet.

   ```text
   You are helping a testing team assess an unfamiliar synthetic notice-management application. Use only the running UI observations and the participant-facing baseline documents I provide. Do not inspect source code or facilitator-only files, and do not edit anything.

   Summarise what I observed, separating direct observations from expectations and inference. List the important user journeys, unclear behaviours, risks, missing documentation, and tests I would expect to exist. For every expectation, name its evidence source or mark it unknown. End with three questions for a product or subject-matter expert.

   Keep the output concise and do not reveal or infer a seeded issue list.
   ```

6. **Human decision:** compare the Copilot summary to the worksheet. Correct unsupported assumptions and retain at least one unanswered question.

## Copyable prompts

The prompt in Task 5 is complete and read-only. Supply only your own observations and the three participant-facing baseline documents as context. Do not attach `reference-outcomes/` or `workshop/hints/`.
See the [Lab 01 prompt review card](../resources/PROMPT-REVIEW-CARDS.md#lab-01-first-impression).

## Expected observations

The UI, incomplete business-rule note, and current tests provide different amounts of information. Some behaviour may be observable without being justified by an approved requirement. The test suites cover a small baseline, not every user journey.

## Validation checkpoint

Complete [Checkpoint LAB-01](../checkpoints/lab-01.md). Check that at least one claim is labelled observed, one is labelled inferred or uncertain, and one question is still open.

## Discussion questions

- What did the UI show that the documents did not?
- Which journey did you assume was protected by tests but could not find?
- Which result would need a policy owner before you wrote an assertion?

## Troubleshooting

If the app will not start, use the Lab 00 readiness output. If a form cannot be completed, record the exact state and ask the facilitator; do not read the answer key to unblock yourself.

## Optional challenge

**Explore:** write a five-step exploratory charter for one page, including preconditions, synthetic inputs, stop conditions, and evidence to retain.

## Completion criteria

The observation worksheet contains a reproducible journey, an explicit expectation source (or “unknown”), and a comparison with actual baseline test suites.

## Next lab

Continue to [Lab 02 — Understand Copilot customisation](lab-02-understand-copilot-customisation.md).
