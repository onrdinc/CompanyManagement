using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Model.Dto.MilestoneJob
{
    public class MilestoneJobPostDto : IDto
    {
        public int MilestoneId { get; set; }
        public int JobId { get; set; }
    }
}
