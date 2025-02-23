using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class ProjectLeaderService(IProjectLeaderRepository projectLeaderRepository)
    : BaseService<IProjectLeaderRepository, ProjectLeaderEntity>(projectLeaderRepository), IProjectLeaderService
{
    public async Task<bool> CreateProjectLeaderAsync(ProjectLeaderRegistrationForm form)
    {
        if (await _repository.ExistsAsync(x => x.Email == form.Email))
            return false;

        return await CreateAsync(ProjectLeaderFactory.Create(form));
    }

    public async Task<IEnumerable<ProjectLeader>> GetAllProjectLeadersAsync()
    {
        var entities = await _repository.GetAllAsync();
        var projectLeaders = entities.Select(ProjectLeaderFactory.Create);

        return projectLeaders ?? [];
    }

    public async Task<ProjectLeader?> GetProjectLeaderByIdAsync(int id)
    {
        var entity = await _repository.GetAsync(x => x.Id == id);
        var projectLeader = ProjectLeaderFactory.Create(entity!);
        return projectLeader ?? null!;
    }

    public async Task<bool> UpdateProjectLeaderAsync(ProjectLeaderUpdateForm form)
    {
        //For some reason when using a factory here... it doesn't want to work with Entity Framework

        var existingEntity = await _repository.GetAsync(x => x.Id == form.Id);

        if (existingEntity == null)
        {
            return false;
        }

        existingEntity.Name = form.Name;
        existingEntity.Email = form.Email;

        return await UpdateAsync(existingEntity);
    }

    public async Task<bool> DeleteProjectLeaderAsync(int id)
    {
        return await DeleteAsync(x => x.Id == id);
    }

}
