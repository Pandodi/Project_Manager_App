using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace Project_Manager_WPF.ViewModels;

public partial class AddProjectViewModel
    (IProjectService projectService, 
    IProjectLeaderService projectLeaderService,
    ICustomerService customerService,
    IServiceService serviceService,
    IStatusTypeService statusTypeService,
    IServiceProvider serviceProvider) : ObservableObject
{

    private readonly IProjectService _projectService = projectService;
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly IProjectLeaderService _projectLeaderService = projectLeaderService;
    private readonly ICustomerService _customerService = customerService;
    private readonly IServiceService _serviceService = serviceService;
    private readonly IStatusTypeService _statusTypeService = statusTypeService;

    [ObservableProperty]
    private ProjectRegistrationForm _projectForm = new();


    [ObservableProperty]
    private ObservableCollection<ProjectLeader> _projectLeaders = [];
    [ObservableProperty]
    private ObservableCollection<Customer> _customers = [];
    [ObservableProperty]
    private ObservableCollection<Service> _services = [];
    [ObservableProperty]
    private ObservableCollection<StatusType> _statusTypes = [];


    [ObservableProperty]
    private ProjectLeader _selectedProjectLeader = null!;
    [ObservableProperty]
    private Customer _selectedCustomer = null!;
    [ObservableProperty]
    private Service _selectedService = null!;
    [ObservableProperty]
    private StatusType _selectedStatusType = null!;



    [RelayCommand]
    public async Task AddProject()
    {
        if (SelectedProjectLeader != null)
            ProjectForm.ProjectLeaderId = SelectedProjectLeader.Id;

        if (SelectedCustomer != null)
            ProjectForm.CustomerId = SelectedCustomer.Id;

        if (SelectedService != null)
            ProjectForm.ServiceId = SelectedService.Id;

        if (SelectedStatusType != null)
            ProjectForm.StatusTypeId = SelectedStatusType.Id;


        var success = await _projectService.CreateProjectAsync(ProjectForm);
        if (success)
        {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ProjectListViewModel>();
        }
    }

    public async Task InitializeAsync()
    {
        ProjectLeaders = new ObservableCollection<ProjectLeader>(await _projectLeaderService.GetAllProjectLeadersAsync());
        Customers = new ObservableCollection<Customer>(await _customerService.GetAllCustomersAsync());
        Services = new ObservableCollection<Service>(await _serviceService.GetAllServicesAsync());
        StatusTypes = new ObservableCollection<StatusType>(await _statusTypeService.GetAllStatusTypesAsync());
    }



}




