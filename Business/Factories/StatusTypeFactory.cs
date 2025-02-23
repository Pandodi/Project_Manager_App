using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class StatusTypeFactory
{
    public static StatusTypeRegistrationForm Create() => new();

    public static StatusTypeEntity Create(StatusTypeRegistrationForm form) => new()
    {
        StatusName = form.StatusName 
    };

    public static StatusType Create(StatusTypeEntity statusTypeEntity) => new()
    {
        Id = statusTypeEntity.Id,
        StatusName = statusTypeEntity.StatusName
    };

    
}
