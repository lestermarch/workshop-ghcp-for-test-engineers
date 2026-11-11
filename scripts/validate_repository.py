#!/usr/bin/env python3
"""Check required repository assets, customisation counts, and relative Markdown links."""

import re
import sys
from pathlib import Path
from urllib.parse import unquote

ROOT = Path(__file__).resolve().parents[1]
REQUIRED = (
    "README.md", "QUICKSTART.md", "ARCHITECTURE.md", "SECURITY.md",
    "CONTRIBUTING.md", "WORKSHOP.md", "FACILITATOR-GUIDE.md", "GOLDEN-PATH.md",
    "TEST-STRATEGY.md", "GOVERNANCE.md", "EVIDENCE-GUIDE.md", "TRACEABILITY.md",
    "SCALING-RECOMMENDATION-TEMPLATE.md", "KNOWN-ISSUES.md",
    "COPILOT-CUSTOMISATION-GUIDE.md", ".github/copilot-instructions.md",
)


def main() -> int:
    errors: list[str] = []
    for relative in REQUIRED:
        if not (ROOT / relative).is_file():
            errors.append(f"Missing required file: {relative}")

    counts = {
        "agent profiles": len(list((ROOT / ".github/agents").glob("*.agent.md"))),
        "skills": len(list((ROOT / ".github/skills").glob("*/SKILL.md"))),
        "prompt files": len(list((ROOT / ".github/prompts").glob("*.prompt.md"))),
        "path instructions": len(list((ROOT / ".github/instructions").glob("*.instructions.md"))),
    }
    minimums = {"agent profiles": 12, "skills": 16, "prompt files": 28, "path instructions": 9}
    for label, count in counts.items():
        if count < minimums[label]:
            errors.append(f"Expected at least {minimums[label]} {label}; found {count}.")

    link_pattern = re.compile(r"!?\[[^\]]*\]\(([^)]+)\)")
    for source in ROOT.rglob("*.md"):
        if any(part in {".git", "bin", "obj", "participant-work"} for part in source.parts):
            continue
        text = source.read_text(encoding="utf-8-sig")
        for target in link_pattern.findall(text):
            target = target.strip().split()[0].strip("<>")
            if not target or target.startswith(("http://", "https://", "mailto:", "#")):
                continue
            destination = unquote(target.split("#", 1)[0])
            if destination and not (source.parent / destination).resolve().exists():
                errors.append(f"Broken relative link in {source.relative_to(ROOT)}: {target}")

    for skill in (ROOT / ".github/skills").glob("*/SKILL.md"):
        text = skill.read_text(encoding="utf-8-sig")
        expected_name = skill.parent.name
        if not text.startswith("---\n") or f"name: {expected_name}" not in text:
            errors.append(f"Invalid or mismatched skill metadata: {skill.relative_to(ROOT)}")
        if "description:" not in text.split("---", 2)[1] if text.startswith("---") else True:
            errors.append(f"Skill description missing: {skill.relative_to(ROOT)}")

    if errors:
        print("\n".join(f"ERROR: {error}" for error in errors))
        return 1
    print("Repository assets, customisation counts, skill metadata, and relative Markdown links are valid.")
    return 0


if __name__ == "__main__":
    sys.exit(main())
