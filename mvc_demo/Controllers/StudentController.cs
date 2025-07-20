using Microsoft.AspNetCore.Mvc;

namespace mvc_demo.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

}