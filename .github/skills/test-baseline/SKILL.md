---
name: test-baseline
description: Run the existing test suite, record reproducible outcomes and coverage, and classify baseline test quality.
---
# Test baseline

Read test projects and scripts, restore only if required, then run unit, integration, and configured E2E tests separately. Record exact commands, SDK/runtime, pass/fail/skip, and failures. Collect coverage when available but treat it as diagnostic. Classify cases by behaviour, level, assertion strength, isolation, boundaries, and missing scenarios. Populate the test inventory; do not fix production behaviour during baseline capture.
