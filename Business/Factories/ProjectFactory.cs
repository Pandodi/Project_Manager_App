using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class ProjectFactory
{
    public static ProjectRegistrationForm Create() => new();

    public static ProjectEntity Create(ProjectRegistrationForm form) => new()
    {
        Title = form.Title,
        Description = form.Description,
        StartDate = form.StartDate,
        EndDate = form.EndDate,
        HoursWorked = form.HoursWorked,
        ProjectLeaderId = form.ProjectLeaderId,
        CustomerId = form.CustomerId,
        ServiceId = form.ServiceId,
        StatusTypeId = form.StatusTypeId
    };

    public static Project Create(ProjectEntity projectEntity) => new()
    {
        Id = projectEntity.Id,
        Title = projectEntity.Title,
        Description = projectEntity.Description,
        StartDate = projectEntity.StartDate,
        EndDate = projectEntity.EndDate,
        HoursWorked = projectEntity.HoursWorked,
        ProjectLeaderId = projectEntity.ProjectLeaderId,
        CustomerId = projectEntity.CustomerId,
        ServiceId = projectEntity.ServiceId,
        StatusTypeId = projectEntity.StatusTypeId
    };

    public static ProjectUpdateForm Create(Project project) => new()
    {
        Id = project.Id,
        Title = project.Title,
        Description = project.Description,
        StartDate = project.StartDate,
        EndDate = project.EndDate,
        HoursWorked = project.HoursWorked,
        ProjectLeaderId = project.ProjectLeaderId,
        CustomerId = project.CustomerId,
        ServiceId = project.ServiceId,
        StatusTypeId = project.StatusTypeId
    };

    public static ProjectEntity Create(ProjectUpdateForm updateForm) => new()
    {
        Id = updateForm.Id,
        Title = updateForm.Title,
        Description = updateForm.Description,
        StartDate = updateForm.StartDate,
        EndDate = updateForm.EndDate,
        HoursWorked = updateForm.HoursWorked,
        ProjectLeaderId = updateForm.ProjectLeaderId,
        CustomerId = updateForm.CustomerId,
        ServiceId = updateForm.ServiceId,
        StatusTypeId = updateForm.StatusTypeId
    };

    public static ProjectDTO Read(ProjectEntity entity) => new()
    {
        Id = entity.Id,
        Title = entity.Title,
        Description = entity.Description,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,
        CustomerName = entity.Customer.CustomerName,
        ServiceName = entity.Service.ServiceName,
        ProjectLeaderName = entity.ProjectLeader.Name,
        Status = entity.StatusType.StatusName
    };
}
