using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model.Dto.Contact;
using ToDo.Model.Dto.Department;
using ToDo.Model.Entities;

namespace ToDo.Business.Profiles
{
    public class ContactProfile :Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactGetDto>();
            CreateMap<ContactPostDto, Contact>();
        }
    }
}
