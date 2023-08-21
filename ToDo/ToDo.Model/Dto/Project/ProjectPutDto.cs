using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Model.Dto.Project
{
    public class ProjectPutDto : IDto
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int DepartmentId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
