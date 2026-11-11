using LegacyNoticeManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LegacyNoticeManager.Data;

public class NoticeDbContext(DbContextOptions<NoticeDbContext> options) : DbContext(options)
{
    public DbSet<Notice> Notices => Set<Notice>();
    public DbSet<AuditRecord> AuditRecords => Set<AuditRecord>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Notice>().HasData(
            new Notice { Id = 1, Title = "Temporary buoy relocation", Description = "A training notice for the North region.", Region = "North", Severity = "Low", EffectiveDate = new DateTime(2026, 12, 1), ExpiryDate = new DateTime(2026, 12, 20), Status = "Approved", Owner = "Demo operator", ApprovedAt = new DateTime(2026, 11, 1) },
            new Notice { Id = 2, Title = "Training channel inspection", Description = "Synthetic example record.", Region = "Outer Reach", Severity = "Medium", EffectiveDate = new DateTime(2026, 12, 10), ExpiryDate = new DateTime(2026, 12, 22), Status = "Draft", Owner = "Demo operator" },
            new Notice { Id = 3, Title = "Seasonal marker advisory", Description = "Synthetic example record.", Region = "South", Severity = "High", EffectiveDate = new DateTime(2026, 12, 15), ExpiryDate = new DateTime(2026, 12, 30), Status = "Rejected", Owner = "Demo operator", RejectionReason = "Add a clearer description." });
    }
}
