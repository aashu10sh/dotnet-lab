using Microsoft.AspNetCore.Mvc;

namespace yujon.Controllers;

public class DanceController: Controller
{
    
    private readonly ApplicationDbContext _context;

    public DanceController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        // var dancers = _context.Dancers.ToList();
        Console.WriteLine(_context.Dancers.ToList());
        ViewData["Name"] = "Yujon";
        return View();
    }
    
}