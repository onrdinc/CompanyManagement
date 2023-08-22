using Infrastructure.DataAccess.Interfaces;
using ToDo.Model.Entities;

namespace ToDo.DataAccess.Interfaces
{
    public interface IWageRepository : IBaseRepository<Wage>
    {
        Task<Wage> GetByIdAsync(int Id, params string[] includeList);

    }
}
