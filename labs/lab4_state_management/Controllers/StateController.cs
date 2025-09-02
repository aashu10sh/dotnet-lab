namespace lab4_state_management.Controllers;

using Microsoft.AspNetCore.Mvc;

public class StateController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult SetSession()
    {
        HttpContext.Session.SetString("User", "Samrat");
        HttpContext.Session.SetInt32("Age", 20);
        ViewBag.Message = "Session Data Stored";
        return View("Result");
    }

    public IActionResult GetSession()
    {
        var user = HttpContext.Session.GetString("User");
        var age = HttpContext.Session.GetInt32("Age");
        ViewBag.Message = $"Session Data: {user}, Age: {age}";
        return View("Result");
    }

    public IActionResult HttpContextExample()
    {
        var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
        ViewBag.Message = $"Your IP Address from HttpContext: {ip}";
        return View("Result");
    }

    public IActionResult SetTempData()
    {
        TempData["Message"] = "This is TempData Example";
        return RedirectToAction("GetTempData");
    }

    public IActionResult GetTempData()
    {
        ViewBag.Message = TempData["Message"] as string;
        return View("Result");
    }

    public IActionResult SetCookie()
    {
        Response.Cookies.Append("User", "Samrat", new CookieOptions()
        {
            Expires = DateTime.Now.AddMinutes(5)
        });
        ViewBag.Message = "Cookie Stored!";
        return View("Result");
    }

    public IActionResult GetCookie()
    {
        var user = Request.Cookies["User"];
        ViewBag.Message = $"Cookie Value: {user}";
        return View("Result");
    }

    public IActionResult QueryStringExample(string name, int age)
    {
        ViewBag.Message = $"Query String Data: Name={name}, Age={age}";
        return View("Result");
    }

    [HttpGet]
    public IActionResult HiddenFieldForm()
    {
        return View();
    }

    [HttpPost]
    public IActionResult HiddenFieldForm(string hiddenValue)
    {
        ViewBag.Message = $"Hidden Field Value: {hiddenValue}";
        return View("Result");
    }
}
