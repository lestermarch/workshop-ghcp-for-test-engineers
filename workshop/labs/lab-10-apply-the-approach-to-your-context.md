# Lab 10 — Apply the approach to your context

**Estimated duration:** 12 minutes
**All terminal commands:** run from the repository root unless a task says otherwise.

## Purpose

Transfer one small, safe testing activity to a participant's own environment without sharing confidential material.

## Learning objectives

- Select a bounded functional slice and state what evidence is available.
- Choose an appropriate Copilot customisation and human reviewer.
- Identify data, security, and policy constraints before a proof of concept.
- Define success and stop conditions before starting.

## Starting state

Labs 00–09 are complete, or a facilitator has summarised the primary learning. Use the blank [adoption plan](../resources/adoption-plan.md).

## Files involved

[Adoption plan](../resources/adoption-plan.md), [customisation scorecard](../resources/customisation-scorecard.md), `GOVERNANCE.md`, `SECURITY.md`, and your organisation's approved Copilot policies.

## Tasks

1. **Choose:** identify an application type and a narrow functional slice without naming a customer, system, or confidential project.
2. **Record:** complete the adoption plan with existing documentation/test levels, risks, suitable Copilot activity, evidence, human reviewers, data controls, success measures, and stop conditions.
3. **Copilot — planning prompt:** provide only non-sensitive information from the adoption plan.
4. **Observe:** compare Copilot's suggested scope with the plan. Remove assumptions and identify approval gaps.
5. **Human decision:** decide whether the idea is suitable for a real proof of concept, needs policy/security review, or should stop.

## Copyable prompts

```text
Help me shape a small, safe proof-of-concept plan for using GitHub Copilot in a testing activity. I will provide only non-confidential, approved summary information; do not ask me to paste source code, customer records, credentials, or personal data. Do not recommend bypassing organisation policy.

Return: candidate narrow slice; current evidence and gaps; suitable Copilot mechanism; success measures; human reviewers; data/security checks; stop conditions; and a first reversible activity. Mark every assumption. Do not claim a tool or IDE feature is available until verified.

My approved summary:
[paste only non-sensitive information]
```
See the [Lab 10 prompt review card](../resources/PROMPT-REVIEW-CARDS.md#lab-10-adoption-plan).

## Expected observations

A useful adoption idea is bounded, measurable, reversible, and reviewed by named humans. Copilot should not receive more data than the approved environment permits.

## Validation checkpoint

Complete [Checkpoint LAB-10](../checkpoints/lab-10.md). A peer can identify the narrow slice, success measure, human owner, and stop condition without seeing confidential information.

## Discussion questions

- Which testing activity has evidence available and an appropriate reviewer?
- What would make you stop the experiment?
- How will you distinguish time saved from increased review or correction effort?

## Troubleshooting

If a proposal depends on confidential input, replace it with a synthetic summary or stop. If policy or feature availability is unknown, record the owner to consult rather than assuming approval.

## Optional challenge

**Extend:** apply the scorecard to the proposed prompt, agent, or skill and set a baseline for review effort.

## Completion criteria

The adoption plan has a bounded slice, evidence, human owner, data controls, success criteria, and stop conditions.

## Next lab

Workshop complete. Use the [facilitator close and feedback questions](../facilitator/FEEDBACK.md) or revisit any checkpoint.
