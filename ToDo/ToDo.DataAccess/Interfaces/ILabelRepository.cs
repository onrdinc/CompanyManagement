using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model.Entities;

namespace ToDo.DataAccess.Interfaces
{
    public interface ILabelRepository : IBaseRepository<Label>
    {
        Task<Label> GetByIdAsync(int Id, params string[] includeList);
    }
}
