#!/usr/bin/env python3
"""Validate workshop lab structure, required paths, and local Markdown links."""

from __future__ import annotations

import re
import sys
from pathlib import Path
from urllib.parse import unquote

ROOT = Path(__file__).resolve().parents[1]
LABS = [
    "setup-and-validation",
    "meet-the-legacy-application",
    "understand-copilot-customisation",
    "shape-copilot-with-instructions",
    "run-and-create-prompt-files",
    "work-with-specialist-agents",
    "discover-and-install-a-skill",
    "explore-the-application-in-a-browser",
    "create-and-run-playwright-tests",
    "investigate-review-and-record-evidence",
    "apply-the-approach-to-your-context",
]
REQUIRED_HEADINGS = (
    "## Purpose",
    "## Learning objectives",
    "## Starting state",
    "## Files involved",
    "## Tasks",
    "## Copyable prompts",
    "## Expected observations",
    "## Validation checkpoint",
    "## Discussion questions",
    "## Troubleshooting",
    "## Optional challenge",
    "## Completion criteria",
    "## Next lab",
)
LINK_PATTERN = re.compile(r"!?\[[^\]]*\]\(([^)]+)\)")


def main() -> int:
    errors: list[str] = []
    for index, suffix in enumerate(LABS):
        lab = ROOT / "workshop/labs" / f"lab-{index:02d}-{suffix}.md"
        checkpoint = ROOT / "workshop/checkpoints" / f"lab-{index:02d}.md"
        if not lab.is_file():
            errors.append(f"Missing lab: {lab.relative_to(ROOT)}")
            continue
        if not checkpoint.is_file():
            errors.append(f"Missing checkpoint: {checkpoint.relative_to(ROOT)}")
        content = lab.read_text(encoding="utf-8-sig")
        if not content.startswith(f"# Lab {index:02d} — "):
            errors.append(f"Lab title/number is invalid: {lab.relative_to(ROOT)}")
        if not re.search(r"\*\*Estimated duration:\*\*\s*\d+\s+minutes", content):
            errors.append(f"Lab duration is missing: {lab.relative_to(ROOT)}")
        for heading in REQUIRED_HEADINGS:
            if heading not in content:
                errors.append(f"{lab.relative_to(ROOT)} is missing section {heading}")
        if re.search(r"\bISSUE-\d{2}\b", content):
            errors.append(f"Participant lab contains a facilitator issue identifier: {lab.relative_to(ROOT)}")

    for source in (ROOT / "workshop").rglob("*.md"):
        text = source.read_text(encoding="utf-8-sig")
        for target in LINK_PATTERN.findall(text):
            target = target.strip().split()[0].strip("<>")
            if not target or target.startswith(("http://", "https://", "mailto:", "#")):
                continue
            path = unquote(target.split("#", 1)[0])
            if path and not (source.parent / path).resolve().exists():
                errors.append(f"Broken workshop link in {source.relative_to(ROOT)}: {target}")

    if errors:
        print("\n".join(f"FAIL: {error}" for error in errors))
        return 1
    print(f"PASS: {len(LABS)} labs, {len(LABS)} checkpoints, required lab sections, and local workshop links.")
    return 0


if __name__ == "__main__":
    sys.exit(main())
