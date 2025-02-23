using Business.Models;

namespace Business.Services
{
    public interface IStatusTypeService
    {
        Task<IEnumerable<StatusType>> GetAllStatusTypesAsync();
        Task<StatusType?> GetStatusTypeByIdAsync(int id);
    }
}