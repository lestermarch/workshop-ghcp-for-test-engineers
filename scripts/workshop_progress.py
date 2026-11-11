#!/usr/bin/env python3
"""Track local workshop progress without an external learning platform."""

from __future__ import annotations

import argparse
import json
import sys
from datetime import datetime, timezone
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
STATE = ROOT / "workshop/.progress.json"
LAB_IDS = [f"LAB-{index:02d}" for index in range(11)]
CHALLENGE_LEVELS = ("explore", "apply", "extend")


def load_state() -> dict:
    if not STATE.exists():
        return {"completed_labs": [], "completed_challenges": [], "updated_at": None}
    try:
        data = json.loads(STATE.read_text(encoding="utf-8"))
    except (OSError, json.JSONDecodeError) as error:
        raise ValueError(f"Cannot read {STATE.relative_to(ROOT)}: {error}") from error
    if not isinstance(data, dict):
        raise ValueError("Progress data must be a JSON object.")
    data.setdefault("completed_labs", [])
    data.setdefault("completed_challenges", [])
    if not isinstance(data["completed_labs"], list) or set(data["completed_labs"]) - set(LAB_IDS):
        raise ValueError("Progress data contains invalid completed lab identifiers.")
    if not isinstance(data["completed_challenges"], list) or not all(
        isinstance(item, str) for item in data["completed_challenges"]
    ):
        raise ValueError("Progress data contains invalid challenge entries.")
    return data


def save_state(data: dict) -> None:
    data["updated_at"] = datetime.now(timezone.utc).isoformat(timespec="seconds")
    STATE.parent.mkdir(parents=True, exist_ok=True)
    STATE.write_text(json.dumps(data, indent=2) + "\n", encoding="utf-8")


def next_lab(completed: list[str]) -> str:
    return next((lab for lab in LAB_IDS if lab not in completed), "Complete")


def main() -> int:
    parser = argparse.ArgumentParser(description=__doc__)
    subparsers = parser.add_subparsers(dest="action", required=True)
    subparsers.add_parser("show", help="show completed labs and the next checkpoint")
    complete = subparsers.add_parser("complete", help="mark one lab complete")
    complete.add_argument("lab", choices=LAB_IDS)
    challenge = subparsers.add_parser("challenge", help="record an optional challenge by level and short slug")
    challenge.add_argument("level", choices=CHALLENGE_LEVELS)
    challenge.add_argument("slug")
    reset = subparsers.add_parser("reset", help="clear local progress after confirmation")
    reset.add_argument("--confirm", action="store_true", help="skip the interactive RESET confirmation")
    args = parser.parse_args()

    try:
        state = load_state()
    except ValueError as error:
        print(f"FAIL: {error}", file=sys.stderr)
        return 1

    completed_labs = sorted(set(state["completed_labs"]), key=LAB_IDS.index)
    if args.action == "show":
        print(f"Completed labs: {', '.join(completed_labs) if completed_labs else 'none'}")
        print(f"Completed challenges: {', '.join(state['completed_challenges']) if state['completed_challenges'] else 'none'}")
        current = next_lab(completed_labs)
        remaining = [lab for lab in LAB_IDS if lab not in completed_labs]
        print(f"Current checkpoint: {current}")
        print(f"Remaining labs: {', '.join(remaining) if remaining else 'none'}")
        return 0

    if args.action == "complete":
        if args.lab not in completed_labs:
            completed_labs.append(args.lab)
        state["completed_labs"] = sorted(completed_labs, key=LAB_IDS.index)
    elif args.action == "challenge":
        entry = f"{args.level}:{args.slug}"
        if entry not in state["completed_challenges"]:
            state["completed_challenges"].append(entry)
    else:
        if not args.confirm:
            answer = input("Clear local workshop progress only? Type RESET to confirm: ")
            if answer != "RESET":
                print("Progress reset cancelled.")
                return 0
        state = {"completed_labs": [], "completed_challenges": [], "updated_at": None}

    try:
        save_state(state)
    except OSError as error:
        print(f"FAIL: Could not save progress: {error}", file=sys.stderr)
        return 1
    print(f"Progress saved. Current checkpoint: {next_lab(state['completed_labs'])}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
