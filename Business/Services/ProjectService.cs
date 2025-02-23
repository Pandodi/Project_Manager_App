using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository)
    : BaseService<IProjectRepository, ProjectEntity>(projectRepository), IProjectService
{

    public async Task<bool> CreateProjectAsync(ProjectRegistrationForm form)
    {
        if (await _repository.ExistsAsync(x => x.Title == form.Title))
            return false;

        return await CreateAsync(ProjectFactory.Create(form));
    }

    public async Task<IEnumerable<Project>> GetAllProjectsAsync()
    {
        var entities = await _repository.GetAllAsync();
        var projects = entities.Select(ProjectFactory.Create);

        return projects ?? [];
    }

    public async Task<ProjectDTO?> ViewProjectByIdAsync(int id)
    {
        var entity = await _repository.GetDetailAsync(
            projects => projects.Id == id,
            query => query
            .Include(projects => projects.Customer)
            .Include(projects => projects.Service)
            .Include(projects => projects.ProjectLeader)
            .Include(projects => projects.StatusType)
            );

        if (entity == null) return null;

        var detailedProject = ProjectFactory.Read(entity);
        return detailedProject;
    }

    public async Task<Project?> GetProjectByIdAsync(int id)
    {
        var entity = await _repository.GetAsync(x => x.Id == id);
        var project = ProjectFactory.Create(entity!);
        return project ?? null!;
    }

    public async Task<bool> UpdateProjectAsync(ProjectUpdateForm form)
    {
        var existingEntity = await _repository.GetAsync(x => x.Id == form.Id);

        if (existingEntity == null)
        {
            return false;
        }

        existingEntity.Title = form.Title;
        existingEntity.Description = form.Description;
        existingEntity.StartDate = form.StartDate;
        existingEntity.EndDate = form.EndDate;
        existingEntity.HoursWorked = form.HoursWorked;
        existingEntity.ProjectLeaderId = form.ProjectLeaderId;
        existingEntity.CustomerId = form.CustomerId;
        existingEntity.ServiceId = form.ServiceId;
        existingEntity.StatusTypeId = form.StatusTypeId;

        return await UpdateAsync(existingEntity);

        //return await UpdateAsync(ProjectFactory.Create(form));
    }

    public async Task<bool> DeleteProjectAsync(int id)
    {
        return await DeleteAsync(x => x.Id == id);
    }


}
