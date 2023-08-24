namespace ToDo.MvcUI.Areas.Admin.Models.Dtos.ProjectDtos
{
    public class NewProjectDto
    {
        public int? ServiceId { get; set; }
        public int DepartmentId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
