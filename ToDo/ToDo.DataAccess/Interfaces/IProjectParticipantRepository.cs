using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model.Entities;

namespace ToDo.DataAccess.Interfaces
{
    public interface IProjectParticipantRepository : IBaseRepository<ProjectParticipant>
    {
        Task<ProjectParticipant> GetByIdAsync(int Id, params string[] includeList);
        Task<List<ProjectParticipant>> GetByParticipantAsync(int projectId, params string[] includeList);
        Task<List<ProjectParticipant>> GetByUserProjectAsync(int userId, params string[] includeList);

    }
}
