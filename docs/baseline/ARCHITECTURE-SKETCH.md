# Architecture sketch (baseline)

```mermaid
flowchart LR
  User --> MVC[Web application]
  MVC --> Data[Local data store]
```

The original design notes do not show controller responsibilities or audit storage.
