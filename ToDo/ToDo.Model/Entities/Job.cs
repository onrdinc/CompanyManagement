using Infrastructure.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Model.Entities
{

    public class Job:IEntity
    {
        public int Id { get; set; }
        public int StatuId { get; set; }
        public string? JobTitle { get; set; }
        public string? Detail { get; set; }
        public int ProjectId { get; set; }
        public int LabelId { get; set; }
        public int UserId { get; set; }
        public bool? IsDeleted { get; set; } = false;

        public Project? Project { get; set; }
        public Statu? Statu { get; set; }
        public Label? Label { get; set; }
        public User? User { get; set; }
    }
}
