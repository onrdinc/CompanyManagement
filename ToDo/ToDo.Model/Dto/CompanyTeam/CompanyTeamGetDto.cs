using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model.Dto.Company;
using ToDo.Model.Dto.Department;
using ToDo.Model.Dto.User;

namespace ToDo.Model.Dto.CompanyTeam
{
    public class CompanyTeamGetDto : IDto
    {
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        public CompanyGetDto? Company { get; set; }
        public DepartmentGetDto? Department { get; set; }
        public UserGetDto? User { get; set; }

    }
}
