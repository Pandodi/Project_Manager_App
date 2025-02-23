using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class StatusTypeService(IStatusTypeRepository statusTypeRepository)
    : BaseService<IStatusTypeRepository, StatusTypeEntity>(statusTypeRepository), IStatusTypeService
{
    public async Task<IEnumerable<StatusType>> GetAllStatusTypesAsync()
    {
        var entities = await _repository.GetAllAsync();
        var statusTypes = entities.Select(StatusTypeFactory.Create);

        return statusTypes ?? [];
    }

    public async Task<StatusType?> GetStatusTypeByIdAsync(int id)
    {
        var entity = await _repository.GetAsync(x => x.Id == id);
        var statusType = StatusTypeFactory.Create(entity!);
        return statusType ?? null!;
    }
}
