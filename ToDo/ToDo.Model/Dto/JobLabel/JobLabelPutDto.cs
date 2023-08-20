using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Model.Dto.JobLabel
{
    public class JobLabelPutDto : IDto
    {
        public int ProjectId { get; set; }
        public int JobId { get; set; }
        public int LabelId { get; set; }
    }
}
