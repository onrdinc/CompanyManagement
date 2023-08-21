namespace ToDo.MvcUI.Areas.Admin.Models
{
    public class ProjectItem
    {
        public int Id { get; set; }
        public string? DepartmentName { get; set; }
        public string? ServiceName { get; set; }
        public int ServiceId { get; set; }
        public int DepartmentId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
