using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class ProjectUpdateForm
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public int HoursWorked { get; set; }

    [Required]
    public int ProjectLeaderId { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [Required]
    public int ServiceId { get; set; }

    [Required]
    public int StatusTypeId { get; set; }
}
