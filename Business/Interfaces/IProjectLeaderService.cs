using Business.Dtos;
using Business.Models;

namespace Business.Interfaces
{
    public interface IProjectLeaderService
    {
        Task<bool> CreateProjectLeaderAsync(ProjectLeaderRegistrationForm form);
        Task<bool> DeleteProjectLeaderAsync(int id);
        Task<IEnumerable<ProjectLeader>> GetAllProjectLeadersAsync();
        Task<ProjectLeader?> GetProjectLeaderByIdAsync(int id);
        Task<bool> UpdateProjectLeaderAsync(ProjectLeaderUpdateForm form);
    }
}