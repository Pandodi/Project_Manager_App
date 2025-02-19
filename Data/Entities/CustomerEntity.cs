
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class CustomerEntity
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(150)")]
    [Required]
    public string CustomerName { get; set; } = null!;

    [Column(TypeName = "nvarchar(150)")]
    [Required]
    public string CustomerEmail { get; set; } = null!;

    public ICollection<ProjectEntity> Projects { get; set; } = [];
}
