using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class CustomerRegistrationForm
{
    [Required]
    public string CustomerName { get; set; } = null!;
    [Required]
    public string CustomerEmail { get; set; } = null!;
}


