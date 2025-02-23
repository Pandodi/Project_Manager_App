namespace Business.Dtos;


//Created a new project DTO to be able to view project details
public class ProjectDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string ServiceName { get; set; } = string.Empty;
    public string ProjectLeaderName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}
