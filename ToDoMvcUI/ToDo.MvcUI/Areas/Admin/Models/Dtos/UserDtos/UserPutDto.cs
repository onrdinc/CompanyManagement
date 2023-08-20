﻿namespace ToDo.MvcUI.Areas.Admin.Models.Dtos.UserDtos
{
    public class UserPutDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Nickname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
    }
}
