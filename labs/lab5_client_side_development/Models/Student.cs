using System.ComponentModel.DataAnnotations;

namespace lab5_client_side_development.Models;
public class Student
{
    [Required(ErrorMessage = "Fullname is required")]
    public string Fullname { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Phone is required")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone must be 10 digits")]
    public string Phone { get; set; }
}