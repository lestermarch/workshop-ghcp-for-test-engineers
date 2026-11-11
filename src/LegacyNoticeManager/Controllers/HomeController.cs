using LegacyNoticeManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace LegacyNoticeManager.Controllers;

public class HomeController : Controller
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel { RequestId = HttpContext.TraceIdentifier });
}
