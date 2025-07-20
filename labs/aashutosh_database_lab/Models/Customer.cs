namespace aashutosh_database_lab.Models;

public class Customer
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Company { get; set; }
    public required Guid AccountNumber { get; set; } = Guid.NewGuid();
    
    public int Balance { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string TOString()
    {
        return $"{Id}: {Name} {AccountNumber.ToString()} from {Company} has Salary {Balance}";
    }


}


