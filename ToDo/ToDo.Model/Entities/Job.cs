using Infrastructure.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Model.Entities
{
    [Table("Jobs")]

    public class Job:IEntity
    {
        [Key]
        public int Id { get; set; }
        public int MilestoneId { get; set; }
        public string? JobTitle { get; set; }
        public string? Detail { get; set; }
        public int ProjectId { get; set; }


        [ForeignKey("ProjectId")]
        public Project? Project { get; set; }

        [ForeignKey("MilestoneId")]
        public Milestone? Milestone { get; set; }
    }
}
