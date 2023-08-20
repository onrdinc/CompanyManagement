using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model.Dto.Company;
using ToDo.Model.Dto.Department;

namespace ToDo.Model.Dto.Project
{
    public class ProjectGetDto : IDto
    {
        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }
        public string? Name { get; set; }
        public CompanyGetDto Company { get; set; }
        public DepartmentGetDto Department { get; set; }
    }
}
