using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Model.Dto.Job
{
    public class JobPutDto : IDto
    {
        public int Id { get; set; }
        public int LabelId { get; set; }
        public int UserId { get; set; }
        public int StatuId { get; set; }
        public string? JobTitle { get; set; }
        public string? Detail { get; set; }
        public int ProjectId { get; set; }
    }
}
