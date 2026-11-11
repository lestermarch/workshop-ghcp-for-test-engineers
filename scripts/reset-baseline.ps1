$ErrorActionPreference = "Stop"
$root = Split-Path -Parent $PSScriptRoot
$gitRoot = git -C $root rev-parse --show-toplevel 2>$null
if ($LASTEXITCODE -ne 0 -or -not $gitRoot) { throw "Reset requires a Git checkout." }
if ((Resolve-Path $gitRoot).Path -ne (Resolve-Path $root).Path) { throw "Run reset from the repository root." }
Write-Host "This restores tracked src/, tests/, samples/, and docs/baseline/ from HEAD. Evidence and untracked files are preserved."
$answer = Read-Host "Continue? Type RESET to confirm"
if ($answer -cne "RESET") { Write-Host "Reset cancelled."; exit 0 }
git -C $root restore --source=HEAD --worktree -- src tests samples docs/baseline
if ($LASTEXITCODE -ne 0) { throw "Git restore failed." }
Write-Host "Baseline paths restored. Evidence was not changed."
