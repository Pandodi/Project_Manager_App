using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Project_Manager_WPF.ViewModels;

public partial class EditProjectLeaderViewModel(IProjectLeaderService projectLeaderService, IServiceProvider serviceProvider) : ObservableObject
{
    private readonly IProjectLeaderService _projectLeaderService = projectLeaderService;
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    [ObservableProperty]
    private ProjectLeader _projectLeader = new();

    [ObservableProperty]
    private ProjectLeaderUpdateForm _projectLeaderForm = new();

    public void SetProjectLeader(ProjectLeader projectLeader)
    {
        ProjectLeader = projectLeader;
        ProjectLeaderForm = new ProjectLeaderUpdateForm
        {
            Id = projectLeader.Id,
            Name = projectLeader.Name,
            Email = projectLeader.Email
        };
    }

    [RelayCommand]
    public async Task EditProjectLeader()
    {

        var success = await _projectLeaderService.UpdateProjectLeaderAsync(ProjectLeaderForm);
        if (success)
        {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ProjectLeaderListViewModel>();
        }


    }

}




