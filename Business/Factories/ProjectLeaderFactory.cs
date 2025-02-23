using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class ProjectLeaderFactory
{
    public static ProjectLeaderRegistrationForm Create() => new();

    public static ProjectLeaderEntity Create(ProjectLeaderRegistrationForm form) => new()
    {
        Name = form.Name,
        Email = form.Email
    };

    public static ProjectLeader Create(ProjectLeaderEntity projectLeaderEntity) => new()
    {
        Id = projectLeaderEntity.Id,
        Name = projectLeaderEntity.Name,
        Email = projectLeaderEntity.Email
    };

    public static ProjectLeaderUpdateForm Create(ProjectLeader projectLeader) => new()
    {
        Id = projectLeader.Id,
        Name = projectLeader.Name,
        Email = projectLeader.Email
    };

    public static ProjectLeaderEntity Create(ProjectLeaderUpdateForm updateForm) => new()
    {
        Id = updateForm.Id,
        Name = updateForm.Name,
        Email = updateForm.Email
    };
}
