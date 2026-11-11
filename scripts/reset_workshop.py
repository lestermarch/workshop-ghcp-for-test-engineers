#!/usr/bin/env python3
"""Safely remove only known untracked files created by workshop exercises."""

from __future__ import annotations

import argparse
import shutil
import subprocess
import sys
from datetime import datetime
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
RESETTABLE = {
    "LAB-03": [".github/instructions/lab03-experiment.instructions.md"],
    "LAB-04": [".github/prompts/lab04-notice-form-validation.prompt.md"],
    "LAB-05": [".github/agents/boundary-value-analyst.agent.md"],
    "LAB-06": [".github/skills/workshop-installed-skill/SKILL.md"],
    "LAB-08": ["tests/EndToEnd/ParticipantPlaywrightTests.cs"],
}


def tracked(relative: str) -> bool:
    result = subprocess.run(
        ["git", "-C", str(ROOT), "ls-files", "--error-unmatch", "--", relative],
        capture_output=True,
        text=True,
        check=False,
    )
    return result.returncode == 0


def main() -> int:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("lab", choices=[*RESETTABLE, "all"])
    parser.add_argument("--confirm", action="store_true", help="back up and remove listed files")
    args = parser.parse_args()
    relatives = [path for paths in RESETTABLE.values() for path in paths] if args.lab == "all" else RESETTABLE[args.lab]
    existing = [path for path in relatives if (ROOT / path).is_file()]
    forbidden = [path for path in existing if tracked(path)]

    print("Files to back up and remove:")
    if existing:
        for path in existing:
            print(f"  {path}" + (" (tracked; protected)" if path in forbidden else ""))
    else:
        print("  none")
    if forbidden:
        print("FAIL: tracked files are protected; remove only your own changes manually after reviewing git diff.", file=sys.stderr)
        return 1
    if not args.confirm:
        print("No files changed. Rerun with --confirm to back up and remove these specific files.")
        return 0

    timestamp = datetime.now().strftime("%Y%m%d-%H%M%S")
    backup_root = ROOT / "workshop/participant-work/backups" / timestamp
    for relative in existing:
        source = ROOT / relative
        destination = backup_root / relative
        destination.parent.mkdir(parents=True, exist_ok=True)
        shutil.copy2(source, destination)
        source.unlink()
        print(f"Backed up and removed {relative}")

    for directory in (
        ROOT / ".github/skills/workshop-installed-skill",
    ):
        try:
            directory.rmdir()
        except OSError:
            pass
    print(f"Backup location: {backup_root.relative_to(ROOT) if existing else 'none'}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
