
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProjectLeaderEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(150)")]
    public string Name { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(150)")]
    public string Email { get; set; } = null!;

    public ICollection<ProjectEntity> Projects { get; set; } = [];

}
