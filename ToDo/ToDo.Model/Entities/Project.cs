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
    [Table ("Projects")]
    public class Project:IEntity
    {
        [Key]
        public int Id { get;set; }
        public int CompanyId { get;set; }
        public int DepartmentId { get;set; }
        public string? Name { get;set; }

        [ForeignKey("CompanyId")]
        public Company? Company { get;set; }

        [ForeignKey("DepartmentId")]
        public Department? Department { get;set; }


    }
}
