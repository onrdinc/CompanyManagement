using Infrastructure.DataAccess.Interfaces;
using ToDo.Model.Entities;

namespace ToDo.DataAccess.Interfaces
{
    public interface IJobRepository : IBaseRepository<Job>
    {
        Task<Job> GetByIdAsync(int Id, params string[] includeList);
    }
}
