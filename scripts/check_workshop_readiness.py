#!/usr/bin/env python3
"""Check key files required to run the synthetic workshop locally."""

import csv
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
REQUIRED = (
    "LegacyNoticeManager.sln",
    "global.json",
    "src/LegacyNoticeManager/Program.cs",
    "src/LegacyNoticeManager/Data/NoticeDbContext.cs",
    "tests/Unit/LegacyNoticeManager.UnitTests.csproj",
    "tests/Integration/LegacyNoticeManager.IntegrationTests.csproj",
    "tests/EndToEnd/LegacyNoticeManager.EndToEndTests.csproj",
    "tests/Reference/LegacyNoticeManager.ReferenceTests.csproj",
    "docs/baseline/OVERVIEW.md",
    "WORKSHOP.md",
    "workshop/README.md",
    "workshop/setup/ENVIRONMENT.md",
    "workshop/labs/lab-10-apply-the-approach-to-your-context.md",
    "workshop/facilitator/AGENDA.md",
    "scripts/workshop_ready.py",
    "scripts/check_workshop.py",
    "scripts/workshop_progress.py",
    ".github/prompts/01-map-the-application.prompt.md",
    "evidence/templates/AI-ACTIVITY-TEMPLATE.md",
)


def main() -> int:
    errors = [f"Missing: {name}" for name in REQUIRED if not (ROOT / name).is_file()]
    with (ROOT / "reference-outcomes/seeded-issues.csv").open(encoding="utf-8-sig", newline="") as stream:
        issues = list(csv.DictReader(stream))
    if len(issues) < 12:
        errors.append(f"Expected at least 12 facilitator issues, found {len(issues)}.")
    if len({row.get("issue_id") for row in issues}) != len(issues):
        errors.append("Facilitator issue IDs are not unique.")
    if not (ROOT / "workshop/checkpoints/lab-10.md").is_file():
        errors.append("The final lab checkpoint is missing.")
    required_categories = {
        "functional correctness", "missing validation", "date and time handling",
        "state-transition control", "error handling", "auditability",
        "duplicate detection", "accessibility", "security hygiene", "observability",
        "concurrency", "documentation mismatch", "missing unit coverage",
        "missing integration coverage", "missing end-to-end coverage",
    }
    categories = {row.get("category", "") for row in issues}
    if required_categories - categories:
        errors.append(f"Issue categories missing: {sorted(required_categories - categories)}")
    required_columns = {
        "issue_id", "category", "component", "description", "why_it_matters",
        "expected_discovery_method", "expected_test_level", "expected_severity",
        "likely_false_assumptions", "acceptable_remediation_direction",
        "fix_during_workshop", "validation_method",
    }
    if issues and required_columns - set(issues[0]):
        errors.append(f"Issue manifest missing columns: {sorted(required_columns - set(issues[0]))}")
    if errors:
        print("\n".join(f"ERROR: {error}" for error in errors))
        return 1
    print(f"Workshop readiness assets found; {len(issues)} facilitator issues are uniquely identified.")
    return 0


if __name__ == "__main__":
    sys.exit(main())
