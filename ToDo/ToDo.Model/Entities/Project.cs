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
    public class Project:IEntity
    {
        [Key]
        public int Id { get;set; }
        public int ServiceId { get;set; }
        public int DepartmentId { get;set; }
        public string? Name { get;set; }
        public string? Description { get; set; }


        public Service? Service { get;set; }

        public Department? Department { get;set; }
        public bool? IsDeleted { get; set; } = false;


    }
}
