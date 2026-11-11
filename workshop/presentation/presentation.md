# GitHub Copilot for testing: concept refresher

## Brief

**Audience:** testers, test-automation engineers, quality engineers, developers, and test leads; familiarity with Copilot may vary.

**Outcome:** participants can follow a safe observation-to-evidence testing loop and know where to continue the workshop independently.

**Delivery:** a presenter-led refresher of approximately seven minutes within a one-hour session, followed by a live demonstration, discussion, and repository handoff. Timings are guidance, not a benchmark.

**Story:** move from an uncertain legacy application to a reviewable testing decision, then invite participants to repeat the process themselves.

## Slide plan

| # | Slide | Purpose and takeaway | Visual intent | Time |
|---|---|---|---|---:|
| 1 | Copilot supports testing judgement | Set the expectation that Copilot assists the tester; a human remains responsible for the decision. | One opening statement. | 0.5 min |
| 2 | Meet the synthetic application | Introduce the fictional notice workflow as a safe place to investigate incomplete documentation and tests. | Three cards introduce the synthetic system and its gaps. | 1 min |
| 3 | Choose the right Copilot mechanism | Distinguish instructions, prompts, agents, skills, and tools by the role each plays. | A compact comparison. | 1.5 min |
| 4 | Start with observation | Separate what happened from an expected result and from an unanswered question. | Three labelled statements. | 1 min |
| 5 | Make one focused test | Show how one supported observation becomes a reviewed, isolated test at an appropriate level. | A short sequence from observation to execution. | 1 min |
| 6 | Review the result, not just the assertion | Classify a result, inspect available evidence, and record a human decision before changing the app. | A three-step review sequence. | 1 min |
| 7 | Continue with the workshop | Give participants a safe starting point and the self-paced route after the demonstration. | A short call to action. | 1 min |

The slides total seven minutes. The remaining session time is reserved for the live walkthrough, discussion, questions, and handoff.

## Visual direction

**Concept:** a familiar GitHub repository surface—quiet white cards, subtle grey borders, charcoal text, blue links, and green reserved for the next action.

The palette follows [GitHub Primer's light product colours](https://primer.style/product/primitives/color/): `#1f2328` text, `#f6f8fa` subtle surfaces, `#d1d9e0` borders, `#0969da` links, and `#1f883d` for the workshop-guide action. The deck uses CSS tokens, no remote illustrations, and no animation.

| Slide | Layout pattern | Why |
|---|---|---|
| 1 | Statement | A single central workshop principle. |
| 2 | Evidence | Three cards establish the synthetic system and its uncertainty. |
| 3 | Diagram | Five related Copilot mechanisms are grouped as cards. |
| 4 | Comparison | Observed, expected, and unknown are distinct categories. |
| 5 | Process | The test workflow is an ordered three-step sequence. |
| 6 | Process | The response to a failure is presented as three ordered review actions. |
| 7 | Conclusion | The participant handoff and guide link close the session. |

## Source ledger

The following repository sources were inspected on 11 November 2026. Confidence is high for what each file documents or implements; none establishes real-world maritime policy.

| Claim | Repository evidence | Slides |
|---|---|---|
| The application and notice workflow are fictional and synthetic. | `README.md:3-7` | 1, 2 |
| The workshop distinguishes Copilot customisation mechanisms and notes host-dependent support. | `COPILOT-CUSTOMISATION-GUIDE.md:3-12` | 3 |
| Browser exploration records observations and separates them from expectations. | `workshop/labs/lab-07-explore-the-application-in-a-browser.md:25-36` | 4 |
| The workshop reviews a focused Playwright test before execution and classifies its result. | `workshop/labs/lab-08-create-and-run-playwright-tests.md:25-45` | 5, 6 |
| Evidence and human decisions are recorded without treating test results as policy. | `EVIDENCE-GUIDE.md:3-7`; `workshop/labs/lab-09-investigate-review-and-record-evidence.md:25-33` | 6 |
| The participant path includes setup, labs, checkpoints, and safety guidance. | `workshop/README.md:18-25,29-41,52-63` | 7 |

## Assumptions and open questions

- Participants may have different Copilot and browser-tool capabilities. Check the actual host; use manual browser exploration or paste the relevant prompt or agent text if necessary.
- The expected behaviour for an observation may be unknown. Ask a product or subject-matter expert rather than inventing policy.
- The presentation uses online Reveal.js assets. If the network is unavailable, use this outline as the fallback.
- Detailed skill installation, facilitator answers, and real-world adoption decisions are outside this short refresher and remain in the self-paced workshop.

## Run the presentation

From the repository root, start a local server:

```shell
python -m http.server 8000 --bind 127.0.0.1
```

Open `http://127.0.0.1:8000/workshop/presentation/` in a browser. Use the arrow keys to navigate and press `S` for speaker notes; allow the speaker-view popup if prompted. The deck needs network access to load its pinned Reveal.js and plugin assets. Stop the server with Ctrl+C.
