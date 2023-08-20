using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model.Dto.Job;
using ToDo.Model.Dto.Label;
using ToDo.Model.Dto.Project;

namespace ToDo.Model.Dto.JobLabel
{
    public class JobLabelGetDto : IDto
    {
        public int ProjectId { get; set; }
        public int JobId { get; set; }
        public int LabelId { get; set; }
        public ProjectGetDto? Project { get; set; }
        public JobGetDto? Job { get; set; }
        public LabelGetDto? Label { get; set; }
    }
}
