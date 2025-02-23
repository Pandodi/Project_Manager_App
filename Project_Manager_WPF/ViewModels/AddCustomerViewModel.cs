using Business.Dtos;
using Business.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Project_Manager_WPF.ViewModels;

public partial class AddCustomerViewModel(ICustomerService customerService, IServiceProvider serviceProvider) : ObservableObject
{
    private readonly ICustomerService _customerService = customerService;
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    [ObservableProperty]
    private CustomerRegistrationForm _customerForm = new();

    [RelayCommand]
    public async Task AddCustomer()
    {
        var success = await _customerService.CreateCustomerAsync(CustomerForm);
        if (success)
        {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<CustomerListViewModel>();
        }
    }
    
}

