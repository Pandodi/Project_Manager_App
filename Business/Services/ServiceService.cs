using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class ServiceService(IServiceRepository serviceRepository)
    : BaseService<IServiceRepository, ServiceEntity>(serviceRepository), IServiceService
{
    public async Task<bool> CreateServiceAsync(ServiceRegistrationForm form)
    {
        if (await _repository.ExistsAsync(x => x.ServiceName == form.ServiceName))
            return false;

        return await CreateAsync(ServiceFactory.Create(form));
    }

    public async Task<IEnumerable<Service>> GetAllServicesAsync()
    {
        var entities = await _repository.GetAllAsync();
        var services = entities.Select(ServiceFactory.Create);

        return services ?? [];
    }

    public async Task<Service?> GetServiceByIdAsync(int id)
    {
        var entity = await _repository.GetAsync(x => x.Id == id);
        var service = ServiceFactory.Create(entity!);
        return service ?? null!;
    }

    public async Task<bool> UpdateServiceAsync(ServiceUpdateForm form)
    {
        //For some reason when using a factory here... it doesn't want to work with Entity Framework

        var existingEntity = await _repository.GetAsync(x => x.Id == form.Id);

        if (existingEntity == null)
        {
            return false;
        }

        existingEntity.ServiceName = form.ServiceName;
        existingEntity.PricePerHour = form.PricePerHour;

        return await UpdateAsync(existingEntity);
    }

    public async Task<bool> DeleteServiceAsync(int id)
    {
        return await DeleteAsync(x => x.Id == id);
    }

}