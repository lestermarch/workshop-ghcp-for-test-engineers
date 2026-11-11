# Prompt review cards

Use the card that matches the prompt block in a lab. The full copyable prompt remains in the lab so it can be run without extra assembly. A different model response is acceptable if it is grounded, safe, scoped, and reviewable.

<a id="lab-00-capability-check"></a>
## Lab 00 — Capability check

- **Why:** establish actual host support without assuming parity.
- **Context:** current IDE and repository root; no source files are necessary.
- **Expected:** known feature surface, uncertainty, and manual fallback.
- **Weak response:** claims an agent or MCP tool is available without checking.
- **Follow-up:** “Which file or UI evidence supports that? What remains unverified?”
- **Alternative:** manually open the agent and prompt lists and record what the host exposes.

<a id="lab-01-first-impression"></a>
## Lab 01 — First impression

- **Why:** organise participant observations before specialist analysis.
- **Context:** participant-facing docs and the participant's own UI worksheet.
- **Expected:** observed facts separated from expectations, risks, and SME questions.
- **Weak response:** introduces seeded issues or claims code behaviour without source.
- **Follow-up:** “For each expectation, what is the source? Mark unsupported items unknown.”
- **Alternative:** write the journey map without Copilot, then use Copilot only to check omissions.

<a id="lab-02-customisation-map"></a>
## Lab 02 — Customisation map

- **Why:** choose a mechanism by scope and purpose.
- **Context:** only the explicitly named repository files.
- **Expected:** explanation with citations and host caveats.
- **Weak response:** says a skill is a tool or that all IDEs discover the same assets.
- **Follow-up:** “Which file would persist this rule, and how can we verify activation?”
- **Alternative:** complete the mechanism map in pairs without Copilot.

<a id="lab-03-instruction-experiment"></a>
## Lab 03 — Instruction experiment

- **Why:** qualitatively compare one task with and without scoped repository guidance.
- **Context:** same prompt, same relevant test paths, similar Chat state.
- **Expected:** candidate test proposal with evidence and locator reasoning.
- **Weak response:** fabricates exact reproducibility, or treats one response as proof of causation.
- **Follow-up:** “What changed besides the instruction? Would this improvement matter in review?”
- **Alternative:** compare on a different small test-design task while keeping both runs read-only.

<a id="lab-04-prompt-file-comparison"></a>
## Lab 04 — Prompt-file comparison

- **Why:** contrast a vague request with a structured reusable prompt.
- **Context:** the same form question and participant observations for both runs.
- **Expected:** the structured prompt asks for evidence, boundary cases, uncertainty, and validation.
- **Weak response:** treats more text as automatically better or invents policy.
- **Follow-up:** “Which part made the result more reviewable? Which constraint can be removed?”
- **Alternative:** ask a peer to follow the prompt without Copilot and see whether the task remains clear.

<a id="lab-05-specialist-agent-comparison"></a>
## Lab 05 — Specialist-agent comparison

- **Why:** compare general Chat, a specialist agent, and a meaningful adapted agent.
- **Context:** same observation and evidence in all runs; do not include answer-key material.
- **Expected:** difference in relevance, consistency, boundaries, or output shape.
- **Weak response:** assumes the agent has tools it cannot access or claims the specialist is always better.
- **Follow-up:** “Which task was improved by the role? What should remain a shared instruction?”
- **Alternative:** compare a general prompt file with the agent if the IDE has no agent picker.

<a id="lab-06-skill-adaptation"></a>
## Lab 06 — Skill adaptation

- **Why:** test whether reviewed task guidance improves a bounded analysis after local adaptation.
- **Context:** first the reviewed source content, then the same task with the adapted copy.
- **Expected:** focused diagnostic suggestion with local constraints and no tool execution.
- **Weak response:** executes an external script, requests secrets, or claims provenance without review.
- **Follow-up:** “Which instruction changed the result? What permission or dependency remains?”
- **Alternative:** use the bundled `playwright-failure-investigation` skill as the source copy.

<a id="lab-07-browser-exploration"></a>
## Lab 07 — Browser exploration

- **Why:** record user-visible behavior before inspecting implementation.
- **Context:** local synthetic URL, one journey, one invalid/boundary input.
- **Expected:** action/input/result, expected-result source or ambiguity, and repeatability.
- **Weak response:** claims to have used a browser without evidence or jumps directly to a fix.
- **Follow-up:** “Can we reproduce this in a fresh page? What source establishes the expectation?”
- **Alternative:** explore manually and ask Chat to structure only the participant's own notes.

<a id="lab-08-test-generation"></a>
## Lab 08 — Test generation

- **Why:** turn one supported observation into the smallest useful automated check.
- **Context:** observation, evidence, current test fixture patterns, and explicit test-only scope.
- **Expected:** test-level rationale, semantic locator, conditional assertions, command, and uncertainty.
- **Weak response:** changes production code, uses arbitrary sleep, or encodes unsupported policy.
- **Follow-up:** “Which assertion fails if the observed behavior changes? Which requirement supports it?”
- **Alternative:** draft the test manually, then ask Copilot for a review against `ui-tests.instructions.md`.

<a id="lab-09-failure-review"></a>
## Lab 09 — Failure review

- **Why:** classify a result and choose the next evidence-gathering action.
- **Context:** exact command/result, browser artifacts if accessible, and participant-facing requirement.
- **Expected:** facts, hypotheses, cause classification, human decision, and smallest next action.
- **Weak response:** declares product defect solely from a failure or claims to have opened inaccessible traces.
- **Follow-up:** “What would distinguish application, test, data, environment, and policy causes?”
- **Alternative:** use a peer reviewer with the same evidence and compare the reasoning.

<a id="lab-10-adoption-plan"></a>
## Lab 10 — Adoption plan

- **Why:** transfer the method without exposing customer data.
- **Context:** non-confidential summary of a narrow testing slice and approved policy constraints.
- **Expected:** reversible proof of concept, reviewers, success/stop criteria, and marked assumptions.
- **Weak response:** asks for production code or assumes features and data-handling approval.
- **Follow-up:** “What is the smallest synthetic or approved test that would validate this plan?”
- **Alternative:** complete the adoption plan as a team without Copilot.
