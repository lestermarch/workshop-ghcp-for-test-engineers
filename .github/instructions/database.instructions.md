---
applyTo: "src/LegacyNoticeManager/Data/**,src/LegacyNoticeManager/Models/**"
---
# Database and models

Applies to persistence and entity model changes. Keep seed values synthetic. Note that baseline schema creation uses `EnsureCreated`; do not present it as a migration strategy. Check constraints, nullability, date semantics, concurrency, and audit effects. Preserve intended baseline behaviour until tests and policy review support change. Update test and evidence traceability.
