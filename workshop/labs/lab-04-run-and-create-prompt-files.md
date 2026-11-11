# Lab 04 — Run and create prompt files

**Estimated duration:** 12 minutes
**All terminal commands:** run from the repository root unless a task says otherwise.

## Purpose

Run an existing repeatable testing prompt, inspect its design, then create and execute a smaller prompt for one form-validation question.

## Learning objectives

- Identify objective, context, constraints, output format, and validation in a prompt file.
- Invoke a prompt file or use its manual fallback.
- Create a bounded, read-only prompt that distinguishes observation from inference.

## Starting state

Labs 00–03 are complete. If the Lab 03 experiment should not remain, reset it before continuing.

## Files involved

`.github/prompts/05-baseline-existing-tests.prompt.md`, `.github/prompts/06-identify-test-gaps.prompt.md`, new `.github/prompts/lab04-notice-form-validation.prompt.md`, `.github/prompts/` and `tests/`.

## Tasks

1. **Open:** read `05-baseline-existing-tests.prompt.md`. Mark its objective, required context, constraints, output format, validation, and evidence expectations.
2. **Copilot:** invoke `05-baseline-existing-tests` from the prompt picker if supported. Otherwise paste its full contents into Chat. Supply no facilitator-only files.
3. **Copilot — vague comparison:** in a fresh chat, ask only “Help me test the notice form.” Record the response. Then compare it with the structured prompt's output using the [scorecard](../resources/customisation-scorecard.md).
4. **Observe:** critique both outputs for evidence, assumptions, and actual test commands. Run only commands you can verify from the repository. Record actual results.
5. **Edit:** create `.github/prompts/lab04-notice-form-validation.prompt.md` with the following complete prompt:

   ```markdown
   ---
   name: Notice form validation investigation
   description: Investigate one notice form validation behaviour without changing application code.
   ---

   Investigate one validation behaviour in the Legacy Notice Manager notice form.

   Constraints:
   - Do not modify application code, tests, requirements, or evidence files.
   - Use participant-facing documentation and the running UI first; inspect source only if the observation cannot answer the question.
   - Keep direct observation separate from inference and policy assumptions.
   - Do not use real or confidential data.

   Produce:
   1. Scope and files or UI areas inspected.
   2. Reproducible action and synthetic input.
   3. Observed result and its evidence.
   4. One negative case and one boundary case to consider.
   5. Candidate manual and automated tests, with the appropriate level and rationale.
   6. Unresolved policy or product questions.
   7. A concise evidence-ready summary and validation not performed.
   ```

6. **Copilot:** execute the new prompt using one form question from your Lab 01 observations. If prompt-file selection is unavailable, paste the prompt body. Critique the response; do not ask it to fix the app.
7. **Human decision:** decide whether the prompt is clear, bounded, and repeatable. Keep, revise, or remove only the new lab prompt with `python scripts/reset_workshop.py LAB-04 --confirm`.

## Copyable prompts

The complete reusable prompt is in Task 4. Its constraints and output shape are part of the exercise; do not replace them with a vague request to “test the form”.
See the [Lab 04 prompt review card](../resources/PROMPT-REVIEW-CARDS.md#lab-04-prompt-file-comparison).

## Expected observations

A useful prompt makes the task repeatable and reviewable without dictating the model's exact wording. It cannot supply missing policy knowledge.

## Validation checkpoint

Complete [Checkpoint LAB-04](../checkpoints/lab-04.md). Check that the file exists, has a useful task description, prohibits application edits, and includes observation, negative/boundary cases, questions, and validation.

## Discussion questions

- Which prompt section most improved reviewability?
- Was Copilot's boundary case grounded or invented?
- What should be supplied as context rather than copied into every prompt?

## Troubleshooting

If prompt frontmatter is not recognized, use the manual paste fallback. If the response invents policy, ask it to label the statement as an assumption and name evidence needed.

## Optional challenge

**Apply:** create a second prompt for audit-history review with read-only scope and an explicit human-review output.

## Completion criteria

An existing prompt was run or manually supplied, the new prompt was executed on one bounded question, and the output was critiqued.

## Next lab

Continue to [Lab 05 — Work with specialist agents](lab-05-work-with-specialist-agents.md).
