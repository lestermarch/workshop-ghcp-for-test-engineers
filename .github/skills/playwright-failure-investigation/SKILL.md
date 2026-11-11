---
name: playwright-failure-investigation
description: Reproduce and classify Playwright failures using test output, screenshots, traces, UI state, and requirement evidence.
---
# Playwright failure investigation

1. Reproduce the failure without changing code.
2. Read the assertion and browser/process output.
3. Inspect the screenshot and trace, if captured.
4. Revisit the exact UI state and repeat the action.
5. Inspect implementation only when browser evidence is insufficient.
6. Classify likely cause: application, automated test, environment, test data, or ambiguous requirement.
7. Record evidence, expected behaviour source, uncertainty, and reviewer.
8. Propose the smallest next action; do not make a speculative fix.
9. After the human decision and understood correction, rerun the focused test and relevant regression tests.

Never alter a test to match current behaviour without explaining whether that behaviour is an approved requirement.
