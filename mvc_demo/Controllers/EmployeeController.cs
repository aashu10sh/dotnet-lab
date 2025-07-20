using Microsoft.AspNetCore.Mvc;

namespace mvc_demo.Controllers;

[Route("Employee")]
public class EmployeeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [Route("Details/{id?}")]
    public IActionResult Details(int id)
    {
        ViewData["id"] = id;
        return View();
    }

    [Route("~/Employee/Details/all")]
    public IActionResult Details()
    {
        ViewData["message"] = "Calling from the all route";
        return View();
    }
}