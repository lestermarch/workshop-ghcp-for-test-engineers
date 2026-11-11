namespace LegacyNoticeManager.Models;

public class AuditRecord
{
    public int Id { get; set; }
    public int NoticeId { get; set; }
    public Notice? Notice { get; set; }
    public string Event { get; set; } = "";
    public string Actor { get; set; } = "";
    public DateTime OccurredAt { get; set; }
}
