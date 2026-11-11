# Synthetic workshop data

The application loads its repeatable fictional seed records from `NoticeDbContext.OnModelCreating`. Do not add a second disconnected seed source. Manual and automated test cases should use synthetic titles and dates; use `evidence/traceability.csv` to link test IDs to risks and evidence.
