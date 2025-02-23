using Business.Interfaces;
using Business.Models;
using Business.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Windows;

namespace Project_Manager_WPF.ViewModels;

public partial class ProjectLeaderListViewModel(IProjectLeaderService projectLeaderService, IServiceProvider serviceProvider) : ObservableObject
{
    private readonly IProjectLeaderService _projectLeaderService = projectLeaderService;
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    [ObservableProperty]
    private ObservableCollection<ProjectLeader> _projectLeaders = [];

    [ObservableProperty]
    private ProjectLeader _projectLeader = new();


    public async Task GetProjectLeadersAsync()
    {
        var projectLeaders = await _projectLeaderService.GetAllProjectLeadersAsync();
        ProjectLeaders = new ObservableCollection<ProjectLeader>(projectLeaders);
    }

    [RelayCommand]
    public async Task DeleteProjectLeader(ProjectLeader projectLeader)
    {
        if (projectLeader == null) return;

        var result = MessageBox.Show("Are you sure you want to delete the customer?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        if (result == MessageBoxResult.Yes)
        {
            var success = await _projectLeaderService.DeleteProjectLeaderAsync(projectLeader.Id);
            if (success)
            {
                ProjectLeaders.Remove(projectLeader);
            }
        }
    }

    [RelayCommand]
    public void GoToEditProjectLeader(ProjectLeader projectLeader)
    {
        var projectLeaderEditViewModel = _serviceProvider.GetRequiredService<EditProjectLeaderViewModel>();
        projectLeaderEditViewModel.SetProjectLeader(projectLeader);

        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = projectLeaderEditViewModel;
    }

    [RelayCommand]
    public void GoToAddProjectLeader()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<AddProjectLeaderViewModel>();
    }
}




