using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Model.Dto.Project
{
    public class ProjectPostDto : IDto
    {
        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }
        public string? Name { get; set; }
    }
}
