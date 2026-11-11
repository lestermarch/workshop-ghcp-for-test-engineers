# Reset and recovery

Workshop exercises create only a small, known set of untracked participant assets. They do not overwrite the baseline prompts, agents, skills, tests, or evidence files.

From the repository root, preview files associated with a lab:

```shell
python scripts/reset_workshop.py LAB-03
```

The command is non-destructive unless `--confirm` is supplied. With confirmation, each existing participant-created file is copied into `workshop/participant-work/backups/` and then removed individually. It refuses to delete tracked files. Progress is kept separately and is not reset by lab cleanup.

Reset all known participant exercise files with `python scripts/reset_workshop.py all --confirm`. This still deletes only whitelisted file paths; it does not recursively remove directories. Remove a now-empty folder manually if desired. To reset progress, use `python scripts/workshop_progress.py reset` and confirm interactively.

For application state, stop the app and point `ConnectionStrings__NoticeDatabase` to a new synthetic database path. Do not delete an unidentified database or use `git clean`, `git reset`, or a broad restore command for workshop recovery.

See [lab-specific recovery](../troubleshooting/README.md) and each lab's reset section.
