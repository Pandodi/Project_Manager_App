using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class ProjectLeaderRepository(DataContext context) : BaseRepository<ProjectLeaderEntity>(context), IProjectLeaderRepository
{
    private readonly DataContext _context = context;
}
