using Infrastructure.DataAccess.Interfaces;
using ToDo.Model.Entities;

namespace ToDo.DataAccess.Interfaces
{
    public interface IMilestoneJobRepository : IBaseRepository<MilestoneJob>
    {
       Task<MilestoneJob> GetByIdAsync(int Id, params string[] includeList);
    }
}
