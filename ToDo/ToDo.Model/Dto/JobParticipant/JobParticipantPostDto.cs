using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Model.Dto.JobParticipant
{
    public class JobParticipantPostDto : IDto
    {
        public int JobId { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
    }
}
