using Infrastructure.DataAccess.Interfaces;
using ToDo.Model.Entities;

namespace ToDo.DataAccess.Interfaces
{
    public interface IUserRepository:IBaseRepository<User>
    {
        Task<User> GetByIdAsync(int Id, params string[] includeList);
        Task<List<User>> GetByDepartmentAsync(int departmentId, params string[] includeList);

    }
}
