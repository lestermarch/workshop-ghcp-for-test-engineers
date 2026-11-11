# Presenter demo prompts and Copilot App walkthrough

**Facilitator preparation, not a participant answer sheet.**
**Status:** AI-generated draft for presenter review. Repository assets and linked GitHub documentation inspected on 11 November 2026. These prompts are recommendations, not recorded successful demo runs.

## Recommendation for the hour

Demonstrate a small selection, not the whole catalogue. The repository currently has 28 prompt files, 16 skills, and 12 custom agents. Keep the story **observe → question → generate → inspect → run → decide**.

| Minutes | Demonstration | Prompts below |
|---|---|---|
| 0–7 | Welcome, synthetic scope, concept refresher. | Presentation; A if needed. |
| 7–12 | Instructions, prompt files, skills, agents, and tools. Open one file of each kind. | A; show B without waiting for a full repository map. |
| 12–18 | One standalone example: generate and run a focused unit test using a skill. Show the integration alternative, but do not run both. | C; D is backup. |
| 18–31 | Lab 07: explore one journey in the VS Code browser view. Record one reproducible observation. | F. |
| 31–45 | Lab 08: create, inspect, and run one .NET Playwright test. | G, then H. |
| 45–51 | Lab 09: inspect evidence, classify the result, obtain a human decision. | I; J is optional. |
| 51–57 | Copilot App: show the shared browser canvas and a report or observation record. Reuse the same story, not another full exploration. | App walkthrough below. |
| 57–60 | Questions and self-paced handoff. | Point to the workshop guide and unused prompt bank. |

If time slips, cut the standalone unit example or the App segment, not test inspection or human review. Prepare the App in advance so switching surfaces does not consume the segment.

## How to invoke the different mechanisms

| Mechanism | What to do in the demonstration | What it is not |
|---|---|---|
| Instructions | Open `.github/copilot-instructions.md`, then one matching `.github/instructions/*.instructions.md`. Ask which guidance applies to the target file. | Not a task to execute or an access-control boundary. |
| Prompt file | In VS Code, type `/` and select the actual listed prompt by its basename. Supply the demo-specific context below. | Not a guaranteed command in every Copilot surface. |
| Skill | Ask explicitly: "Apply the `generate-unit-tests` skill..." Observe the host's skill-loading indication where available. | Not a new model, executable test runner, or permission grant. |
| Custom agent | Select the actual agent in the picker before sending the task. In the Copilot App, `/agent` is another documented selection route. | Merely writing an agent's name in prose does not prove that the profile was selected. |
| Tool / MCP | Point out the browser, file, or terminal operation the agent actually calls. | A skill mentioning Playwright does not install or configure browser tools. |
| Canvas | Work with a shared visible surface, such as a browser page or editable document. | A preview alone does not establish that an automated regression test passed. |
| Plugin | Show an installed package's contributed capabilities, if relevant. | Not synonymous with a skill, an MCP server, or a canvas. |

**Compatibility:** these repository prompt files have Markdown bodies without YAML front matter. Check whether the installed VS Code version lists them; do not promise a slash command before looking. If a prompt is absent, open/attach its file and explicitly ask Copilot to follow it. In the App, use the same file-context fallback rather than assuming VS Code prompt-file invocation parity. For a skill, manual reading is a fallback, not proof of native skill activation.

**Agent tools:** `Test author` requests read/search/edit, but not execute; the review agents are read/search only. Run commands yourself or switch to the default execution-capable agent. `Exploratory Tester` and `Playwright Test Engineer` name `playwright/*` MCP tools; those are not automatically the App browser-canvas tools. Never grant broad tools merely to make a demonstration work.

**Context:** use a fresh conversation for Lab 07 after source-based demos. Otherwise the agent may already know implementation details and the exercise is no longer an unprimed black-box exploration.

## Preparation and boundaries

- Use a rehearsal checkout/worktree containing all intended workshop files. Uncommitted and untracked work is not automatically included in a new worktree. This checkout already contains participant-created E2E work: do not overwrite it or assume `TEST-E2E-04` is free.
- Run readiness before presenting: `python scripts\workshop_ready.py --deep` and `python scripts\check_workshop.py`. Follow their remediation only where necessary. Rehearse the selected test and browser tools separately.
- Start the synthetic app using Lab 00's disposable-database instructions. Copy the actual listening URL; do not assume port 5007 is free. If occupied, identify the owner or choose another port, not a process to kill.
- Have one approved synthetic observation and a prepared screenshot/trace/report available. Label prerecorded evidence with its run/date; do not pass it off as the current run.
- Do not read `reference-outcomes`, workshop hints, solutions, or answer guidance during projected exploration. The `tests\Reference` suite is facilitator-controlled and included in deep readiness and verification runs.
- Keep all generated output under human review. Do not repair application code, install plugins, create PRs, or reset the checkout as a side effect of these demo prompts.
- For test-writing demos, use the existing traceability/evidence conventions and inspect the diff. Do not invent a requirement or silently mark a human decision accepted.

## Standalone prompt, skill, and agent examples

### A. Instructions: show guidance at the point of use

**Surface:** default agent, read-only request. **Time:** 1–2 minutes.
**Open:** `.github/copilot-instructions.md` and `.github/instructions/ui-tests.instructions.md`.

```text
For a proposed test under tests\EndToEnd, inspect the repository guidance
that applies to that path. Explain the five most relevant constraints in a
compact table: instruction, source path/line, and effect on our test.
Distinguish files you found from guidance you can verify the host loaded.
Do not edit files, run tests, inspect facilitator answers, or generate a test.
```

**Show:** persistent repository guidance versus today's task. An answer claiming automatic activation without host evidence is a useful limitation to challenge, not something to repeat as fact.

### B. Prompt file: bounded application discovery

**Invoke:** `01-map-the-application` from the VS Code prompt picker, if listed.
**Fallback:** attach `.github/prompts/01-map-the-application.prompt.md`.
**Time:** 2–3 minutes; optional alternative to C.

```text
Follow .github\prompts\01-map-the-application.prompt.md.
For this short demo, scope the application map to the notice-details request:
route → controller action → EF Core lookup → Razor view.
Give at most six bullets with source path/line citations and one unknown.
Return the inventory, component-map excerpt, and activity-record draft in
Chat only; do not save files. Do not inspect reference-outcomes,
tests\Reference, workshop hints/solutions, or answer guidance.
Do not change code, run tests, or expand into a full repository audit.
```

**Show:** the reusable prompt defines objective, context, constraints, response shape, and validation; the extra request supplies scope. The controller's default route and details action are real trace points, not an invented service architecture.

### C. Skill: one focused unit-test demonstration

**Invoke:** default execution-capable agent with the named skill.
**Open:** `.github/skills/generate-unit-tests/SKILL.md`.
**Time:** 4–6 minutes. **Recommended standalone live example.**

First request a proposal:

```text
Apply the generate-unit-tests skill to Notice.PublicationDate().
Inspect src\LegacyNoticeManager\Models\Notice.cs and
tests\Unit\NoticeBaselineTests.cs. Choose one uncovered interaction involving
Emergency and region, using explicit fixed dates, and propose the smallest
xUnit test or theory. Check for duplicate coverage before claiming a gap.
State the expected value's implementation source and label this as
characterisation, not approved maritime policy.
Show the proposed code, test-level rationale, and exact focused command
in Chat. Do not edit files or run commands yet. Do not inspect answer keys.
```

After inspecting the proposal:

```text
Implement the reviewed unit-test proposal only. Do not change application
code or existing assertions. Follow tests\AGENTS.md and the unit-test
instructions, allocate an unused TestId, and update directly related
traceability/evidence with the requirement status still explicit.
Run the focused test, then dotnet test tests\Unit as required by the skill.
Report exact passed/failed/skipped counts and commands. Record missing
human approval as pending; do not claim a policy decision.
Show the diff and stop without committing or fixing the app.
```

**Show:** the skill is reusable method guidance; the default agent still performs the work with its tools. This pure calculation does not need HTTP or a browser.

### D. Skill: integration-test alternative

**Invoke:** default execution-capable agent, `generate-integration-tests`.
**Open:** its `SKILL.md` beside `tests/Integration/NoticePagesTests.cs`.
**Time:** 4–6 minutes. **Use instead of C, or leave for self-paced work.**

```text
Apply the generate-integration-tests skill. Inspect the existing
NoticeApplicationFactory, seed data, and NoticesController.Details.
Propose focused HTTP tests for an existing notice and a missing notice.
Check the current suite for duplicates. Reuse the isolated SQLite factory;
do not call the separately running demo app or external services.
Assert status and meaningful content where applicable. Explain why this
is integration rather than unit or browser coverage, and why these GET
requests do not require a persistence-mutation assertion.
Show the code and expected-result sources in Chat first. Do not edit or run.
```

After approval, use the same test-only execution gate as C, substituting `dotnet test tests\Integration`. The existing integration tests cover the register and an approved export; inspect the current suite again before asserting that this gap still exists.

### E. Custom agent: a testing task without code generation

**Select:** **Manual test designer**. **Time:** 2–3 minutes; optional.

```text
Using only the synthetic browser observation I provide, propose two manual
follow-ups: one negative/boundary case and one exploratory charter.
For each include preconditions, synthetic input, steps, evidence to collect,
expected-result source or explicit unknown, and a cleanup note.
Do not infer business policy, read facilitator answers, execute tools,
or edit files. Keep the response to one compact table.

Observation:
[paste an observation you actually made]
```

**Show:** a specialist role can improve test design without generating code. Its actual tools remain read/search; the prompt does not turn it into a browser operator.

## Main demonstration: Labs 07, 08, and 09

### F. Lab 07: browser exploration

**Select:** **Exploratory Tester**.
**Invoke:** `explore-application-in-browser` if listed, otherwise attach its prompt file.
**Open:** `.github/agents/exploratory-tester.agent.md` briefly, then show the browser.

```text
Follow .github\prompts\explore-application-in-browser.prompt.md.
The prepared synthetic app is running at [ACTUAL LOCAL URL].
Use the available browser tools to open it and explore one create-notice
journey. Try one invalid input and one boundary input; use synthetic data.
Do not inspect implementation, tests, facilitator material, or prior answers.
Keep this pass to five minutes, then stop.
Record exact action/input/result, whether it repeats, and the expected-result
source if known. Otherwise say unknown. Do not call it a confirmed defect.
Do not edit files or fix anything. If you cannot operate the browser,
say so and give manual steps instead of claiming interaction.
```

**Pause:** ask the audience which statements are observations and which need a requirement owner. Keep the observation in Chat or an observation record before switching to source-based work.

**Canvas caveat:** in VS Code, confirm the specialist can access the chosen browser tool. In the App, use the default agent plus the profile as task guidance if the selected specialist cannot call the shared canvas. Say that this is a fallback, not the same tool configuration.

### G. Lab 08: translate the observation into a test proposal

**Select:** **Playwright Test Engineer**.
**Invoke:** `generate-playwright-test-from-observation` if listed.

```text
Follow .github\prompts\generate-playwright-test-from-observation.prompt.md
and apply the playwright-test-generation skill.
Use only the verified observation below as the scenario.
Inspect the existing E2E fixture, BrowserTestBase, test instructions,
NoticeJourneyTests, and any participant tests to avoid duplication.
Propose one .NET Playwright/xUnit test, not a JavaScript test project.
First show the assertion's source, uncertainty, test-level rationale,
semantic locators, isolated-data strategy, code, and exact focused command.
An unsupported desired outcome needs a human decision; offer a clearly
labelled characterisation test or deferral rather than inventing policy.
Do not edit files, execute tests, or fix the application yet.

Observation and evidence:
[paste the Lab 07 record]
```

**Pause:** inspect whether the test would catch a meaningful change. Check locators, conditional assertions, data isolation, and the expected-result source.

### H. Lab 08: implement and execute the reviewed test

**Use:** the same agent, if execute is available.

```text
Implement only the reviewed Playwright scenario in a new, unused demo test
file/class under tests\EndToEnd. ParticipantPlaywrightTests.cs may already
contain work: do not overwrite it. Allocate an unused TestId.
Use BrowserApplicationFixture and RunBrowserScenarioAsync; do not hardcode
the preview app URL. Follow the repository's test and evidence instructions.
Update directly related traceability/evidence only, keeping human decisions
pending where not supplied. Do not modify the application or weaken assertions.
Run only the new class first, capturing a TRX under TestResults\E2E and
using an explicit LogFileName so it can be identified later.
Report the exact command, pass/fail/skip, and any artifact paths.
Do not commit, push, or attempt a fix after failure.
```

**Command shape, not a command to paste unchanged:**

```powershell
dotnet test tests\EndToEnd --filter "FullyQualifiedName~[NEW_CLASS_NAME]" --logger "trx;LogFileName=demo-focused.trx" --results-directory TestResults\E2E
python scripts\create_e2e_report.py --trx TestResults\E2E\demo-focused.trx --output TestResults\E2E\demo-focused.html
```

Replace the class placeholder with the generated class. Run the report command after the test result is captured, including on failure. `scripts\e2e.ps1` runs the whole E2E project, not a single class.

**Explain:** the E2E fixture launches a separate app on a dynamically selected loopback port with a temporary database. The shared preview is not that test's browser context. Failure screenshots/traces are captured by the base class; successful runs discard their traces.

### I. Lab 09: classify, then decide

**Use:** default execution-capable agent for reproduction/investigation.
**Invoke:** `investigate-failing-playwright-test` and `playwright-failure-investigation` only if a test actually failed.

```text
Follow .github\prompts\investigate-failing-playwright-test.prompt.md
and apply the playwright-failure-investigation skill.
Reproduce the supplied focused failure once without editing code.
Inspect the result, screenshot, and local trace if accessible before source.
Say explicitly which artifacts you could and could not inspect.
Separate facts, hypotheses, expected-result sources, and unresolved questions.
Classify the likely cause as application, test, environment/data,
ambiguity, or further investigation required.
Recommend the smallest next investigation and the human decision needed.
Do not change files, weaken assertions, or declare policy from passing tests.

Exact command and result:
[paste]
Observation and artifact paths:
[paste current-run evidence; label any prerecorded evidence separately]
```

For a passing test, do not manufacture a failure. Ask for review of the assertion and requirement evidence instead, or show the prepared intentional-failure demonstration labelled as such.

**Optional prepared evidence command:**

```powershell
$previousCaptureFailure = $env:E2E_CAPTURE_FAILURE
try {
    $env:E2E_CAPTURE_FAILURE = "true"
    .\scripts\e2e.ps1 -Mode headless
}
finally {
    if ($null -eq $previousCaptureFailure) {
        Remove-Item Env:E2E_CAPTURE_FAILURE -ErrorAction SilentlyContinue
    }
    else {
        $env:E2E_CAPTURE_FAILURE = $previousCaptureFailure
    }
}
```

This runs the whole E2E project and is expected to report a failure because `Failure_evidence_capture_demo` deliberately fails. It is not a product defect or evidence that the generated scenario failed. Prefer preparing it before the live slot.

Open an actual trace with the installed .NET Playwright `show-trace` script described in Lab 09. A `.zip` link in the HTML summary is not a trace viewer. Do not upload traces to a public service.

### J. Custom agent: independent critique, not another implementation

**Select:** **Change reviewer** for the test diff, or **Evidence and governance reviewer** for the result/decision record.
**Invoke:** `19-review-ai-generated-change` for the Change reviewer route.
**Time:** 2 minutes, within Lab 09 if time permits.

```text
Review only the demo test diff and its supplied evidence.
Follow .github\prompts\19-review-ai-generated-change.prompt.md.
Identify at most three material concerns: unsupported expectation,
weak assertion/locator, or missing isolation/evidence.
Cite paths/lines and distinguish inspected evidence from commands you ran.
Do not execute tests, change files, approve the change on my behalf,
merge, or inspect facilitator answers.
Return request changes, a recommendation to approve, or SME decision needed.
The acceptance decision remains mine.

Test file, exact command/result, and observation:
[paste]
```

**Show:** the writer and reviewer have different responsibilities. A separate profile is not proof of an independent human review or a different underlying model.

## Copilot App: recommended six-minute walkthrough

Do this in a prepared local repository session, not a workspace-less chat. Use Interactive mode and review tool permissions. A worktree isolates working files, not unrestricted network/process access.

### 1. Orient the audience, briefly

Show repository/session, selected mode, the agent picker, and the changes view. Explain: **same repository conventions and skills, another collaboration surface**. Do not spend the slot changing models, signing in, installing dependencies, or creating parallel sessions.

### 2. Open the running app in the shared browser canvas

Use the **default agent** so the host can expose its native canvas capabilities:

```text
Open [ACTUAL LOCAL APP URL] in the shared browser canvas beside this
conversation. Read the rendered page, then identify the create-notice action.
Keep the page available so I can interact with it too.
Do not inspect implementation or tests, modify files, or install anything.
If the URL is not responsive or the browser canvas is unavailable, report
the limitation instead of claiming a preview.
```

If startup is required, ask it to follow Lab 00, use a unique temporary SQLite database, confirm the actual URL responds, and keep only its own server running until you finish. Do not stop a pre-existing listener or reuse it without confirming its ownership and synthetic scope.

### 3. Demonstrate two-way collaboration

Manually navigate or enter a synthetic value in the canvas. Then send:

```text
Read the current state of this same shared browser canvas; do not open a
separate browser. Describe what changed since your last snapshot.
Use the current controls to demonstrate one invalid submission without
creating a valid notice. Capture the exact validation text and take a
screenshot if supported. Stop before any implementation inspection or fix.
Do not claim a screen-reader assessment from an accessibility snapshot.
```

**Talking point:** the human and agent can inspect and steer the same surface. This is different from generating a test against remembered HTML. If the chosen agent cannot access this canvas, switch back to the default agent; a separate MCP browser is a distinct fallback session.

### 4. Show regression evidence, not just a preview

Reuse H's focused test and result. Do not generate another test merely to demonstrate the App.

```text
Use the exact focused test command and result I provide.
If a new run is necessary, ask before rerunning it.
Generate the repository's HTML summary from that run's actual TRX using
scripts\create_e2e_report.py with explicit input and output filenames.
Open the report in a browser canvas if supported, otherwise in a regular
browser. Keep the application preview separate and label both.
Tell me whether the artifacts belong to this run. Do not claim that a
passing test saved a trace, and do not upload any artifact externally.

Command, result and TRX path:
[paste]
```

The HTML summary's artifact list scans the whole artifact directory; it is not automatically a current-run association. Match scenario names, timestamps, and test output before presenting a screenshot or trace.

If the canvas needs HTTP rather than local-file navigation, serve the repository's **`TestResults` directory only** on a free loopback port, for example `python -m http.server 8766 --bind 127.0.0.1 --directory TestResults`, and open `/E2E/demo-focused.html`. This also allows the existing relative artifact links to resolve. Confirm readiness and stop only this helper afterwards. Do not expose the repository or reports on all interfaces.

### 5. Finish with the human decision

Say whether you accept the test, amend it, reject it, or defer the expectation. Show the diff/evidence, not a claim that the preview or scanner assures correctness. Stop demo-owned servers after closing the preview; a closed/stopped server is not a lasting shared deliverable.

## Canvases and plugins worth showing

| Capability | Recommendation | Prerequisite / limitation |
|---|---|---|
| Shared **Browser** canvas | Main App demonstration: human interaction, agent reads the new state, evidence captured. | Verified in this session's canvas schema: navigate, read, click, type, screenshot, and page evaluation. No extra testing plugin is needed for these capabilities here. |
| **Editor** canvas | Useful supporting surface for the observation or AI-activity Markdown record. | Review factual content and mark the human decision pending until you make it. Not a test runner. |
| Local .NET Playwright plus screenshot/trace/report | Best testing companion to the canvas. | Existing repository tooling, not an App plugin. Agent browser exploration and automated test execution are separate evidence. |
| A small **test triage** canvas | Good optional prepared example of a shared testing workflow. | A custom extension, not a verified preinstalled testing dashboard. Prepare/rehearse before the session; do not build it during the hour. |
| **`github-security`** plugin / Security canvas | Optional later session on defensive code review; not a substitute for Labs 07–09. | Documented public preview. Existing code-scanning alerts require repository access and code scanning; a local review does not require code scanning enabled. Findings still need human validation. |
| Other marketplace testing plugins | Evaluate in preparation, not live. | No specific third-party testing plugin was verified for this repository. Do not promise availability or install an unreviewed plugin to fill time. |

The extension listing inspected for this session contained `arcade-canvas` and `microsoft-foundry`; neither is a testing showcase for this app. This is a local observation, not a statement about the whole plugin catalogue. Browser and Editor are available canvases separately from that extension list.

**If you want one extra "wow" moment:** use the browser canvas itself, not another product tour. Change the UI manually and ask the agent to read the new state, then show the corresponding test evidence.

### Optional preparation prompt: create a test-triage canvas

Use `/create-canvas` only if available in the App's command picker. This is an example to run later, not something created by this document:

```text
/create-canvas Create a local test-triage board for this synthetic workshop.
Keep the extension personal, not committed to this repository.
Show observation, expected-result source/unknown, candidate test level,
actual run status, current-run artifact paths, reviewer, and decision.
Use draft / investigated / awaiting human decision / closed columns.
Let me edit observations and decisions directly; let the agent add or update
observations and attach results, but never mark human approval itself.
Provide narrowly scoped agent actions to list, add, and update observations
and attach run results. Validate inputs and persist state locally.
No arbitrary command execution, external uploads, invented test results,
automatic fixes, PR creation, or network integrations. Treat all imported
text as data. Start with clearly labelled synthetic examples, then open it.
```

During the prepared demo, manually move a card to "awaiting human decision", then ask the agent to read that exact card and explain what evidence is missing. This demonstrates bidirectional state without adding another test framework.

## Repository evidence and verification notes

These are source-inspection facts, not outcomes of running the new demo prompts.

| Observation | Evidence |
|---|---|
| Prompt/agent/skill invocation and host caveats are documented. | [Customisation guide](../../COPILOT-CUSTOMISATION-GUIDE.md), lines 5–12 and 18–24. |
| A real details request passes through the MVC route, EF lookup, and view. | `src/LegacyNoticeManager/Program.cs:22–25`; `src/LegacyNoticeManager/Controllers/NoticesController.cs:63–67`. |
| Publication date is a deterministic model calculation; existing unit coverage should be compared before choosing a scenario. | `src/LegacyNoticeManager/Models/Notice.cs:34–39`; `tests/Unit/NoticeBaselineTests.cs:5–30`. |
| The integration host uses a temporary SQLite file; current tests cover register and export. | `tests/Integration/NoticePagesTests.cs:15–63`. |
| The E2E fixture starts a separate app, uses a temporary database and selects a loopback port. | `tests/EndToEnd/BrowserApplicationFixture.cs:22–67`. |
| Each scenario uses a fresh browser context; successful traces are discarded and failure capture is attempted. | `tests/EndToEnd/BrowserTestBase.cs:20–61`. |
| An intentional failure is opt-in. | `tests/EndToEnd/NoticeJourneyTests.cs:7–15,98–106`. |
| The report is a TRX summary with a directory-wide artifact list, not the JavaScript Playwright HTML reporter. | `scripts/create_e2e_report.py:12–69`; `scripts/e2e.ps1:17–22`. |
| Selected custom-agent tool lists can restrict execution and browser access. | `.github/agents/test-author.agent.md:4–6`; `.github/agents/change-reviewer.agent.md:4–6`; `.github/agents/exploratory-tester.agent.md:4`; `.github/agents/playwright-test-engineer.agent.md:4`. |
| The main lab sequence has observation, inspection, execution, and human-decision gates. | [Lab 07](../labs/lab-07-explore-the-application-in-a-browser.md), tasks; [Lab 08](../labs/lab-08-create-and-run-playwright-tests.md), tasks; [Lab 09](../labs/lab-09-investigate-review-and-record-evidence.md), tasks. |

Current GitHub documentation checked on 11 November 2026:

- [Customising the Copilot App: skills, agents, MCP, plugins and canvases](https://docs.github.com/en/copilot/how-tos/github-copilot-app/customize-github-copilot-app)
- [Agent sessions, worktrees, modes and tool permissions](https://docs.github.com/en/copilot/how-tos/github-copilot-app/agent-sessions)
- [Canvas extensions, discovery and `/create-canvas`](https://docs.github.com/en/copilot/how-tos/github-copilot-app/working-with-canvas-extensions)
- [App slash-command reference](https://docs.github.com/en/copilot/reference/github-copilot-app-reference/slash-commands)
- [Built-in App skills](https://docs.github.com/en/copilot/reference/github-copilot-app-reference/built-in-skills)
- [GitHub Security canvas prerequisites and public-preview limitations](https://docs.github.com/en/copilot/how-tos/github-copilot-app/view-and-fix-security-alerts)

**Unresolved until rehearsal:** actual VS Code prompt/skill discovery; the selected custom agent's access to the intended browser surface; App/plugin availability under organisation policy; elapsed generation/run time; and the authoritative expectation for the chosen observation. Product UI and command availability can change.

Drafting checks run on 11 November 2026:

| Command | Actual outcome |
|---|---|
| `python scripts\check_workshop.py` | Passed: 11 labs/checkpoints, required sections, and local workshop links. |
| `python scripts\validate_repository.py` | Passed: repository assets, customisation counts, skill metadata, and relative Markdown links. |
| `git diff --check` | Passed for tracked changes. This does not inspect the untracked guide; its links were covered by the documentation validators above. |

**Human review:** pending. The presenter should choose the live subset, rehearse it in the actual host, and record accepted/amended/rejected/deferred decisions. No demonstration prompts, new tests, plugin installations, or custom canvas builds were executed as part of drafting this guide.
