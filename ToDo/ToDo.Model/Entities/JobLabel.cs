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
    [Table("JobLabels")]

    public class JobLabel:IEntity
    {
        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int JobId { get; set; }
        public int LabelId { get; set; }

        [ForeignKey("ProjectId")]
        public Project? Project { get; set; }
        [ForeignKey("JobId")]
        public Job? Job { get; set; }
        [ForeignKey("LabelId")]
        public Label? Label { get; set; }
    }


}
