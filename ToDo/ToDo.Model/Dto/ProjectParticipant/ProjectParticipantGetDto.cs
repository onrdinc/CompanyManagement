using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model.Dto.Company;
using ToDo.Model.Dto.Project;
using ToDo.Model.Dto.User;

namespace ToDo.Model.Dto.ProjectParticipant
{
    public class ProjectParticipantGetDto: IDto
    {
        //public int ProjectId { get; set; }
        //public int UserId { get; set; }
        public int Id { get; set; }

        public UserGetDto User { get; set; }
        public ProjectGetDto Project { get; set; }
        public string Duty { get; set; }

    }
}
