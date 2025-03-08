using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InvoiceApp.Models;
using Microsoft.AspNetCore.Identity;
using InvoiceApp.Areas.Identity.Data;

namespace InvoiceApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        this._userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        if (User.Identity.IsAuthenticated)
        {
            //ViewData["UserID"] = _userManager.GetUserId(this.User);
            //var user = _userManager.GetUserAsync(User).Result
            var user = await _userManager.GetUserAsync(User);
            ViewData["UserID"] = user?.FirstName + " " + user?.LastName;
        }
        else
        {
            ViewData["UserID"] = "User ID";
        }
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
