using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Model.Entities
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
