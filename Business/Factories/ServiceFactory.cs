using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class ServiceFactory
{
    public static ServiceRegistrationForm Create() => new();

    public static ServiceEntity Create(ServiceRegistrationForm form) => new()
    {
        ServiceName = form.ServiceName,
        PricePerHour = form.PricePerHour
    };

    public static Service Create(ServiceEntity serviceEntity) => new()
    {
        Id = serviceEntity.Id,
        ServiceName = serviceEntity.ServiceName,
        PricePerHour = serviceEntity.PricePerHour
    };

    public static ServiceUpdateForm Create(Service service) => new()
    {
        Id = service.Id,
        ServiceName = service.ServiceName,
        PricePerHour = service.PricePerHour
    };

    public static ServiceEntity Create(ServiceUpdateForm updateForm) => new()
    {
        Id = updateForm.Id,
        ServiceName = updateForm.ServiceName,
        PricePerHour = updateForm.PricePerHour
    };
}
