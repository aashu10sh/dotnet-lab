using Microsoft.AspNetCore.Mvc;

namespace aashutosh_mvc_lab.Controllers;

[Route("Demo")]
public class DemoController: Controller
{
    [HttpGet("Example")]
    public IActionResult Example()
    {
        return Json("This is a URL Attribute Router.");
    }
    
}