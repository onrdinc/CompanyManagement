using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Model.Dto.Department
{
    public class DepartmentPostDto : IDto
    {
        public int CompanyId { get; set; }
        public string? Name { get; set; }
    }
}
