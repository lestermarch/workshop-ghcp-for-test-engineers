#!/usr/bin/env python3
"""Create a small offline HTML summary from the .NET Playwright TRX result."""

import argparse
import html
import sys
import xml.etree.ElementTree as ET
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]


def main() -> int:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--trx", type=Path, default=ROOT / "TestResults/E2E/e2e.trx")
    parser.add_argument("--output", type=Path, default=ROOT / "TestResults/E2E/index.html")
    args = parser.parse_args()
    trx_path = args.trx if args.trx.is_absolute() else ROOT / args.trx
    output_path = args.output if args.output.is_absolute() else ROOT / args.output
    if not trx_path.is_file():
        print(f"TRX file not found: {trx_path}", file=sys.stderr)
        return 1

    tree = ET.parse(trx_path)
    test_results = [element for element in tree.iter() if element.tag.endswith("UnitTestResult")]
    rows = []
    for result in test_results:
        name = result.attrib.get("testName", "Unknown test")
        outcome = result.attrib.get("outcome", "Unknown")
        duration = result.attrib.get("duration", "")
        error = next((element.text for element in result.iter() if element.tag.endswith("Message") and element.text), "")
        rows.append(
            "<tr><td>{}</td><td>{}</td><td>{}</td><td><pre>{}</pre></td></tr>".format(
                html.escape(name), html.escape(outcome), html.escape(duration), html.escape(error)
            )
        )

    artifacts = ROOT / "TestResults/BrowserArtifacts"
    artifact_links = []
    if artifacts.is_dir():
        for artifact in sorted(artifacts.glob("*")):
            relative = artifact.relative_to(ROOT).as_posix()
            artifact_links.append(f'<li><a href="../../{html.escape(relative)}">{html.escape(artifact.name)}</a></li>')

    output_path.parent.mkdir(parents=True, exist_ok=True)
    output_path.write_text(
        """<!doctype html>
<html lang="en"><meta charset="utf-8"><title>Playwright test report</title>
<style>body{{font:16px system-ui;max-width:1100px;margin:2rem auto;padding:0 1rem}}
table{{border-collapse:collapse;width:100%}}th,td{{border:1px solid #888;padding:.5rem;text-align:left}}
th{{background:#e8edf1}}pre{{white-space:pre-wrap;max-width:55rem}}</style>
<h1>Playwright test report</h1>
<p>Generated from {trx}; this summary does not replace review of test evidence.</p>
<table><thead><tr><th>Test</th><th>Outcome</th><th>Duration</th><th>Failure details</th></tr></thead>
<tbody>{rows}</tbody></table>
<h2>Browser artifacts</h2><ul>{artifacts}</ul></html>
""".format(
            trx=html.escape(trx_path.relative_to(ROOT).as_posix()) if trx_path.is_relative_to(ROOT) else html.escape(trx_path.name),
            rows="".join(rows),
            artifacts="".join(artifact_links) or "<li>No failure artifacts captured.</li>",
        ),
        encoding="utf-8",
    )
    print(f"HTML report written to {output_path}")
    return 0


if __name__ == "__main__":
    sys.exit(main())
