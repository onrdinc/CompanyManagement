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
    public class JobRepository : BaseRepository<Job, ToDoContext>, IJobRepository
    {
        public async Task<Job> GetByIdAsync(int Id, params string[] includeList)
        {
            return await GetAsync(k => k.Id == Id && k.IsDeleted == false, includeList);
        }

        public async Task<List<Job>> GetByProjectJobAsync(int projectId, params string[] includeList)
        {
            return await GetAllAsync(k => k.ProjectId == projectId && k.IsDeleted == false, includeList);
        }

        public async Task<List<Job>> GetByUserJobAsync(int userId, params string[] includeList)
        {
            return await GetAllAsync(k => k.UserId == userId && k.IsDeleted == false, includeList);
        }
    }
}
