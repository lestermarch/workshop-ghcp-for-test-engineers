#!/usr/bin/env python3
"""Validate IDs and file references in the workshop's CSV traceability data."""

import csv
import re
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]


def read_csv(path: Path) -> list[dict[str, str]]:
    with path.open(encoding="utf-8-sig", newline="") as stream:
        return list(csv.DictReader(stream))


def main() -> int:
    errors: list[str] = []
    requirements = read_csv(ROOT / "evidence/requirements.csv")
    risks = read_csv(ROOT / "evidence/risks.csv")
    rows = read_csv(ROOT / "evidence/traceability.csv")

    requirement_ids = [row.get("requirement_id", "") for row in requirements]
    if not all(requirement_ids) or len(requirement_ids) != len(set(requirement_ids)):
        errors.append("Requirement IDs are missing or duplicated in evidence/requirements.csv.")
    risk_ids = {row.get("risk_id", "") for row in risks}
    if "" in risk_ids:
        errors.append("A risk ID is missing in evidence/risks.csv.")
    if len(risk_ids) != len(risks):
        errors.append("Risk IDs are duplicated in evidence/risks.csv.")

    req_refs = [row.get("requirement_id", "") for row in rows]
    test_refs = [row.get("test_id", "") for row in rows]
    if not all(req_refs) or len(req_refs) != len(set(req_refs)):
        errors.append("Traceability requirement IDs are missing or duplicated.")
    if not all(test_refs) or len(test_refs) != len(set(test_refs)):
        errors.append("Traceability test IDs are missing or duplicated.")
    if set(req_refs) - set(requirement_ids):
        errors.append(f"Unresolved requirements: {sorted(set(req_refs) - set(requirement_ids))}")
    if {row.get("risk_id", "") for row in rows} - risk_ids:
        errors.append("Traceability contains an unresolved risk ID.")

    test_code = "\n".join(
        path.read_text(encoding="utf-8-sig")
        for path in (ROOT / "tests").rglob("*.cs")
    )
    test_id_occurrences = re.findall(r'"(TEST-(?:UNIT|INT|E2E|REF)-\d+)"', test_code)
    defined_tests = set(test_id_occurrences)
    if len(test_id_occurrences) != len(defined_tests):
        errors.append("Test IDs are duplicated in test traits.")
    if set(test_refs) - defined_tests:
        errors.append(f"Test IDs not found in test traits: {sorted(set(test_refs) - defined_tests)}")
    if defined_tests - set(test_refs):
        errors.append(f"Test IDs missing traceability rows: {sorted(defined_tests - set(test_refs))}")

    for row in rows:
        for field in ("source_path", "test_path"):
            path = ROOT / row.get(field, "")
            if not path.is_file():
                errors.append(f"{field} does not exist: {row.get(field)}")
        evidence_id = row.get("evidence_id", "")
        evidence_matches = list((ROOT / "evidence").rglob(f"{evidence_id}*.md"))
        if not evidence_id or not evidence_matches:
            errors.append(f"Evidence record does not resolve: {evidence_id}")

    mandatory_evidence_fields = (
        "Activity ID", "Date and time", "Participant/reviewer", "Objective",
        "Tool or agent used", "Prompt file or skill used", "Context supplied",
        "Output summary", "Files created or changed", "Findings", "Assumptions",
        "Commands executed", "Test results", "Human decision", "Accepted amendments",
        "Rejected content", "Unresolved questions", "Residual risk", "Lesson learned",
    )
    evidence_files = list((ROOT / "evidence/examples").glob("EV-*.md"))
    if not evidence_files:
        errors.append("No completed synthetic evidence examples were found.")
    for path in evidence_files:
        content = path.read_text(encoding="utf-8-sig")
        for field in mandatory_evidence_fields:
            if field.lower() not in content.lower():
                errors.append(f"{path.relative_to(ROOT)} is missing mandatory field: {field}")

    if errors:
        print("\n".join(f"ERROR: {error}" for error in errors))
        return 1
    print(f"Traceability valid: {len(req_refs)} requirements/tests linked; evidence records resolve.")
    return 0


if __name__ == "__main__":
    sys.exit(main())
