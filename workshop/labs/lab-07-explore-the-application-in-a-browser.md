# Lab 07 — Explore the application in a browser

**Estimated duration:** 15 minutes
**All terminal commands:** run from the repository root unless a task says otherwise.

## Purpose

Use the running interface as a black box. Record a reproducible observation before reading implementation code or asking for a fix.

## Learning objectives

- Use the Exploratory Tester agent and browser tools when available.
- Exercise a synthetic notice journey, including an invalid or boundary input.
- Distinguish observed behaviour, expectation, hypothesis, and ambiguity.
- Identify evidence and decide whether a requirement or SME is needed.

## Starting state

Lab 00's app is running and accessible at the URL printed by ASP.NET Core. Keep the temporary synthetic database isolated. Do not read facilitator-only outcomes.

## Files involved

`.github/agents/exploratory-tester.agent.md`, `.github/prompts/explore-application-in-browser.prompt.md`, `.github/prompts/explore-form-boundaries.prompt.md`, `evidence/templates/BROWSER-OBSERVATION-TEMPLATE.md`, and [the observation worksheet](../resources/observation-worksheet.md).

## Tasks

1. **Copilot — agent:** select **Exploratory Tester** if available. Supply the running app URL and the prompt below. If browser tools are unavailable, open the app yourself and provide your actions/results to Chat.
2. **Browser — explore:** follow the list → details → create → validation → edit → approval/rejection path. Use synthetic input. Try one invalid or boundary input. Observe keyboard navigation and visible validation feedback. Do not inspect source code yet.
3. **Observe:** ask the agent to repeat one action or repeat it manually in a fresh page. Capture a screenshot only if permitted; use local Playwright artifacts if you need a saved screenshot/trace.
4. **Record:** complete `evidence/templates/BROWSER-OBSERVATION-TEMPLATE.md` or the [worksheet](../resources/observation-worksheet.md). State what you observed, what you expected (with source if known), and what remains uncertain.
5. **Human decision:** classify the finding using the exact classification vocabulary in the observation template. Decide whether it is reproducible and whether an expected result is supported.

## Copyable prompts

```text
Explore the running Legacy Notice Manager as an experienced tester. Start from the rendered application and do not inspect implementation code yet. Exercise the notice-management journey, try one invalid and one boundary input, and find one behaviour worth investigating. Record each action, synthetic input, exact observed result, and any expected result only when its source is known. Identify what remains ambiguous. Do not modify code or tests, do not reveal facilitator answers, and do not treat an unexpected result as a confirmed defect. If you cannot operate the browser, say so and give me manual steps instead of claiming you explored it.
```

For a narrower pass, invoke `explore-form-boundaries.prompt.md` and supply the field or state you actually observed. Do not ask the model to invent an expected result.
See the [Lab 07 prompt review card](../resources/PROMPT-REVIEW-CARDS.md#lab-07-browser-exploration).

## Expected observations

The browser can show what happened, not whether policy is correct. A repeatable UI observation is stronger than a guess, but may still need product documentation or SME confirmation. If the IDE cannot use browser tools, manual exploration is equivalent for this lab.

## Validation checkpoint

Complete [Checkpoint LAB-07](../checkpoints/lab-07.md). The record includes a reproducible action, exact observed outcome, evidence path or manual note, classification, and an unanswered question or evidence-backed expectation.

## Discussion questions

- Which observation is confirmed by the UI and which claim remains an inference?
- What would count as an authoritative source for the expected result?
- Did the agent stay black-box, or did it read source too early?

## Troubleshooting

If the MCP browser cannot navigate, confirm the local URL and host tool configuration. If it remains unavailable, use a regular browser and record actions manually. Do not paste a public or production URL into an unapproved agent.

## Optional challenge

**Explore:** repeat the chosen journey with keyboard-only interaction and record any accessibility concern without claiming conformance.

## Completion criteria

One observation is reproducible or explicitly unresolved, recorded without a speculative code fix, and classified by a human.

## Next lab

Continue to [Lab 08 — Create and run Playwright tests](lab-08-create-and-run-playwright-tests.md).
