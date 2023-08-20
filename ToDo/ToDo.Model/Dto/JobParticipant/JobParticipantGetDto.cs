using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model.Dto.Job;
using ToDo.Model.Dto.Project;
using ToDo.Model.Dto.User;

namespace ToDo.Model.Dto.JobParticipant
{
    public class JobParticipantGetDto : IDto
    {
        public int JobId { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public ProjectGetDto? Project { get; set; }
        public JobGetDto? Job { get; set; }
        public UserGetDto? User { get; set; }

    }
}
