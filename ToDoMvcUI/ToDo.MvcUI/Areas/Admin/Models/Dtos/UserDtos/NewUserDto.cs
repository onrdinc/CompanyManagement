namespace ToDo.MvcUI.Areas.Admin.Models.Dtos.UserDtos
{
    public class NewUserDto
    {
        public string Name { get;set; }
        public string Surname { get;set; }
        public string Email { get;set; }
        public string Password { get;set; }
        public string Nickname { get;set; }
        public string Duty { get;set; }
        public int DepartmentId { get;set; }
        //public IFormFile UserPhoto { get;set; }
    }
}
