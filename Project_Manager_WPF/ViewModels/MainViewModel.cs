using Business.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;


namespace Project_Manager_WPF.ViewModels;

public partial class MainViewModel(IServiceProvider serviceProvider) : ObservableObject
{
    [ObservableProperty]
    public ObservableObject _currentViewModel = null!;

    private readonly IServiceProvider _serviceProvider = serviceProvider;

    [RelayCommand]
    private async Task GoToCustomersAsync()
    {
        var customerListVM = _serviceProvider.GetRequiredService<CustomerListViewModel>();
        await customerListVM.GetCustomersAsync();
        CurrentViewModel = customerListVM;
    }

    [RelayCommand]
    private async Task GoToProjectLeadersAsync()
    {
        var pjListVm = _serviceProvider.GetRequiredService<ProjectLeaderListViewModel>();
        await pjListVm.GetProjectLeadersAsync();
        CurrentViewModel = pjListVm;
    }

    [RelayCommand]
    private async Task GoToServicesAsync()
    {
        var serviceListVm = _serviceProvider.GetRequiredService<ServiceListViewModel>();
        await serviceListVm.GetServicesAsync();
        CurrentViewModel = serviceListVm;
    }

    [RelayCommand]
    private async Task GoToProjectsAsync()
    {
        var projectsVM = _serviceProvider.GetRequiredService<ProjectListViewModel>();
        await projectsVM.GetProjectsAsync();
        CurrentViewModel = projectsVM;
    }
}
