# Example reviewed requirements (fictional)

> Facilitator example only. Confidence describes evidence in this repository, not real-world policy.

| ID | Candidate statement | Evidence | Confidence | Status |
|---|---|---|---|---|
| REQ-01 | A notice has a title, region, severity, effective and expiry dates, and a status. | `src/LegacyNoticeManager/Models/Notice.cs` | High for implementation; policy unconfirmed | Accepted as observed data shape |
| REQ-02 | The implementation permits equal effective and expiry dates. | Create validation compares dates with `<`. | High | Accepted as observed behaviour; policy question remains |
| REQ-03 | Outer Reach uses a longer publication lead time than other regions. | `Notice.PublicationDate()` | High for code | Deferred for SME policy confirmation |
| REQ-04 | Only approved notices can be exported. | `NoticesController.Export` | High | Accepted as observed workflow |
