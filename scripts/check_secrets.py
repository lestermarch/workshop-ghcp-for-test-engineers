#!/usr/bin/env python3
"""Detect a small set of high-confidence secret formats; not a complete security scanner."""

import re
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
PATTERNS = (
    re.compile(r"-----BEGIN (?:RSA |EC |OPENSSH )?PRIVATE KEY-----"),
    re.compile(r"\bAKIA[0-9A-Z]{16}\b"),
    re.compile(r"\bgh[pousr]_[A-Za-z0-9]{30,}\b"),
    re.compile(r"\bgithub_pat_[A-Za-z0-9_]{30,}\b"),
)
SKIP = {".git", "bin", "obj", ".vs", "TestResults"}


def main() -> int:
    findings: list[str] = []
    for path in ROOT.rglob("*"):
        if not path.is_file() or any(part in SKIP for part in path.parts):
            continue
        if path.suffix.lower() in {".db", ".dll", ".exe", ".pdb", ".png", ".jpg", ".zip"}:
            continue
        try:
            content = path.read_text(encoding="utf-8-sig")
        except (UnicodeDecodeError, OSError):
            continue
        for number, line in enumerate(content.splitlines(), start=1):
            if any(pattern.search(line) for pattern in PATTERNS):
                findings.append(f"{path.relative_to(ROOT)}:{number}")
    if findings:
        print("High-confidence secret-like material detected at:")
        print("\n".join(findings))
        return 1
    print("No high-confidence secret formats detected (this is not a full secret scan).")
    return 0


if __name__ == "__main__":
    sys.exit(main())
