namespace aashutosh_mvc_lab.Areas.Students.Controller;

using Microsoft.AspNetCore.Mvc;

[Area("Student")]
[Route("Student/[controller]/[action]")]
public class ProfileController : Controller
{
    public IActionResult Index()
    {
        return Json("This is Student Area - Profile Controller");
    }

    public IActionResult Details()
    {
        return Json("Student Profile Details");
    }
}
