using Infrastructure.DataAccess.Implementations.EF;
using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.DataAccess.EF.Contexts;
using ToDo.DataAccess.Interfaces;
using ToDo.Model.Entities;

namespace ToDo.DataAccess.EF.Repositories
{
    public class UserRepository : BaseRepository<User, ToDoContext>, IUserRepository
    {
        public async Task<List<User>> GetByDepartmentAsync(int departmentId, params string[] includeList)
        {
            return await GetAllAsync(k => k.DepartmentId == departmentId && k.IsDeleted == false, includeList);
        }

        public async Task<User> GetByIdAsync(int Id, params string[] includeList)
        {
            return await GetAsync(k => k.Id == Id && k.IsDeleted == false, includeList);
        }
    }
}
