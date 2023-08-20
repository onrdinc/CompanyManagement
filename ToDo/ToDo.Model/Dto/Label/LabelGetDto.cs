using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model.Dto.Project;

namespace ToDo.Model.Dto.Label
{
    public class LabelGetDto : IDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int ProjectId { get; set; }
        public ProjectGetDto Project { get; set; }
    }
}
