using Business.Interfaces;
using Business.Models;
using Business.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace Project_Manager_WPF.ViewModels;

public partial class ServiceListViewModel(IServiceService serviceService, IServiceProvider serviceProvider) : ObservableObject
{
    private readonly IServiceService _serviceService = serviceService;
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    [ObservableProperty]
    private ObservableCollection<Service> _services = [];

    [ObservableProperty]
    private Service _service = new();

    public async Task GetServicesAsync()
    {
        var services = await _serviceService.GetAllServicesAsync();
        Services = new ObservableCollection<Service>(services);
    }

    [RelayCommand]
    public async Task DeleteService(Service service)
    {
        if (service == null) return;

        var result = await _serviceService.DeleteServiceAsync(service.Id);
        if (result)
        {
            Services.Remove(service);
        }
    }

    [RelayCommand]
    public void GoToEditService(Service service)
    {
        var serviceEditViewModel = _serviceProvider.GetRequiredService<EditServiceViewModel>();
        serviceEditViewModel.SetService(service);

        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = serviceEditViewModel;
    }

    [RelayCommand]
    public void GoToAddService()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<AddServiceViewModel>();
    }

}




