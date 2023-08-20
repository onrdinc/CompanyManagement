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
    [Table("MilestoneJobs")]

    public class MilestoneJob:IEntity
    {
        [Key]

        public int Id { get; set; }
        public int MilestoneId { get; set; }
        public int JobId { get; set; }

        [ForeignKey("MilestoneId")]
        public Milestone? Milestone { get; set; }

        [ForeignKey("JobId")]
        public Job? Job { get; set; }
    }
}
