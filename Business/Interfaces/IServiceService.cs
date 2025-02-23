using Business.Dtos;
using Business.Models;

namespace Business.Interfaces
{
    public interface IServiceService
    {
        Task<bool> CreateServiceAsync(ServiceRegistrationForm form);
        Task<bool> DeleteServiceAsync(int id);
        Task<IEnumerable<Service>> GetAllServicesAsync();
        Task<Service?> GetServiceByIdAsync(int id);
        Task<bool> UpdateServiceAsync(ServiceUpdateForm form);
    }
}