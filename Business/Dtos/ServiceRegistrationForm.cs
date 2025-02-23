using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class ServiceRegistrationForm
{
    [Required]
    public string ServiceName { get; set; } = null!;
    [Required]
    public decimal PricePerHour { get; set; }
}


