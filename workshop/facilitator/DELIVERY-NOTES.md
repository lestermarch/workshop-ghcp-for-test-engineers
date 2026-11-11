# Delivery notes

## Before the session

- Confirm the selected host, account entitlement, organisation policy, and whether prompt files, custom agents, skills, agent mode, and MCP browser tools are actually available.
- Run `python scripts/workshop_ready.py --deep`, install Chromium if needed, and run `python scripts/check_workshop.py`.
- Confirm local app startup, the Playwright fixture, HTML report generation, and reset script in the primary delivery environment.
- Provide each participant a clean checkout and a local-only folder for observation/progress. Do not use customer source or secrets.
- Keep `workshop/facilitator/`, `workshop/hints/`, and `reference-outcomes/` out of screen share and participant instructions until appropriate.
- Prepare an offline copy of the bundled skill fallback, but do not vendor any external skill.

## Room and environment checklist

- Participants can read the repository and run a terminal.
- A GitHub Copilot-enabled surface is available or manual prompt paste is acceptable.
- .NET 10, Python 3, Git, and Playwright Chromium are ready in the agreed environment.
- Browser MCP is optional; the .NET Playwright runner and manual UI route are the fallback.
- Application and test data are synthetic and local.
- Participants know how to capture questions without pasting sensitive content.

## Facilitation stance

Ask for an observation, an expectation source, and confidence before discussing a fix. Copilot output is a draft. Do not reward volume of tests or acceptance of the first recommendation. Encourage participants to identify tool unavailability honestly and use the documented fallback.

## Demonstration checkpoints

- At Lab 00, readiness distinguishes automated checks from host-dependent Copilot features.
- At Lab 01, participants have an observation before source context.
- At Lab 03, the same prompt and similar context are compared before/after the new instruction.
- At Lab 05, the agent has an actual responsibility/output change.
- At Lab 06, the external asset is inspected before installation; a rejected candidate is a valid outcome.
- At Labs 07–09, the browser observation precedes code review, the test is inspected before running, and a human classifies the result.
- At Lab 10, no confidential code or data is submitted.

## Likely participant errors

- Reading facilitator answers early: pause, redirect to the UI, and ask them to label what they already saw as known or unknown.
- Treating a code path as approved business policy: ask for an authoritative owner/source.
- Treating prompt/agent/skill support as universal: ask them to record the host and use a manual fallback.
- Copying external skill content before review: stop the copy; complete the review form or use the local fallback.
- Asking Copilot to fix a failing test immediately: capture output/artifact, classify the cause, and obtain a human decision.
- Using a fragile locator or arbitrary wait: inspect accessibility snapshot and test instruction; ask for a resilient alternative.
- Spending too long on install or generated-code errors: switch to the prepared environment, skip optional work, and preserve the checkpoint.

## Likely Copilot variations

Responses will vary in ordering, detail, and hypotheses. Accept different output when it is grounded, scoped, testable, and explicit about uncertainty. Challenge unsupported expected results, broad refactors, security/accessibility claims without review, and unverified tool use.

## Fallbacks and extensions

- No browser MCP: participant drives a normal browser and records the action/result.
- No skill source network: copy the local `playwright-failure-investigation` skill to the workshop target and adapt it.
- No prompt/agent picker: paste the corresponding file into Chat.
- No Chromium: complete manual exploration and discuss the test proposal; mark E2E as not run.
- More time: use the three-level [challenge catalogue](../challenges/CATALOGUE.md), create another state-transition test, or compare a second agent.

## Recommended UKHO session

Use the 172-minute facilitated route. For a first customer session, allocate the full time, provide a prepared local environment, and reserve enough discussion time for policy and governance questions. Do not attempt to validate the synthetic notice rules as real maritime policy.

## Best 10-minute demonstration path

1. Spend 2 minutes opening the synthetic register and describing one observed action.
2. Spend 2 minutes asking Exploratory Tester to explore without source access (or demonstrate manual exploration if tools are absent).
3. Spend 3 minutes converting the observation into a focused Playwright test and running it headlessly.
4. Spend 2 minutes opening the screenshot/trace/report or describing the missing artifact honestly.
5. Spend 1 minute asking the audience to classify the result and name the human decision required.

## Best participant-led exercise

Lab 07 → Lab 08 → Lab 09 is the strongest sequence: participants choose a journey, form an observation, generate and run a test, inspect evidence, classify the result, and record a decision. Do not preselect the finding for them.
