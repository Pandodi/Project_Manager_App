using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class CustomerService(ICustomerRepository customerRepository)
    : BaseService<ICustomerRepository, CustomerEntity>(customerRepository), ICustomerService
{
    public async Task<bool> CreateCustomerAsync(CustomerRegistrationForm form)
    {
        if (await _repository.ExistsAsync(x => x.CustomerEmail == form.CustomerEmail))
            return false;

        return await CreateAsync(CustomerFactory.Create(form));
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        var entities = await _repository.GetAllAsync();
        var customers = entities.Select(CustomerFactory.Create);

        return customers ?? [];
    }

    public async Task<Customer?> GetCustomerByIdAsync(int id)
    {
        var entity = await _repository.GetAsync(x => x.Id == id);
        var customer = CustomerFactory.Create(entity!);
        return customer ?? null!;
    }

    public async Task<bool> UpdateCustomerAsync(CustomerUpdateForm form)
    {

        //For some reason when using a factory here... it doesn't want to work with Entity Framework
        
        var existingEntity = await _repository.GetAsync(x => x.Id == form.Id);

        if (existingEntity == null)
        {
            return false; 
        }

        existingEntity.CustomerName = form.CustomerName;
        existingEntity.CustomerEmail = form.CustomerEmail;

        return await UpdateAsync(existingEntity); 
    }

    public async Task<bool> DeleteCustomerAsync(int id)
    {
        return await DeleteAsync(x => x.Id == id);
    }

}
