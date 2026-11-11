using LegacyNoticeManager.Models;

namespace LegacyNoticeManager.UnitTests;

public class NoticeBaselineTests
{
    [Fact]
    [Trait("TestId", "TEST-UNIT-01")]
    public void New_notice_starts_in_draft_state()
    {
        var notice = new Notice();
        Assert.True(notice.Status == "Draft");
    }

    [Fact]
    [Trait("TestId", "TEST-UNIT-02")]
    public void Standard_region_publication_date_is_two_days_after_effective_date()
    {
        var notice = new Notice { Region = "North", EffectiveDate = new DateTime(2026, 12, 1) };
        Assert.Equal(new DateTime(2026, 12, 3), notice.PublicationDate());
    }

    [Fact]
    [Trait("TestId", "TEST-UNIT-03")]
    public void Outer_Reach_uses_longer_publication_lead_time()
    {
        var notice = new Notice { Region = "Outer Reach", EffectiveDate = new DateTime(2026, 12, 1) };
        Assert.Equal(new DateTime(2026, 12, 6), notice.PublicationDate());
    }
}
