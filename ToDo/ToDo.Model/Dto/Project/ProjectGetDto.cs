using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model.Dto.Company;
using ToDo.Model.Dto.Department;
using ToDo.Model.Dto.Service;

namespace ToDo.Model.Dto.Project
{
    public class ProjectGetDto : IDto
    {
        public int Id { get; set; }
        //public string? ServiceName { get; set; }
        //public int ServiceId { get; set; }
        //public int DepartmentId { get; set; }
        //public string? DepartmentName { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DepartmentGetDto Department { get; set; }
        public ServiceGetDto Service { get; set; }
    }
}
