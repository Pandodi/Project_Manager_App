using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class CustomerFactory
{
    public static CustomerRegistrationForm Create() => new();

    public static CustomerEntity Create(CustomerRegistrationForm form) => new()
    {
        CustomerName = form.CustomerName,
        CustomerEmail = form.CustomerEmail
    };

    public static Customer Create(CustomerEntity customerEntity) => new()
    {
        Id = customerEntity.Id,
        CustomerName = customerEntity.CustomerName,
        CustomerEmail = customerEntity.CustomerEmail
    };

    public static CustomerUpdateForm Create(Customer customer) => new()
    {
        Id = customer.Id,
        CustomerName = customer.CustomerName,
        CustomerEmail = customer.CustomerEmail
    };

    public static CustomerEntity Create(CustomerUpdateForm updateForm)
    {
        return new CustomerEntity()
        {
            Id = updateForm.Id,
            CustomerName = updateForm.CustomerName,
            CustomerEmail = updateForm.CustomerEmail
        };
    }





}
