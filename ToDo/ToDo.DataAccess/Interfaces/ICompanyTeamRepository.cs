using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model.Entities;

namespace ToDo.DataAccess.Interfaces
{
    public interface ICompanyTeamRepository : IBaseRepository<CompanyTeam>
    {
        Task<CompanyTeam> GetByIdAsync(int Id, params string[] includeList);

    }
}
