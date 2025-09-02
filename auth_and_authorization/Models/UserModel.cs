using System.ComponentModel.DataAnnotations;

namespace auth_and_authorization.Models;

public class UserModel
{
    [Required]
    [MaxLength(20)]
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public int Id { get; set; }
}