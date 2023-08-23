using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Model.Entities
{
    public class AboutUs :IEntity
    {
        public int Id { get; set; }
        public string? About { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
