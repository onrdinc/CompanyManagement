using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Model.Dto.Contact
{
    public class ContactPostDto : IDto
    {
        public string NameSurname { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
    }
}
