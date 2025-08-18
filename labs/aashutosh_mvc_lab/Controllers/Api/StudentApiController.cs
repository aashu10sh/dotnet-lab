namespace aashutosh_mvc_lab.Controllers.Api;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    // GET: api/students
    [HttpGet]
    public IActionResult GetAllStudents()
    {
        var students = new[]
        {
            new { Id = 1, Name = "John Doe", Email = "john@example.com" },
            new { Id = 2, Name = "Jane Smith", Email = "jane@example.com" }
        };
        return Ok(students);
    }

    // GET: api/students/5
    [HttpGet("{id}")]
    public IActionResult GetStudent(int id)
    {
        var student = new { Id = id, Name = $"Student {id}", Email = $"student{id}@example.com" };
        return Ok(student);
    }

    // POST: api/students
    [HttpPost]
    public IActionResult CreateStudent([FromBody] object student)
    {
        return Ok(new { Message = "Student created successfully", Data = student });
    }

    // PUT: api/students/5
    [HttpPut("{id}")]
    public IActionResult UpdateStudent(int id, [FromBody] object student)
    {
        return Ok(new { Message = $"Student {id} updated successfully", Data = student });
    }

    // DELETE: api/students/5
    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(int id)
    {
        return Ok(new { Message = $"Student {id} deleted successfully" });
    }
}