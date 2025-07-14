using Microsoft.AspNetCore.Mvc;

namespace mvc_demo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
