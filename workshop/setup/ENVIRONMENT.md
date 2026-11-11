# Environment and Copilot feature differences

This workshop uses ordinary .NET and Python commands for its application and test validation. Copilot customisation features depend on the host; verify them in the IDE actually used by participants rather than assuming parity.

| Surface | Suitable use | Important limitation or fallback |
|---|---|---|
| GitHub Copilot Chat in VS Code | Ask questions and run the guided prompts. | Repository instructions, prompt-file pickers, custom agents, skills, agent mode, and MCP tools may vary by extension version, policy, account, and rollout. If an asset is not selectable, open its Markdown file and paste its task into Chat. |
| VS Code agent mode | Use agents and configured tools to work across files or interact with the browser. | Tool availability is host configuration. The `playwright/*` aliases in the sample agent profiles require a compatible Playwright MCP server; their presence in a file does not install that server. |
| Copilot coding agent | A separate GitHub-hosted task experience. | It is not the local browser session or IDE agent mode. Do not assume local Playwright access, repository prompt-file invocation, or an identical tool set. Use local tests and Chat as the workshop path. |
| Visual Studio | Build, run, and test the .NET app; use Copilot Chat where available. | Customisation discovery and prompt/skill/agent support can differ from VS Code. Read the corresponding files directly and use ordinary terminal commands when a picker is absent. |
| GitHub Codespaces | Run the same checkout and commands in an organisation-approved cloud development environment. | This repository does not provide a devcontainer that guarantees Copilot extensions or Chromium. Check prerequisites after the Codespace starts. |
| Local Windows/macOS/Linux | Run the application and .NET Playwright tests locally. | Windows uses PowerShell 7 (`pwsh`) for the Playwright installer; PowerShell 5 can run most other commands. macOS/Linux examples use Bash and `python3`. Playwright downloads browser binaries to the local user cache. |
| Playwright MCP browser | Optional interactive browser exploration through Copilot tools. | It is separate from the .NET Playwright test runner. If unavailable, explore manually in a browser and record observations in the worksheet. |

## Manual capability check

1. Open a Copilot Chat conversation in the selected IDE and ask: “Which repository instruction files are in scope for this file? Cite their paths. Do not edit files.”
2. Check whether `.github/prompts/01-map-the-application.prompt.md` appears in the prompt UI. If not, open and paste its contents.
3. Check whether **Legacy Application Archaeologist** and **Exploratory Tester** appear in the agent picker. If not, paste the respective agent file into Chat as context.
4. Check whether skills can be selected or loaded. If not, open the relevant `SKILL.md` and provide it as context.
5. Check whether browser navigation/snapshot tools are available. If not, use the manual journey in Lab 07; do not claim Copilot interacted with the browser.
6. Use local Playwright scripts for deterministic tests regardless of whether MCP browser tools are available.

The purpose is to record the actual surface and fallback, not to make every participant use the same feature set.

## Data and policy

Use only synthetic values. Confirm that your organisation permits sending repository content to the selected Copilot service. Never paste customer or production code into an unapproved service. Review screenshots and traces before sharing because they may preserve form values and page content.
