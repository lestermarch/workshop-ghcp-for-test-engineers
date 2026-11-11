# Lab 06 — Discover and install a skill

**Estimated duration:** 15 minutes
**All terminal commands:** run from the repository root unless a task says otherwise.

## Purpose

Practise discovering a community Copilot customisation without treating public availability as trust. Inspect it, adapt it to local conventions, use it on a bounded task, and decide whether to retain it.

## Learning objectives

- Search a reusable customisation library without depending on one asset being permanent.
- Review instructions, scripts, dependencies, licence, and permissions before installation.
- Install and adapt one skill into the repository.
- Use a locally bundled fallback when the network or external candidate is unsuitable.

## Starting state

Labs 00–05 are complete. Have access to the [external asset review form](../resources/external-asset-review.md). No external download is required for the fallback.

## Files involved

External source: [github/awesome-copilot skills](https://github.com/github/awesome-copilot/tree/main/skills/). The [external source record](../resources/EXTERNAL-SOURCE-RECORD.md) gives a current discovery candidate and checked date. Local fallback: `.github/skills/playwright-failure-investigation/SKILL.md`. Installation target: `.github/skills/workshop-installed-skill/SKILL.md`.

## Tasks

1. **Browser — discover:** open the Awesome Copilot repository and browse its current `skills` directory. Search for testing, web testing, accessibility, or debugging. A web search observed a `webapp-testing` skill path on 2026-11-03; it is a candidate to re-check, not a workshop dependency. If it moved or disappeared, choose another relevant candidate.
2. **Inspect before installation:** open the full skill and every referenced script, tool, or package. Complete the [external asset review form](../resources/external-asset-review.md), including source commit/retrieval date, licence, network and file access, and any destructive instruction. Do not execute downloaded scripts or package installers.
3. **Before adaptation:** after completing the safety review, run the same bounded task with the candidate skill content as written, without executing scripts or granting tools. Save the response locally.
4. **Human decision:** select **retain/adapt**, **reject**, or **local fallback**. If the licence is unclear or the content requests broad permissions, reject it. Do not paste unreviewed external instructions into Copilot.
5. **Install:** if retained, prefer a standalone reviewed `SKILL.md` and copy it to `.github/skills/workshop-installed-skill/`. Do not copy or execute scripts. If the skill needs scripts, broad permissions, or unreviewed references, reject it or use the local fallback. Record which route was used; do not claim the local fallback is a third-party asset.
6. **Edit:** adapt the copied skill's `name` to `workshop-installed-skill`, ensure it has a concise `description`, and add local evidence and no-production-edit constraints. Preserve attribution and licence information for any external material. Do not copy unreviewed scripts.
7. **Copilot — after adaptation:** repeat the same bounded task with the adapted skill. Compare before/after using the scorecard. If skill selection is unavailable, paste the adapted file into Chat and mark both runs as manual-context comparisons.
8. **Observe and decide:** review the output and record whether to retain, revise, or remove the skill. Reset the exercise copy with `python scripts/reset_workshop.py LAB-06 --confirm`.

## Copyable prompts

Use this bounded task after installation:

```text
Using the reviewed testing skill and the observation I provide, suggest the next smallest investigation step. Use synthetic data only. Do not execute scripts, access the network, edit application code, or assert policy. Separate observed facts, hypotheses, and unresolved questions. State which evidence would change your conclusion and what a human reviewer should decide.
```
See the [Lab 06 prompt review card](../resources/PROMPT-REVIEW-CARDS.md#lab-06-skill-adaptation).

## Expected observations

Community skills can vary in format, licence, tool assumptions, and scope. The lab works if the selected asset is rejected and the local fallback is used. Installing a skill is not evidence that its instructions are safe or correct.

## Validation checkpoint

Complete [Checkpoint LAB-06](../checkpoints/lab-06.md). The review form must be complete before the skill is copied, and the installed copy must match the target folder name and local constraints.

## Discussion questions

- What instruction or script would have changed your decision?
- How did you establish the licence and provenance?
- What should you do when an external skill's author or update history is unclear?

## Troubleshooting

If GitHub is unavailable, use the bundled local skill fallback. If the skill picker is missing, paste the local reviewed copy into Chat. If metadata fails validation, keep the external source outside `.github/skills` until corrected.

## Optional challenge

**Apply:** review a different candidate, such as an accessibility or code-review skill, and compare its permissions with the first choice.

## Completion criteria

One reviewed skill was installed and adapted, or explicitly rejected in favour of the bundled fallback; the provenance and human decision are recorded.

## Next lab

Continue to [Lab 07 — Explore the application in a browser](lab-07-explore-the-application-in-a-browser.md).
