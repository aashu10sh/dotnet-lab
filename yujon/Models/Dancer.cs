using System.ComponentModel.DataAnnotations;

namespace yujon.Models;

public class Dancer
{
    public required int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public required string Name { get; set; }

    public required string BestMove { get; set; }
}
