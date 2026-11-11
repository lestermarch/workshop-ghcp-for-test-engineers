#!/usr/bin/env bash
set -euo pipefail
root="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
cd "$root"
dotnet restore LegacyNoticeManager.sln
dotnet build LegacyNoticeManager.sln --no-restore
bash scripts/install-playwright.sh
dotnet test LegacyNoticeManager.sln --no-build --collect:"XPlat Code Coverage" --logger "console;verbosity=minimal"
dotnet test tests/Reference/LegacyNoticeManager.ReferenceTests.csproj --collect:"XPlat Code Coverage" --logger "console;verbosity=minimal"
dotnet format LegacyNoticeManager.sln --verify-no-changes --no-restore
dotnet format tests/Reference/LegacyNoticeManager.ReferenceTests.csproj --verify-no-changes --no-restore
python3 scripts/validate_repository.py
python3 scripts/check_workshop.py
python3 scripts/validate_traceability.py
python3 scripts/check_workshop_readiness.py
python3 scripts/check_secrets.py
