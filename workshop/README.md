# GitHub Copilot for testing: guided workshop

**Audience:** software testers, test-automation engineers, quality engineers, developers, and test leads  
**Core facilitated route:** approximately 2 hours 52 minutes, including a 10-minute break  
**Condensed demonstration:** 45–60 minutes  
**Self-paced route:** complete the labs in order and use the checkpoints and recovery notes

## Scenario

You are part of a testing team asked to assess an unfamiliar legacy application. Documentation and automated coverage are incomplete. Your team is evaluating whether GitHub Copilot can help you understand the application, recover candidate requirements, identify test gaps, create useful tests, investigate failures, and produce reviewable evidence.

The sample is the synthetic **Legacy Notice Manager**. Copilot assists the testers; it does not replace testing expertise, product knowledge, security review, accessibility assessment, or subject-matter-expert confirmation. No customer data, secrets, cloud subscription, or production system is needed.

## Learning outcomes

By the end, participants can explain repository context; distinguish instructions, prompts, agents, skills, and tools; run and adapt reusable customisations; explore the UI before reading its implementation; create and run a focused Playwright test; investigate browser evidence; make a human review decision; and record assumptions, evidence, and traceability.

## Choose a route

| Route | Use | Sequence |
|---|---|---|
| Facilitated | Small team with a facilitator; use the timed agenda in [the facilitator pack](facilitator/README.md). | Labs 00–10, with the break after Lab 05. |
| Condensed | Facilitator-led 45–60-minute demonstration. | Lab 00; the guided slice of Labs 01–05; Labs 07–09; close. Defer the full skill installation and customer-transfer exercises. |
| Self-paced | Revisit after the session or complete without a facilitator. | Labs 00–10 in sequence; pause at each checkpoint and record progress. |

Labs are modular. A facilitator can omit optional challenges without blocking the primary path.

For a presenter-led introduction, use the [seven-minute concept refresher outline and run instructions](presentation/presentation.md) and its [presentation source](presentation/index.html). The slide deck uses online assets; the outline is an offline fallback.

## Navigation

1. [Setup and validation](setup/README.md)
2. [Lab 00 — Setup and validation](labs/lab-00-setup-and-validation.md)
3. [Lab 01 — Meet the legacy application](labs/lab-01-meet-the-legacy-application.md)
4. [Lab 02 — Understand Copilot customisation](labs/lab-02-understand-copilot-customisation.md)
5. [Lab 03 — Shape Copilot with instructions](labs/lab-03-shape-copilot-with-instructions.md)
6. [Lab 04 — Run and create prompt files](labs/lab-04-run-and-create-prompt-files.md)
7. [Lab 05 — Work with specialist agents](labs/lab-05-work-with-specialist-agents.md)
8. [Lab 06 — Discover and install a skill](labs/lab-06-discover-and-install-a-skill.md)
9. [Lab 07 — Explore the application in a browser](labs/lab-07-explore-the-application-in-a-browser.md)
10. [Lab 08 — Create and run Playwright tests](labs/lab-08-create-and-run-playwright-tests.md)
11. [Lab 09 — Investigate, review, and record evidence](labs/lab-09-investigate-review-and-record-evidence.md)
12. [Lab 10 — Apply the approach to your context](labs/lab-10-apply-the-approach-to-your-context.md)

Use the [observation worksheet](resources/observation-worksheet.md), [customisation scorecard](resources/customisation-scorecard.md), [external asset review](resources/external-asset-review.md), and [adoption plan](resources/adoption-plan.md). From the repository root, use `python` in PowerShell or `python3` in Bash:

```shell
python scripts/workshop_progress.py show
python scripts/workshop_progress.py complete LAB-00
```

In Bash, replace `python` with `python3`. The status shows completed labs, optional challenges, the current checkpoint, and remaining labs.

## Safety and ownership

- Use only the synthetic application and synthetic inputs in this checkout.
- Follow your organisation's Copilot, data-handling, and approved-service policies. Do not paste confidential code or information into an unapproved service.
- Inspect community skills and agents before use. They are instructions and may include executable scripts or tool references.
- Treat generated tests and findings as drafts. A passing test does not prove that the expected behaviour is correct.
- Do not automatically change application code after a browser-test failure. Classify the failure and obtain a human decision first.
- Browser traces, screenshots, and reports can contain entered values. Review them before sharing and keep them local unless approved.
- AI-generated accessibility and security observations require human validation by an appropriate reviewer.
- Check how prompts, source context, code, and telemetry are processed by the selected Copilot service, and follow your organisation's retention and data-handling rules.

See [environment differences and fallbacks](setup/ENVIRONMENT.md), [troubleshooting](troubleshooting/README.md), and [reset and recovery](reset/README.md). Facilitator answers are in the separate `workshop/facilitator/` area and `reference-outcomes/`; do not open them during participant exploration.
