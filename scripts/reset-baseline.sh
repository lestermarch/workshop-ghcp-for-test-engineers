#!/usr/bin/env bash
set -euo pipefail
root="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
git_root="$(git -C "$root" rev-parse --show-toplevel 2>/dev/null)" || { echo "Reset requires a Git checkout." >&2; exit 1; }
[[ "$git_root" == "$root" ]] || { echo "Run reset from the repository root." >&2; exit 1; }
echo "This restores tracked src/, tests/, samples/, and docs/baseline/ from HEAD. Evidence and untracked files are preserved."
read -r -p "Continue? Type RESET to confirm: " answer
[[ "$answer" == "RESET" ]] || { echo "Reset cancelled."; exit 0; }
git -C "$root" restore --source=HEAD --worktree -- src tests samples docs/baseline
echo "Baseline paths restored. Evidence was not changed."
