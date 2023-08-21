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
        public int StatuId { get; set; }
        public string? JobTitle { get; set; }
        public string? Detail { get; set; }
        public int ProjectId { get; set; }
        public int LabelId { get; set; }


        [ForeignKey("ProjectId")]
        public Project? Project { get; set; }

        [ForeignKey("StatuId")]
        public Statu? Statu { get; set; }
        [ForeignKey("LabelId")]
        public Label? Label { get; set; }
    }
}
