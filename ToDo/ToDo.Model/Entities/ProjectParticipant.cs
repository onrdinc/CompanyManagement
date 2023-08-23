using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Model.Entities
{

    public class ProjectParticipant : IEntity
    {

        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public string Duty { get; set; }

        public bool IsDeleted { get; set; } = false;

        public Project? Project { get; set; }
        public User? User { get; set; }
    }
}
