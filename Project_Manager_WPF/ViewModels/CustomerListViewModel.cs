using Business.Interfaces;
using Business.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Project_Manager_WPF.ViewModels;

public partial class CustomerListViewModel(ICustomerService customerService, IServiceProvider serviceProvider) : ObservableObject
{

    private readonly ICustomerService _customerService = customerService;
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    [ObservableProperty]
    private ObservableCollection<Customer> _customers = [];

    [ObservableProperty]
    private Customer _customer = new();




    public async Task GetCustomersAsync()
    {
        var customers = await _customerService.GetAllCustomersAsync();
        Customers = new ObservableCollection<Customer>(customers);
    }

    [RelayCommand]
    public async Task DeleteCustomer(Customer customer)
    {
        if (customer == null) return;

        var result = MessageBox.Show("Are you sure you want to delete the customer?","Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        if (result == MessageBoxResult.Yes)
        {
            
            var success = await _customerService.DeleteCustomerAsync(customer.Id);
            if (success)
            {
                Customers.Remove(customer);
            }     
        }


    }

    [RelayCommand]
    public void GoToEditCustomer(Customer customer)
    {
        var customerEditViewModel = _serviceProvider.GetRequiredService<EditCustomerViewModel>();
        customerEditViewModel.SetCustomer(customer);

        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = customerEditViewModel;
    }

    [RelayCommand]
    public void GoToAddCustomer()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<AddCustomerViewModel>();
    }

    
}



