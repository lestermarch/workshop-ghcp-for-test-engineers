# Troubleshooting

| Symptom | Likely cause | Recovery |
|---|---|---|
| `dotnet` cannot find an SDK | .NET 10 SDK missing or `global.json` feature band unavailable. | Install an organisation-approved .NET 10 SDK, open a new terminal, and rerun `python scripts/workshop_ready.py`. |
| Restore or build fails | Network/package feed policy, missing SDK, or a compile error. | Capture the full error, confirm `dotnet --version`, retry `dotnet restore LegacyNoticeManager.sln` only if policy permits, and use the facilitator's prepared environment if still blocked. |
| App does not start | Port conflict, stale process, or local database path. | Stop the process started by this participant with Ctrl+C. Use the temporary database commands in Lab 00 and retry. Do not delete an unidentified database or process. |
| Chromium executable is missing | Browser installation did not complete or the cache path differs. | Run the platform-specific installer in setup, then rerun the E2E test. Do not download a random browser binary. |
| Playwright MCP tools are absent | MCP server not configured or unsupported in the IDE. | Perform the Lab 07 journey manually. The .NET Playwright tests still run with installed Chromium. |
| Prompt or agent is not in the picker | The current Copilot surface does not support or discover that asset. | Open the Markdown file and paste its instructions into Chat; report the actual surface rather than claiming automatic activation. |
| Skill metadata is rejected | Community asset format or `name` does not match the repository folder. | Keep the external copy in a temporary review folder; adapt metadata to the documented local format before installation. |
| Generated test does not compile | Wrong fixture/API, missing using, or unsupported generated code. | Compare with `tests/EndToEnd/NoticeJourneyTests.cs`, run `dotnet build tests/EndToEnd`, and ask for the smallest compile-only correction without changing application code. |
| Browser test fails | Could be a product behaviour, test logic, data, environment, or ambiguity. | Follow Lab 09: inspect output and artifacts, reproduce, gather requirement evidence, classify, and obtain a human decision. |
| Database appears inconsistent | A local run reused an old synthetic database. | Stop the app. Set `ConnectionStrings__NoticeDatabase` to a new path under the OS temp directory and restart. Keep the old file until its owner confirms it is disposable. |
| Participant edits break an exercise asset | The experiment changed more than intended. | Use `python scripts/reset_workshop.py LAB-03` (replace with the affected lab ID). The reset script previews, backs up, and removes only known participant-created files. |
| Participant falls behind | Copilot surface or setup is taking longer than the lab. | Skip optional challenges, use the bundled skill fallback, or pair with the facilitator. Preserve the current checkpoint and continue at Lab 07 or Lab 08. |

For unresolved problems, capture command, exact output, environment, and attempted recovery in the local participant-work folder. Do not paste secrets or customer content into a support prompt.
