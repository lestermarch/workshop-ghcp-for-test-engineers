#!/usr/bin/env bash
set -euo pipefail
root="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
cd "$root"
dotnet build tests/EndToEnd/LegacyNoticeManager.EndToEndTests.csproj
installer="tests/EndToEnd/bin/Debug/net10.0/playwright.sh"
[[ -f "$installer" ]] || { echo "Playwright installer not found at $installer" >&2; exit 1; }
bash "$installer" install chromium
