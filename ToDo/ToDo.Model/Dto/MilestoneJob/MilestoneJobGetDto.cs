using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model.Dto.Job;
using ToDo.Model.Dto.Milestone;

namespace ToDo.Model.Dto.MilestoneJob
{
    public class MilestoneJobGetDto : IDto
    {
        public int MilestoneId { get; set; }
        public int JobId { get; set; }
        public MilestoneGetDto Milestone { get;set; }
        public JobGetDto Job { get; set; }
    }
}
