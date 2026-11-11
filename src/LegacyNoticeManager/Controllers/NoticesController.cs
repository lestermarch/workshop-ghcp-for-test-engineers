using LegacyNoticeManager.Data;
using LegacyNoticeManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LegacyNoticeManager.Controllers;

public class NoticesController(NoticeDbContext db) : Controller
{
    public async Task<IActionResult> Index(string? search)
    {
        ViewBag.Search = search;
        var notices = db.Notices.AsNoTracking();
        if (!string.IsNullOrEmpty(search))
        {
            notices = notices.Where(n => n.Title.Contains(search) || n.Region == search);
        }

        return View(await notices.OrderByDescending(n => n.EffectiveDate).ToListAsync());
    }

    public IActionResult Create() => View(new Notice { EffectiveDate = DateTime.Today, ExpiryDate = DateTime.Today.AddDays(30) });

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Notice notice)
    {
        ModelState.Remove(nameof(notice.Owner));
        notice.Owner = string.IsNullOrWhiteSpace(notice.Owner) ? "Workshop user" : notice.Owner;

        if (notice.ExpiryDate.Date < notice.EffectiveDate.Date)
        {
            ModelState.AddModelError(nameof(notice.ExpiryDate), "Expiry must be on or after the effective date.");
        }

        if (notice.Severity == "High" && string.IsNullOrWhiteSpace(notice.Description))
        {
            ModelState.AddModelError(nameof(notice.Description), "A description is required for high-severity notices.");
        }

        if (notice.Emergency && string.IsNullOrWhiteSpace(notice.EmergencyExplanation))
        {
            ModelState.AddModelError(nameof(notice.EmergencyExplanation), "Explain why the emergency timing rule applies.");
        }

        if (await db.Notices.AnyAsync(n => n.Title == notice.Title))
        {
            ModelState.AddModelError(nameof(notice.Title), "A notice with this title already exists.");
        }

        if (!ModelState.IsValid)
        {
            return View(notice);
        }
        notice.Status = "Draft";
        notice.Status = "Draft";
        db.Notices.Add(notice);
        db.AuditRecords.Add(new AuditRecord { Notice = notice, Event = "Created", Actor = notice.Owner, OccurredAt = DateTime.UtcNow });
        await db.SaveChangesAsync();
        return RedirectToAction(nameof(Details), new { id = notice.Id });
    }

    public async Task<IActionResult> Details(int id)
    {
        var notice = await db.Notices.Include(n => n.AuditRecords).FirstOrDefaultAsync(n => n.Id == id);
        return notice is null ? NotFound() : View(notice);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var notice = await db.Notices.FindAsync(id);
        if (notice is null) return NotFound();
        if (notice.Status is not ("Draft" or "Rejected")) return BadRequest("Only draft or rejected notices can be edited.");
        return View(notice);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Notice updated)
    {
        var notice = await db.Notices.FindAsync(id);
        if (notice is null) return NotFound();
        if (notice.Status is not ("Draft" or "Rejected")) return BadRequest("Only draft or rejected notices can be edited.");
        if (!ModelState.IsValid) return View(updated);

        notice.Title = updated.Title;
        notice.Description = updated.Description;
        notice.Region = updated.Region;
        notice.Severity = updated.Severity;
        notice.EffectiveDate = updated.EffectiveDate;
        notice.ExpiryDate = updated.ExpiryDate;
        notice.Emergency = updated.Emergency;
        notice.EmergencyExplanation = updated.EmergencyExplanation;
        db.AuditRecords.Add(new AuditRecord { NoticeId = id, Event = "Edited", Actor = notice.Owner, OccurredAt = DateTime.UtcNow });
        await db.SaveChangesAsync();
        return RedirectToAction(nameof(Details), new { id });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Approve(int id)
    {
        var notice = await db.Notices.FindAsync(id);
        if (notice is null) return NotFound();
        if (notice.Status is not ("Draft" or "Rejected")) return BadRequest("This notice cannot be approved from its current state.");
        if (string.IsNullOrWhiteSpace(notice.Title) || string.IsNullOrWhiteSpace(notice.Region) || string.IsNullOrWhiteSpace(notice.Severity))
        {
            ModelState.AddModelError(string.Empty, "Complete all mandatory fields before approval.");
            return RedirectToAction(nameof(Details), new { id });
        }

        notice.Status = "Approved";
        notice.ApprovedAt = DateTime.UtcNow;
        await db.SaveChangesAsync();
        return RedirectToAction(nameof(Details), new { id });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Reject(int id, string reason)
    {
        var notice = await db.Notices.FindAsync(id);
        if (notice is null) return NotFound();
        if (string.IsNullOrWhiteSpace(reason)) return BadRequest("A rejection reason is required.");
        notice.Status = "Rejected";
        notice.RejectionReason = reason;
        db.AuditRecords.Add(new AuditRecord { NoticeId = id, Event = "Rejected: " + reason, Actor = "Workshop user", OccurredAt = DateTime.UtcNow });
        await db.SaveChangesAsync();
        return RedirectToAction(nameof(Details), new { id });
    }

    public async Task<IActionResult> Export(int id)
    {
        var notice = await db.Notices.FindAsync(id);
        if (notice is null) return NotFound();
        if (notice.Status != "Approved") return BadRequest("Only approved notices can be exported.");

        var csv = $"Id,Title,Region,Severity,EffectiveDate{Environment.NewLine}{notice.Id},\"{notice.Title}\",{notice.Region},{notice.Severity},{notice.EffectiveDate:yyyy-MM-dd}";
        return File(System.Text.Encoding.UTF8.GetBytes(csv), "text/csv", $"notice-{id}.csv");
    }
}
