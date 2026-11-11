# Lab 00 — Setup and validation

**Estimated duration:** 12 minutes
**All terminal commands:** run from the repository root unless a task says otherwise.

## Purpose

Confirm that the local app, baseline test commands, Copilot surface, and optional browser tools are ready. Keep environment setup separate from a claim that Copilot features are identical across IDEs.

## Learning objectives

- Identify the repository root and supported tools.
- Run the single readiness check and interpret pass, warning, and fail results.
- Start the synthetic application and confirm the test/browser route.
- Record which Copilot customisations and tools the chosen host actually exposes.

## Starting state

A fresh checkout or an existing worktree at the repository root. No cloud account or customer data is needed.

## Files involved

`global.json`, `LegacyNoticeManager.sln`, `README.md`, `QUICKSTART.md`, `scripts/workshop_ready.py`, `scripts/check_workshop.py`, `.github/prompts/`, `.github/agents/`, `.github/skills/`, and `tests/`.

## Tasks

1. **Open:** confirm the IDE's open folder is the repository root. The root contains `LegacyNoticeManager.sln` and `global.json`.
2. **Terminal — PowerShell (repository root):**

   ```powershell
   python scripts/workshop_ready.py
   python scripts/check_workshop.py
   ```

   **Terminal — Bash (repository root):**

   ```bash
   python3 scripts/workshop_ready.py
   python3 scripts/check_workshop.py
   ```

   **Observe:** each check prints `PASS`, `WARN`, or `FAIL` and a remediation. A warning about Copilot or MCP capability requires a manual check, not an installation guess.
3. **Terminal — restore and build (repository root):**

   ```shell
   dotnet restore LegacyNoticeManager.sln
   dotnet build LegacyNoticeManager.sln --no-restore
   ```

   **Observe:** the solution builds without errors.
4. **Terminal — install Chromium if the readiness check says it is missing:**

   ```powershell
   .\scripts\install-playwright.ps1
   ```

   ```bash
   bash scripts/install-playwright.sh
   ```

   This downloads Playwright Chromium to the user cache. It does not configure the optional Copilot MCP browser.
5. **Terminal — baseline tests (repository root):**

   ```shell
   dotnet test tests/Unit
   dotnet test tests/Integration
   dotnet test tests/EndToEnd
   ```

   **Observe:** unit and integration suites pass. The current E2E suite has three regular scenarios; the intentional failure-evidence demo is skipped unless explicitly enabled. Record actual results; a skipped test is not a pass.
6. **Terminal — start the app with a disposable synthetic database.**

   PowerShell:

   ```powershell
   $env:ConnectionStrings__NoticeDatabase = "Data Source=$env:TEMP\workshop-notices.db"
   dotnet run --project .\src\LegacyNoticeManager
   ```

   Bash:

   ```bash
   export ConnectionStrings__NoticeDatabase="Data Source=${TMPDIR:-/tmp}/workshop-notices.db"
   dotnet run --project ./src/LegacyNoticeManager
   ```

   **Observe:** the terminal prints a local URL. Open it in a browser. Starting the app creates the synthetic SQLite database. Stop it with Ctrl+C before cleanup.
7. **Copilot — capability check:** in the chosen Copilot Chat surface, ask: “Which repository instruction files apply to this conversation and how can I invoke a prompt file or custom agent here? State uncertainty; do not edit files.” Compare the response with [the environment matrix](../setup/ENVIRONMENT.md).
8. **Open:** inspect the prompt list and agent list. If the selected IDE cannot invoke a prompt or agent, open the relevant Markdown file and paste it into Chat. Confirm browser MCP tools manually; use Lab 07's manual route if absent.
9. **Human decision:** record the environment and fallback in `workshop/participant-work/environment.md`. Do not change organisation policy to make a feature appear.

## Copyable prompts

Use the capability-check prompt in Task 7. It is intentionally read-only and asks Copilot to identify support rather than assume it.
See the [Lab 00 prompt review card](../resources/PROMPT-REVIEW-CARDS.md#lab-00-capability-check) for context and weak-response signals.

## Expected observations

- The readiness tool distinguishes machine checks from manual Copilot-feature checks.
- The app runs locally with synthetic data.
- The E2E test fixture starts its own app and temporary database; the separately started app is only for manual exploration.
- Codespaces and IDE support vary; the fallback remains a local command plus copied prompt/agent text.

## Validation checkpoint

Complete [Checkpoint LAB-00](../checkpoints/lab-00.md). The objective check is `python scripts/workshop_ready.py`; the manual rubric is in [ENVIRONMENT.md](../setup/ENVIRONMENT.md).

## Discussion questions

- Which checks were automated and which required a human?
- Which Copilot capabilities are confirmed in this IDE?
- What should you do if a team member has a different feature set?

## Troubleshooting

See [setup guidance](../setup/README.md) and [troubleshooting](../troubleshooting/README.md). If Chromium installation is blocked, continue with manual exploration; do not claim the browser tests ran.

## Optional challenge

**Explore:** after the exercise, run `python scripts/workshop_ready.py --deep` if the team permits package restore and test execution. It includes the facilitator reference suite. Compare the deeper result with the fast check.

## Completion criteria

Readiness output is recorded, the app was opened or a blocker was documented, baseline test results are exact, and Copilot feature availability is not overstated.

## Next lab

Continue to [Lab 01 — Meet the legacy application](lab-01-meet-the-legacy-application.md).
