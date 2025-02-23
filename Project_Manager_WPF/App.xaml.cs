using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Data.Contexts;
using Microsoft.Extensions.Hosting;
using Business.Services;
using Business.Interfaces;
using Project_Manager_WPF.ViewModels;
using Project_Manager_WPF.Views;
using Data.Interfaces;
using Data.Repositories;

namespace Project_Manager_WPF;

public partial class App : Application
{
    private IHost _host;
    public App()
    {
        _host = Host.CreateDefaultBuilder()
           .ConfigureServices((context, services) =>
           {
               services.AddDbContext<DataContext>(options =>
               options.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\source\\repos\\Pandodi\\Project_Manager_App\\Data\\Databases\\projectDatabase.mdf;Integrated Security=True;Connect Timeout=30"));
               services.AddScoped<ICustomerRepository, CustomerRepository>();
               services.AddScoped<ICustomerService, CustomerService>();
               services.AddScoped<IProjectLeaderRepository, ProjectLeaderRepository>();
               services.AddScoped<IProjectLeaderService, ProjectLeaderService>();
               services.AddScoped<IServiceRepository, ServiceRepository>();
               services.AddScoped<IServiceService, ServiceService>();
               services.AddScoped<IProjectRepository, ProjectRepository>();
               services.AddScoped<IProjectService, ProjectService>();
               services.AddScoped<IStatusTypeRepository, StatusTypeRepository>();
               services.AddScoped<IStatusTypeService, StatusTypeService>();


               services.AddScoped<AddCustomerViewModel>();
               services.AddScoped<CustomerListViewModel>();
               services.AddScoped<EditCustomerViewModel>();

               services.AddScoped<AddProjectLeaderViewModel>();
               services.AddScoped<ProjectLeaderListViewModel>();
               services.AddScoped<EditProjectLeaderViewModel>();

               services.AddScoped<AddServiceViewModel>();
               services.AddScoped<ServiceListViewModel>();
               services.AddScoped<EditServiceViewModel>();

               services.AddScoped<AddProjectViewModel>();
               services.AddScoped<ProjectListViewModel>();
               services.AddScoped<EditProjectViewModel>();
               services.AddScoped<ProjectDetailViewModel>();


               services.AddScoped<AddCustomerView>();
               services.AddScoped<CustomerListView>();
               services.AddScoped<EditCustomerView>();

               services.AddScoped<AddProjectLeaderView>();
               services.AddScoped<ProjectLeaderListView>();
               services.AddScoped<EditProjectLeaderView>();

               services.AddScoped<AddServiceView>();
               services.AddScoped<ServiceListView>();
               services.AddScoped<EditServiceView>();

               services.AddScoped<AddProjectView>();
               services.AddScoped<ProjectListView>();
               services.AddScoped<EditProjectView>();
               services.AddScoped<ProjectDetailView>();


               services.AddScoped<MainViewModel>();
               services.AddScoped<MainWindow>();
           })
           .Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainViewModel = _host.Services.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _host.Services.GetRequiredService<AddCustomerViewModel>();

        var mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }

}
