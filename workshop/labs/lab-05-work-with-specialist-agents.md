# Lab 05 — Work with specialist agents

**Estimated duration:** 15 minutes
**All terminal commands:** run from the repository root unless a task says otherwise.

## Purpose

Use an existing specialist agent, inspect its boundaries, and make a meaningful agent adaptation rather than a name-only edit.

## Learning objectives

- Select an agent whose purpose matches a testing task.
- Identify responsibilities, exclusions, inputs, outputs, tools, and escalation rules.
- Adapt a copy of an agent to a specific testing role and validate its behaviour.

## Starting state

Labs 00–04 are complete. A Copilot surface that supports custom agents is helpful but not required; manual paste is an accepted fallback.

## Files involved

`.github/agents/test-gap-analyst.agent.md`, `.github/agents/legacy-application-archaeologist.agent.md`, new `.github/agents/boundary-value-analyst.agent.md`, `.github/skills/test-gap-analysis/SKILL.md`, and the customisation scorecard.

## Tasks

1. **Open:** inspect `test-gap-analyst.agent.md`. Identify its purpose, input, output, tool list, exclusions, and validation. Compare one responsibility with its related skill.
2. **Copilot — general Chat:** run the bounded prompt below in a fresh general Chat and save the response in `workshop/participant-work/lab-05-general.md`.
3. **Copilot — specialist:** select **Test-Gap Analyst** (or paste the agent definition into Chat) and run that exact prompt with the same observations and requirements. Save the response in `workshop/participant-work/lab-05-specialist.md`.
4. **Observe:** compare both responses with the scorecard. Record whether the specialist scope improved evidence, relevance, or test depth, and where either response made an assumption.
5. **Edit:** copy `test-gap-analyst.agent.md` to `.github/agents/boundary-value-analyst.agent.md`. Change its display name and description, then alter its actual behaviour to:
   - take one form field or state transition as input;
   - produce a boundary-value table with partition, representative synthetic input, expected observation source, and uncertainty;
   - include negative cases and a test-level recommendation;
   - prohibit application edits and require SME escalation for policy ambiguity.
   Preserve only tools the host supports. Do not copy a tool alias into the new agent unless it is configured.
6. **Copilot — modified specialist:** invoke **Boundary Value Analyst** with one form field from the observed app, or paste the adapted agent definition into Chat. Run the same prompt again. Assess whether the meaningful agent change improved the matrix and respected the no-edit boundary.
7. **Human decision:** use the scorecard to keep, revise, or remove the new agent. Reset only the new copy with `python scripts/reset_workshop.py LAB-05 --confirm`.

## Copyable prompts

Use this exact bounded task with general Chat, the original specialist, and the adapted specialist. Keep observation context constant:

```text
Analyse the validation boundaries for one notice form field: [enter the field observed in the UI]. Use synthetic examples only. Start from the observations and participant-facing documentation supplied. Do not modify files or assert a business rule without evidence. Produce representative valid, invalid, and boundary inputs; the expected observation source; a manual test idea; an automated test level; and unresolved questions for a human reviewer.
```

Replace the bracketed field with a real field label from the running UI. Do not include production data.
See the [Lab 05 prompt review card](../resources/PROMPT-REVIEW-CARDS.md#lab-05-specialist-agent-comparison).

## Expected observations

The original agent prioritises gaps; the adapted agent focuses on a boundary matrix. An agent definition can shape behaviour but does not guarantee tool availability or accurate policy.

## Validation checkpoint

Complete [Checkpoint LAB-05](../checkpoints/lab-05.md). The adapted agent must change its responsibilities/output, include exclusions and escalation, and produce a human-reviewable result.

## Discussion questions

- Which output should be handled by a skill rather than a persona?
- What would make this agent unsafe to select automatically?
- Which instructions should be present in both the agent and repository guidance?

## Troubleshooting

If the picker does not show the agent, restart the supported chat surface or paste the file manually. If it claims a tool it cannot use, remove or reconfigure that tool rather than accepting a fabricated result.

## Optional challenge

**Extend:** create a Test Evidence Reviewer with input fields, output sections, exclusions, and a rule to flag unverified claims rather than editing evidence.

## Completion criteria

An existing agent was inspected and used or manually supplied; a copied agent has a meaningful scope/output change and was assessed on a bounded task.

## Next lab

Continue to [Lab 06 — Discover and install a skill](lab-06-discover-and-install-a-skill.md).
