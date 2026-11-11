# Copilot customisation guide

| Asset | Location | Intended use and compatibility |
|---|---|---|
| Repository instructions | `.github/copilot-instructions.md` | Shared context for supported Copilot coding surfaces; not a substitute for checking each IDE. |
| Path instructions | `.github/instructions/*.instructions.md` | Scoped by `applyTo`; support varies by product. |
| Agent instructions | `AGENTS.md` | Nearest applicable guidance for agent experiences that discover AGENTS.md. |
| Custom agents | `.github/agents/*.agent.md` | Specialist profiles where repository agents are supported; tool restrictions and automatic selection vary. Includes Exploratory Tester and Playwright Test Engineer. |
| Skills | `.github/skills/<name>/SKILL.md` | Agent skill discovery in supported surfaces; manual fallback is to read the skill file. Browser skills document exploration, generation, and failure investigation. |
| Prompt files | `.github/prompts/*.prompt.md` | Reusable prompts in supported IDEs; copy the prompt body into Copilot Chat elsewhere. Browser prompts live alongside the numbered golden path. |

These are not guaranteed to behave identically in GitHub.com, Copilot coding agent, CLI, Visual Studio Code, Visual Studio, and other IDEs. Confirm current product support before relying on an automatic activation or tool restriction. The workshop itself remains usable by reading the Markdown files manually. No preview-only feature is required for application build/tests.

The guided examples, mechanism map, host compatibility notes, and before/after experiment are in [Workshop Labs 02–05](workshop/README.md).

Agent profiles use conservative read/search permissions when the format supports tool selection; test-authoring profiles request edit capability only. The host still determines available tools. Never grant credentials or broad external permissions for this sample.

## How to invoke the assets

- In a surface that lists repository agents, choose **Legacy application archaeologist**, **Test-gap analyst**, **Test author**, **Manual test designer**, **Documentation recovery specialist**, **Security and privacy reviewer**, **Accessibility reviewer**, **Evidence and governance reviewer**, **Change reviewer**, **Workshop facilitator**, **Exploratory Tester**, or **Playwright Test Engineer**. If the picker is unavailable, open the matching `.github/agents/*.agent.md` file and paste its task instructions into Chat.
- For the live UI exercise, choose **Exploratory Tester** first. Its first pass is browser-only; it must write observations before reading application source. Choose **Playwright Test Engineer** only after selecting an observed scenario. These profiles reference `playwright/*` MCP tool aliases; the host must expose/configure that server. If it does not, use the .NET Playwright test scripts and copy observations manually.
- Skills are task guidance, not necessarily visible commands. Ask Copilot to apply the named skill (for example `requirements-recovery`) where skill discovery is supported; otherwise read `.github/skills/<name>/SKILL.md` and provide it as context.
- In IDEs that support prompt files, select a prompt by its basename, such as `01-map-the-application`. Else copy its contents from `.github/prompts/` into Copilot Chat.
- Repository and path-specific instructions are automatically discovered only by supported surfaces and within their documented scope. When uncertain, provide the relevant file explicitly.
