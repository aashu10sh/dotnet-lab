using System.ComponentModel.DataAnnotations;

namespace UserCrudConsole.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;
        
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? UpdatedAt { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {FirstName} {LastName}, Email: {Email}, Phone: {PhoneNumber ?? "N/A"}, Created: {CreatedAt:yyyy-MM-dd HH:mm}";
        }
    }
}