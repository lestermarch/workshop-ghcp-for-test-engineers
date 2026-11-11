using System.ComponentModel.DataAnnotations;

namespace LegacyNoticeManager.Models;

public class Notice
{
    public int Id { get; set; }

    [Required, StringLength(90, MinimumLength = 5)]
    public string Title { get; set; } = "";

    public string? Description { get; set; }

    [Required]
    public string Region { get; set; } = "";

    [Required]
    public string Severity { get; set; } = "Low";

    [DataType(DataType.Date)]
    public DateTime EffectiveDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime ExpiryDate { get; set; }

    public string Status { get; set; } = "Draft";
    public string Owner { get; set; } = "";
    public bool Emergency { get; set; }
    public string? EmergencyExplanation { get; set; }
    public string? RejectionReason { get; set; }
    public DateTime? ApprovedAt { get; set; }
    public List<AuditRecord> AuditRecords { get; set; } = [];

    public DateTime PublicationDate()
    {
        var leadDays = Region == "Outer Reach" ? 5 : 2;
        if (Emergency) leadDays = 0;
        return EffectiveDate.AddDays(leadDays);
    }
}
