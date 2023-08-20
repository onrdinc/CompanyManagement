using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Model.Dto.Job
{
    public class JobPostDto : IDto
    {
        public int MilestoneId { get; set; }
        public string? JobTitle { get; set; }
        public string? Detail { get; set; }
        public int ProjectId { get; set; }
    }
}
