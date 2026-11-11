# Lab 02 — Understand Copilot customisation

**Estimated duration:** 10 minutes
**All terminal commands:** run from the repository root unless a task says otherwise.

## Purpose

Locate the repository's existing customisations and choose the mechanism that best matches a testing need.

## Learning objectives

- Distinguish instructions, prompt files, custom agents, skills, `AGENTS.md`, and tools.
- Identify scope and portability limitations from concrete repository files.
- Explain the difference between persistent context and a repeatable task.

## Starting state

Lab 01 is complete. Use the same IDE and Copilot surface recorded in Lab 00.

## Files involved

`.github/copilot-instructions.md`, `.github/instructions/`, `AGENTS.md`, `.github/prompts/`, `.github/agents/`, `.github/skills/`, `.github/workflows/`, and [the customisation guide](../../COPILOT-CUSTOMISATION-GUIDE.md).

## Tasks

1. **Open:** inspect one concrete example of each mechanism. Use `01-map-the-application.prompt.md`, `exploratory-tester.agent.md`, `exploratory-browser-testing/SKILL.md`, and `ui-tests.instructions.md`.
2. **Observe:** note the frontmatter, applicable path, purpose, output format, tools, exclusions, and validation rules. Check root `AGENTS.md` separately from `.github/copilot-instructions.md`.
3. **Copilot — mapping prompt:**

   ```text
   I am learning this repository's Copilot customisations. Using only these files: `.github/copilot-instructions.md`, `.github/instructions/ui-tests.instructions.md`, `AGENTS.md`, `.github/prompts/05-baseline-existing-tests.prompt.md`, `.github/agents/test-gap-analyst.agent.md`, and `.github/skills/test-gap-analysis/SKILL.md`, explain the distinct purpose and scope of each. Cite file paths. Do not claim a feature is supported by my IDE unless I verified it. Do not edit files.

   Then recommend the smallest suitable mechanism for each requirement below and explain why:
   - a persistent convention for all C# tests;
   - a repeatable test-gap analysis task;
   - a specialist persona with exclusions;
   - a reusable multi-step process that includes references;
   - closer guidance for one directory.
   Leave the matching exercise unresolved for me; do not reveal facilitator answers.
   ```

4. **Participant activity:** complete the [mechanism map](../resources/mechanism-map.md) using the files you opened, then compare your explanation with Copilot's.
5. **Human decision:** confirm each mechanism with the file content. Record uncertain IDE support as a question, not as a fact.

## Copyable prompts

Use the full mapping prompt in Task 3. It is read-only and constrains Copilot to named repository examples.
See the [Lab 02 prompt review card](../resources/PROMPT-REVIEW-CARDS.md#lab-02-customisation-map).

## Expected observations

Instructions provide persistent context within a scope; prompts package a repeatable task; agents define a role and operating boundaries; skills provide reusable task knowledge; tools/MCP provide capabilities rather than policy. `AGENTS.md` discovery and feature availability depend on the host.

## Validation checkpoint

Complete [Checkpoint LAB-02](../checkpoints/lab-02.md). Explain one example in your own words and name one portability limitation.

## Discussion questions

- Which file would you change if a rule should apply to every test?
- When might an agent be the wrong mechanism?
- Does a tool alias in a Markdown file prove the tool is installed?

## Troubleshooting

If a prompt or skill is not listed by the IDE, open the file and use its body manually. If Copilot gives a generic answer, narrow the context to the named files and ask for evidence.

## Optional challenge

**Apply:** choose one mechanism for an accessibility review and sketch its scope, exclusions, output, and validation without creating it yet.

## Completion criteria

The mapping exercise is complete, cited to real files, and includes a host-specific limitation.

## Next lab

Continue to [Lab 03 — Shape Copilot with instructions](lab-03-shape-copilot-with-instructions.md).
