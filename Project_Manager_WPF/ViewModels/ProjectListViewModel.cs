using Business.Interfaces;
using Business.Models;
using Business.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Windows;

namespace Project_Manager_WPF.ViewModels;

public partial class ProjectListViewModel
    (IProjectService projectService, 
    IProjectLeaderService projectLeaderService,
    IServiceProvider serviceProvider) 
    : ObservableObject
{

    private readonly IProjectService _projectService = projectService;
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly IProjectLeaderService projectLeaderService = projectLeaderService;

    [ObservableProperty]
    private ObservableCollection<Project> _projects = [];
    [ObservableProperty]
    private ObservableCollection<ProjectLeader> _projectLeaders = [];

    [ObservableProperty]
    private Project _project = new();

    [ObservableProperty]
    private Project _selectedProject = new();

    public async Task GetProjectsAsync()
    {
        var projects = await _projectService.GetAllProjectsAsync();
        Projects = new ObservableCollection<Project>(projects);
    }

    [RelayCommand]
    public async Task DeleteProject(Project project)
    {
        if (project == null) return;

        var result = MessageBox.Show("Are you sure you want to delete this project?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        if (result == MessageBoxResult.Yes)
        {
            var success = await _projectService.DeleteProjectAsync(project.Id);
            if (success)
            {
                Projects.Remove(project);
            }
        }
    }

    [RelayCommand]
    public async Task GoToEditProject(Project project)
    {
        var editProjectVM = _serviceProvider.GetRequiredService<EditProjectViewModel>();
        editProjectVM.SetProject(project);

        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = editProjectVM;
        
        await editProjectVM.InitializeAsync();
    }

    [RelayCommand]
    public async Task GoToAddProject()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        var addProjectVM = _serviceProvider.GetRequiredService<AddProjectViewModel>();

        await addProjectVM.InitializeAsync();
        mainViewModel.CurrentViewModel = addProjectVM;
    }

    [RelayCommand]
    private async Task GoToProjectDetails(Project selectedProject)
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        var viewProjectVM = _serviceProvider.GetRequiredService<ProjectDetailViewModel>();

        var projectDTO = await _projectService.ViewProjectByIdAsync(selectedProject.Id);

        await viewProjectVM.LoadProjectDetailsAsync(projectDTO!);
        mainViewModel.CurrentViewModel = viewProjectVM;
    }

}
