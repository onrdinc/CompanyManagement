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
    public class ProjectParticipantRepository : BaseRepository<ProjectParticipant, ToDoContext>, IProjectParticipantRepository
    {
        public async Task<ProjectParticipant> GetByIdAsync(int Id, params string[] includeList)
        {
            return await GetAsync(k => k.Id == Id, includeList);
        }

        public async Task<List<ProjectParticipant>> GetByParticipantAsync(int projectId, params string[] includeList)
        {
            return await GetAllAsync(k => k.ProjectId == projectId, includeList);
        }
    }
}
