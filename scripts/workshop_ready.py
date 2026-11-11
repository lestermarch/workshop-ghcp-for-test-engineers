#!/usr/bin/env python3
"""Check local workshop prerequisites and optionally run the baseline validation."""

from __future__ import annotations

import argparse
import os
import shutil
import subprocess
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
REQUIRED_FILES = (
    "LegacyNoticeManager.sln",
    "global.json",
    "src/LegacyNoticeManager/Program.cs",
    "tests/Unit/LegacyNoticeManager.UnitTests.csproj",
    "tests/Integration/LegacyNoticeManager.IntegrationTests.csproj",
    "tests/EndToEnd/LegacyNoticeManager.EndToEndTests.csproj",
    "tests/Reference/LegacyNoticeManager.ReferenceTests.csproj",
    "workshop/README.md",
    "workshop/setup/ENVIRONMENT.md",
    "workshop/labs/lab-00-setup-and-validation.md",
    ".github/prompts/01-map-the-application.prompt.md",
    ".github/agents/exploratory-tester.agent.md",
    "scripts/check_workshop.py",
)


class Results:
    def __init__(self) -> None:
        self.failures = 0
        self.warnings = 0

    def report(self, status: str, item: str, detail: str, remediation: str = "") -> None:
        print(f"{status}: {item} - {detail}")
        if remediation:
            print(f"  Remediation: {remediation}")
        if status == "FAIL":
            self.failures += 1
        elif status == "WARN":
            self.warnings += 1


def run_check(results: Results, label: str, command: list[str], remediation: str) -> bool:
    try:
        completed = subprocess.run(
            command,
            cwd=ROOT,
            capture_output=True,
            text=True,
            timeout=600,
            check=False,
        )
    except (OSError, subprocess.TimeoutExpired) as error:
        results.report("FAIL", label, str(error), remediation)
        return False
    if completed.returncode:
        details = (completed.stdout + completed.stderr).strip().splitlines()
        results.report("FAIL", label, details[-1] if details else f"exit code {completed.returncode}", remediation)
        return False
    results.report("PASS", label, "completed successfully")
    return True


def browser_installed() -> bool:
    configured = os.environ.get("PLAYWRIGHT_BROWSERS_PATH")
    if configured == "0":
        cache = ROOT / "tests/EndToEnd/bin/Debug/net10.0/.playwright"
    elif configured:
        cache = Path(configured)
    elif sys.platform == "win32":
        cache = Path(os.environ.get("LOCALAPPDATA", Path.home() / "AppData/Local")) / "ms-playwright"
    elif sys.platform == "darwin":
        cache = Path.home() / "Library/Caches/ms-playwright"
    else:
        cache = Path.home() / ".cache/ms-playwright"
    return cache.is_dir() and any(cache.glob("chromium-*"))


def main() -> int:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument(
        "--deep",
        action="store_true",
        help="restore/build and run baseline tests; run E2E only when Chromium is installed",
    )
    args = parser.parse_args()
    results = Results()

    if sys.version_info < (3, 10):
        results.report("FAIL", "Python", f"{sys.version.split()[0]} detected; 3.10+ is required", "Install Python 3.10 or later.")
    else:
        results.report("PASS", "Python", f"{sys.version.split()[0]} detected")

    dotnet = shutil.which("dotnet")
    if not dotnet:
        results.report("FAIL", ".NET SDK", "dotnet was not found", "Install the .NET 10 SDK and reopen the terminal.")
    else:
        try:
            sdk_list = subprocess.run(
                [dotnet, "--list-sdks"], cwd=ROOT, capture_output=True, text=True, timeout=30, check=False
            )
        except (OSError, subprocess.TimeoutExpired) as error:
            results.report("FAIL", ".NET SDK", str(error), "Install or repair the .NET 10 SDK.")
        else:
            sdk_lines = [line for line in sdk_list.stdout.splitlines() if line.startswith("10.")]
            if sdk_list.returncode == 0 and sdk_lines:
                results.report("PASS", ".NET SDK", f"found {sdk_lines[-1]}")
            else:
                results.report("FAIL", ".NET SDK", "no .NET 10 SDK was found", "Install the SDK version selected by global.json.")

    git = shutil.which("git")
    if not git:
        results.report("WARN", "Git", "git was not found", "Install Git if you need clone, diff, or reset exercises.")
    else:
        run_check(results, "Git checkout", [git, "-C", str(ROOT), "rev-parse", "--show-toplevel"], "Open the repository root, not a nested folder.")

    missing = [name for name in REQUIRED_FILES if not (ROOT / name).is_file()]
    if missing:
        results.report("FAIL", "Workshop files", ", ".join(missing), "Restore the complete repository checkout.")
    else:
        results.report("PASS", "Workshop files", f"all {len(REQUIRED_FILES)} required files are present")

    run_check(
        results,
        "Workshop structure and links",
        [sys.executable, str(ROOT / "scripts/check_workshop.py")],
        "Restore missing lab/checkpoint files or repair the reported local link.",
    )

    if browser_installed():
        results.report("PASS", "Playwright Chromium", "a Chromium browser cache was found")
    else:
        results.report(
            "WARN",
            "Playwright Chromium",
            "browser binary was not found; manual exploration remains available",
            "Run .\\scripts\\install-playwright.ps1 (PowerShell) or bash scripts/install-playwright.sh (Bash).",
        )

    results.report(
        "WARN",
        "Copilot and MCP capabilities",
        "account entitlement, IDE feature rollout, and Playwright MCP availability cannot be checked locally",
        "Complete workshop/setup/ENVIRONMENT.md; use its prompt-paste and manual-browser fallbacks.",
    )

    if args.deep and dotnet:
        commands = (
            ("Restore", [dotnet, "restore", "LegacyNoticeManager.sln"]),
            ("Build", [dotnet, "build", "LegacyNoticeManager.sln", "--no-restore"]),
            ("Unit tests", [dotnet, "test", "tests/Unit", "--no-build"]),
            ("Integration tests", [dotnet, "test", "tests/Integration", "--no-build"]),
            ("Reference tests", [dotnet, "test", "tests/Reference"]),
        )
        for label, command in commands:
            if not run_check(results, label, command, "Review the complete command output and resolve the reported dependency or test failure."):
                break
        else:
            if browser_installed():
                run_check(
                    results,
                    "End-to-end tests",
                    [dotnet, "test", "tests/EndToEnd"],
                    "Install Playwright Chromium or use the manual browser route.",
                )
            else:
                results.report("WARN", "End-to-end tests", "not run because Chromium is not installed", "Install Chromium before Lab 08.")

    print(f"\nReadiness summary: {results.failures} fail, {results.warnings} warning(s).")
    return 1 if results.failures else 0


if __name__ == "__main__":
    raise SystemExit(main())
