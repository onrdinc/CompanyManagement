using Infrastructure.DataAccess.Interfaces;
using ToDo.Model.Entities;

namespace ToDo.DataAccess.Interfaces
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        Task<Department> GetByIdAsync(int Id, params string[] includeList);

    }
}
