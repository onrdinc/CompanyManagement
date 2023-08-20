using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Model.Dto.CompanyTeam
{
    public class CompanyTeamPostDto : IDto
    {
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
    }
}
