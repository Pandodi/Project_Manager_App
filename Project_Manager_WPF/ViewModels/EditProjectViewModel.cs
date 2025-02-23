using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Project_Manager_WPF.ViewModels;

public partial class EditProjectViewModel (IProjectService projectService, IServiceProvider serviceProvider) : ObservableObject
{

    private readonly IProjectService _projectService = projectService;
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    [ObservableProperty]
    private Project _project = new();

    [ObservableProperty]
    private ProjectUpdateForm _projectForm = new();

    public void SetProject(Project project)
    {
        Project = project;
        ProjectForm = new ProjectUpdateForm
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
    }

    [RelayCommand]
    public async Task EditProject()
    {

        var success = await _projectService.UpdateProjectAsync(ProjectForm);
        if (success)
        {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ProjectListViewModel>();
        }


    }

}
