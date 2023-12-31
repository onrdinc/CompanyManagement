﻿namespace ToDo.MvcUI.Areas.Admin.Models
{
    public class UserItem
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Nickname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserPicture { get; set; }
        public string? PicturePath { get; set; }

        public string Duty { get; set; }

    }
}
