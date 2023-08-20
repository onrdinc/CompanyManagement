using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Model.Dto.User
{
    public class UserGetDto:IDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Nickname { get; set; }
        public string? Email { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string UserPicture { get; set; }
        public string? PicturePath { get; set; }


    }
}
