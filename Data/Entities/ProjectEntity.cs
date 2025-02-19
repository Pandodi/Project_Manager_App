
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProjectEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(150)")]
    public string Title { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(500)")]
    public string Description { get; set; } = null!;

    [Required]
    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; }

    [Required]
    [Column(TypeName = "date")]
    public DateTime EndDate { get; set; }
    
    [Column(TypeName = "Money")]
    public decimal PricePerHour { get; set; }

    public int ProjectLeaderId { get; set; }
    public ProjectLeaderEntity ProjectLeader { get; set; } = null!;

    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; } = null!;

    public int ServiceId { get; set; }
    public ServiceEntity Service { get; set; } = null!;
    public int StatusTypeId { get; set; }
    public StatusTypeEntity StatusType { get; set; } = null!;
}
