
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ServiceEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(150)")]
    public string ServiceName { get; set; } = null!;

    [Required]
    public decimal PricePerHour { get; set; }
    public ICollection<ProjectEntity> Projects { get; set; } = [];
}
