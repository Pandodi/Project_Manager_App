using Business.Dtos;
using Business.Interfaces;
using Business.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Project_Manager_WPF.ViewModels;

public partial class AddServiceViewModel(IServiceService serviceService, IServiceProvider serviceProvider) : ObservableObject
{
    private readonly IServiceService _serviceService = serviceService;
    private readonly IServiceProvider _serviceProvider = serviceProvider;


    [ObservableProperty]
    private ServiceRegistrationForm _serviceForm = new();

    [RelayCommand]
    public async Task AddService()
    {
        var success = await _serviceService.CreateServiceAsync(ServiceForm);
        if (success)
        {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            var serviceViewModel = _serviceProvider.GetRequiredService<ServiceListViewModel>();

            await serviceViewModel.GetServicesAsync();
            mainViewModel.CurrentViewModel = serviceViewModel;
        }
    }

}




