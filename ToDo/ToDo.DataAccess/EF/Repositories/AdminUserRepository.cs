using Infrastructure.DataAccess.Implementations.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.DataAccess.EF.Contexts;
using ToDo.DataAccess.Interfaces;
using ToDo.Model.Entities;

namespace ToDo.DataAccess.EF.Repositories
{
    public class AdminUserRepository : BaseRepository<AdminUser, ToDoContext>, IAdminUserRepository
    {

        public async Task<AdminUser> GetByUserNameAndPasswordAsync(string userName, string password, params string[] includeList)
        {
            return await GetAsync(k => k.UserName == userName && k.Password == password && k.IsDeleted.Value);
        }
    }
}
