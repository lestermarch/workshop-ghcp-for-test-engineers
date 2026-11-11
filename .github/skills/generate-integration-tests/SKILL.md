---
name: generate-integration-tests
description: Test HTTP, MVC, persistence, and transitions with isolated local synthetic data.
---
# Generate integration tests

Select an application boundary whose behaviour matters. Use test-host and isolated SQLite data; never call external services. Assert response status/content and persisted side effects, including audit when relevant. Cover one positive and one meaningful invalid/state boundary if justified. Prevent shared-state leakage and ordering dependence. Keep policy assumptions explicit. Run `dotnet test tests/Integration`; update traceability/evidence.
