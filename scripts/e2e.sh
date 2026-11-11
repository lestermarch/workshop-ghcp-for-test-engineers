#!/usr/bin/env bash
set -euo pipefail
mode="${1:-headless}"
root="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
cd "$root"
if [[ "$mode" == "report" ]]; then
  python3 scripts/create_e2e_report.py
  exit $?
fi
case "$mode" in
  headless) export E2E_HEADLESS=true; unset E2E_DEBUG ;;
  headed) export E2E_HEADLESS=false; unset E2E_DEBUG ;;
  debug) export E2E_HEADLESS=false E2E_DEBUG=true ;;
  *) echo "Usage: $0 [headless|headed|debug|report]" >&2; exit 2 ;;
esac
set +e
dotnet test tests/EndToEnd/LegacyNoticeManager.EndToEndTests.csproj \
  --logger "trx;LogFileName=e2e.trx" --results-directory TestResults/E2E
test_status=$?
set -e
python3 scripts/create_e2e_report.py
exit "$test_status"
