﻿using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Project_Manager_WPF.ViewModels;

public partial class EditCustomerViewModel(IServiceProvider serviceProvider, ICustomerService customerService) : ObservableObject
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly ICustomerService _customerService = customerService;

    [ObservableProperty]
    private Customer _customer = new();

    [ObservableProperty]
    private CustomerUpdateForm _customerForm = new();

    public void SetCustomer(Customer customer)
    {
        Customer = customer;
        CustomerForm = new CustomerUpdateForm
        {
            Id = customer.Id,
            CustomerName = customer.CustomerName,
            CustomerEmail = customer.CustomerEmail
        };
    }

    [RelayCommand]
    public async Task EditCustomer()
    {

        var success = await _customerService.UpdateCustomerAsync(CustomerForm);
        if (success)
        {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<CustomerListViewModel>();
        }


    }
}

