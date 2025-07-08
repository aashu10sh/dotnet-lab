using System.ComponentModel.DataAnnotations;


namespace database_with_migrations.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return $"ID : {Id}, Name: ${FirstName}  {LastName}, Email: {Email}, PhoneNumber: {PhoneNumber}, createdAt: {CreatedAt}";
        }
    }
}