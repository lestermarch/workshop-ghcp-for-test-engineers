---
name: exploratory-browser-testing
description: Explore the running Legacy Notice Manager as a black-box tester and turn browser observations into reviewable evidence.
---
# Exploratory browser testing

Start the app and open it with available browser tools. **Do not inspect implementation source until the initial browser observation record and journey map are written.**

Explore reconnaissance and navigation; list/search/details; happy path; invalid forms; minimum/maximum/whitespace and unusual values; date boundaries; state transitions; repeated submissions; back/forward navigation; visible errors; keyboard order/focus; labels, roles, names and validation messaging. Use only synthetic inputs.

For each action record page/journey, action, input, observed result, expected result if known, screenshot/trace reference, candidate requirement/risk/test, human assessment, and uncertainty. Distinguish observation from interpretation. Do not declare a defect without an authoritative requirement; ask an SME when expected behaviour is unclear. Inspect source only after the black-box phase, then compare and record discrepancies.
