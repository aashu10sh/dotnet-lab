namespace aashutosh_mvc_lab.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;

[Area("Admin")]
[Route("Admin/[controller]/[action]")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return Json("This is Admin Area - Home Controller");
    }

    public IActionResult Dashboard()
    {
        return Json("This is Admin Dashboard");
    }
}