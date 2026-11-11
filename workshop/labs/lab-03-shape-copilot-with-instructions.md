# Lab 03 — Shape Copilot with instructions

**Estimated duration:** 12 minutes
**All terminal commands:** run from the repository root unless a task says otherwise.

## Purpose

Run a qualitative before-and-after experiment that shows how a path-specific repository instruction can change a testing response.

## Learning objectives

- Inspect the instruction scope that applies to browser tests.
- Run the same task before and after adding a scoped instruction.
- Compare relevance, grounding, assumptions, safety, and review effort without requiring identical wording.
- Revert or deliberately retain an experiment.

## Starting state

Lab 02 is complete. The repository has an existing UI-test instruction. Use the same Copilot surface and same prompt for both runs.

## Files involved

`.github/instructions/ui-tests.instructions.md`, new `.github/instructions/lab03-experiment.instructions.md`, `.github/agents/playwright-test-engineer.agent.md`, and [the scorecard](../resources/customisation-scorecard.md).

## Tasks

1. **Open:** read `ui-tests.instructions.md` and note its `applyTo` scope and current rules.
2. **Copilot — baseline prompt:** run this in Chat before creating the experiment file. Save the response in `workshop/participant-work/lab-03-before.md` (the folder is local and ignored).

   ```text
   Review the existing Playwright test suite and propose one additional test for the notice workflow. Do not edit any files or inspect facilitator-only material. Give a candidate test name, the user-visible behaviour, expected result and evidence source, likely locator strategy, and any uncertainty. If a requirement is not known, say so rather than inventing one.
   ```

3. **Edit:** create `.github/instructions/lab03-experiment.instructions.md` with the following content:

   ```markdown
   ---
   applyTo: "tests/EndToEnd/**/*.cs"
   ---
   # Workshop browser-test experiment

   When proposing browser tests, separate observed behaviour from expected behaviour and cite a requirement or label the expectation unresolved. Prefer accessible roles and labels; explain any non-semantic locator. Do not edit application code during test discovery.
   ```

4. **Copilot — after prompt:** run the exact same prompt and save the response as `workshop/participant-work/lab-03-after.md`. If the IDE does not apply the new file automatically, state that limitation and paste its content as explicit context; mark the result as a manual-context comparison.
5. **Observe:** compare the two responses with the [scorecard](../resources/customisation-scorecard.md). Do not judge success by identical or more detailed wording alone.
6. **Human decision:** inspect whether the changed guidance is relevant and safe. Retain the new instruction only if the team wants this policy. Otherwise use `python scripts/reset_workshop.py LAB-03 --confirm` to back up and remove only the experiment file.

## Copyable prompts

Use the same full prompt in Task 2 for both runs. Do not add extra direction between runs; if context changed, note it on the scorecard.
See the [Lab 03 prompt review card](../resources/PROMPT-REVIEW-CARDS.md#lab-03-instruction-experiment).

## Expected observations

The instruction may improve evidence and locator reasoning on supported surfaces. Results can vary between model responses. A manual paste is useful but does not prove automatic instruction discovery.

## Validation checkpoint

Complete [Checkpoint LAB-03](../checkpoints/lab-03.md). Confirm `applyTo` targets the intended test path, the file is in the repository instruction directory, and your decision is recorded.

## Discussion questions

- Did the response change in a way that mattered to test quality?
- Was a difference caused by the instruction or by another context change?
- What should remain a human decision?

## Troubleshooting

If the after response looks unchanged, verify the target file path and `applyTo`, then restart the chat or use a manual-context comparison. Do not claim the IDE consumed the instruction without evidence.

## Optional challenge

**Extend:** create a path-specific instruction for evidence records requiring exact commands, test outcomes, and a human decision.

## Completion criteria

Both responses or the host limitation are recorded; the scorecard includes evidence and a retain/revise/revert decision.

## Next lab

Continue to [Lab 04 — Run and create prompt files](lab-04-run-and-create-prompt-files.md).
