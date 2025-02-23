using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class CustomerUpdateForm
{
    public int Id { get; set; }
    [Required]
    public string CustomerName { get; set; } = null!;
    [Required]
    public string CustomerEmail { get; set; } = null!;
}


