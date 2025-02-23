using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Project_Manager_WPF.ViewModels;

public partial class ProjectDetailViewModel (IProjectService projectService) : ObservableObject
{
    private readonly IProjectService _projectService = projectService;

    [ObservableProperty]
    private ProjectDTO? _selectedProject;


    public Task LoadProjectDetailsAsync(ProjectDTO projectDTO)
    {
        SelectedProject = projectDTO;
        return Task.CompletedTask;
    }
}
