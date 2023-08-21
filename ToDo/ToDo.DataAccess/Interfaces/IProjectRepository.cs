using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model.Entities;

namespace ToDo.DataAccess.Interfaces
{
    public interface IProjectRepository:IBaseRepository<Project>
    {
        Task<Project> GetByIdAsync(int Id, params string[] includeList);
        Task<List<Project>> GetByProjectServiceAsync(int serviceId, params string[] includeList);
        Task<List<Project>> GetByProjectDepartmentAsync(int departmentId, params string[] includeList);


    }
}
