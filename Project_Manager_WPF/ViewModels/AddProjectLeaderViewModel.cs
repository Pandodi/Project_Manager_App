using Business.Dtos;
using Business.Interfaces;
using Business.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Project_Manager_WPF.ViewModels;

public partial class AddProjectLeaderViewModel(IProjectLeaderService projectLeaderService, IServiceProvider serviceProvider) : ObservableObject
{
    private readonly IProjectLeaderService _projectLeaderService = projectLeaderService;
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    [ObservableProperty]
    private ProjectLeaderRegistrationForm _projectLeaderForm = new();

    [RelayCommand]
    public async Task AddProjectLeader()
    {
        var success = await _projectLeaderService.CreateProjectLeaderAsync(ProjectLeaderForm);
        if (success)
        {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            var projectLeaderVM = _serviceProvider.GetRequiredService<ProjectLeaderListViewModel>();

            await projectLeaderVM.GetProjectLeadersAsync();
            mainViewModel.CurrentViewModel = projectLeaderVM;
        }
    }

}




