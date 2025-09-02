
namespace securing_dotnet.Models;

public class Todo
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required bool IsCompleted { get; set; }
}