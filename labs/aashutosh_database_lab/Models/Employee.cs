namespace aashutosh_database_lab.Models;

public class Employee
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Company { get; set; }
    public int Salary { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string TOString()
    {
        return $"{Id}: {FirstName} {LastName} from {Company} has Salary {Salary}";
    }

}