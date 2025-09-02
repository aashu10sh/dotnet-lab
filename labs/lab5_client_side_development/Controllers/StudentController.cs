using lab5_client_side_development.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab5_client_side_development.Controllers;

public class StudentController: Controller
{
    [HttpGet]
    public ViewResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(Student student)
    {
        if (ModelState.IsValid)
        {
            ViewBag.Message = "Student Submitted Succesfully";
            return View("Success", student);
        }
        return View(student);
    }
}