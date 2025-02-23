using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class ProjectLeaderUpdateForm
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;
}


