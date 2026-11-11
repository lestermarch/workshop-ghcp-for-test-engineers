# Setup and validation

**Working directory for every command below:** the repository root.

## Prerequisites

- .NET 10 SDK matching `global.json`.
- Python 3.10 or later for workshop scripts.
- Git for cloning, checking changes, and optional reset exercises.
- PowerShell 7 (`pwsh`) for the Windows Playwright installer; PowerShell 5 can run most other Windows examples.
- A GitHub Copilot-enabled IDE or Chat surface permitted by your organisation.
- Playwright Chromium for automated browser tests. Install it once with `.\scripts\install-playwright.ps1` in PowerShell, or `bash scripts/install-playwright.sh` in Bash.
- A browser for manual exploration. The separate Playwright MCP browser is optional; the .NET Playwright suite uses its own local Chromium.

No Azure subscription, cloud credentials, external service, or customer data is required.

## Supported starting points

- **Visual Studio Code:** open the repository folder, sign in with an approved Copilot account, and confirm Chat is available. Agent mode, prompt files, custom agents, skills, and MCP tools vary by extension version, policy, account, and rollout; use the compatibility notes in [ENVIRONMENT.md](ENVIRONMENT.md).
- **GitHub Codespaces:** use only when the repository and organisation permit Codespaces. The workshop does not assume a repository devcontainer or automatic browser installation. Run the same documented commands in the Codespace terminal; install the browser if needed.
- **Visual Studio or another supported IDE:** use it for the .NET workflow if available. Do not assume it exposes the same prompt-file, agent, skill, or MCP features as VS Code.
- **Local Windows:** PowerShell commands in lab steps use Windows path syntax. Install PowerShell 7 (`pwsh`) for Chromium installation, then run `.\scripts\install-playwright.ps1`.
- **Local macOS/Linux:** use the Bash commands shown beside PowerShell commands. Install Chromium with `bash scripts/install-playwright.sh`.

## First checks

1. Run the readiness check from the repository root.

   PowerShell:

   ```powershell
   python scripts/workshop_ready.py
   ```

   Bash:

   ```bash
   python3 scripts/workshop_ready.py
   ```

   Read every **FAIL** and **WARN** and follow its remediation.
2. Run `dotnet restore LegacyNoticeManager.sln`, then `dotnet build LegacyNoticeManager.sln --no-restore`.
3. Install Chromium if the readiness check reports it missing.
4. Run `python scripts/check_workshop.py` to validate the workshop files and lab structure.
5. Validate test commands from Lab 00. E2E is skipped from this readiness stage if Chromium is unavailable; do not count a skipped test as a pass.
6. Complete the manual Copilot and browser-tool checks in [ENVIRONMENT.md](ENVIRONMENT.md).

## Recovery

If a prerequisite fails, see [troubleshooting](../troubleshooting/README.md). Do not spend the workshop session reinstalling an IDE or changing organisation policy. Use the manual browser and Chat fallbacks, then return to the automated steps later.
