using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Model.Dto.ProjectParticipant
{
    public class ProjectParticipantPostDto: IDto
    {
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
    }
}
