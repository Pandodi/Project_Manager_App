using Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class Project
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int HoursWorked { get; set; }
    public decimal TotalCost { get; set; }
    public int ProjectLeaderId { get; set; }
    public int CustomerId { get; set; }
    public int ServiceId { get; set; }
    public int StatusTypeId { get; set; }
}
