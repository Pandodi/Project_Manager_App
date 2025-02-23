using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Project_Manager_WPF.ViewModels;

public partial class EditServiceViewModel(IServiceService serviceService, IServiceProvider serviceProvider) : ObservableObject
{
    private readonly IServiceService _serviceService = serviceService;
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    [ObservableProperty]
    private Service _service = new();

    [ObservableProperty]
    private ServiceUpdateForm _serviceForm = new();

    public void SetService(Service service)
    {
        Service = service;
        ServiceForm = new ServiceUpdateForm
        {
            Id = service.Id,
            ServiceName = service.ServiceName,
            PricePerHour = service.PricePerHour
        };
    }

    [RelayCommand]
    public async Task EditService()
    {

        var success = await _serviceService.UpdateServiceAsync(ServiceForm);
        if (success)
        {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            var serviceViewModel = _serviceProvider.GetRequiredService<ServiceListViewModel>();

            await serviceViewModel.GetServicesAsync();
            mainViewModel.CurrentViewModel = serviceViewModel;
        }


    }

}




