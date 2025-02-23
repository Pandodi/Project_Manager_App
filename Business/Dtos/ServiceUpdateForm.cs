using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class ServiceUpdateForm
{
    public int Id { get; set; }
    [Required]
    public string ServiceName { get; set; } = null!;
    [Required]
    public decimal PricePerHour { get; set; }
}


