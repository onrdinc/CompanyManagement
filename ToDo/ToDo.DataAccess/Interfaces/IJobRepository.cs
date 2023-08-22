using Infrastructure.DataAccess.Interfaces;
using ToDo.Model.Entities;

namespace ToDo.DataAccess.Interfaces
{
    public interface IJobRepository : IBaseRepository<Job>
    {
        Task<Job> GetByIdAsync(int Id, params string[] includeList);
        Task<List<Job>> GetByProjectJobAsync(int projectId, params string[] includeList);
        Task<List<Job>> GetByUserJobAsync(int userId, params string[] includeList);
    }
}
