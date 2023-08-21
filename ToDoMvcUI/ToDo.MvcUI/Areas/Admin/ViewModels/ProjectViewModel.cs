using ToDo.MvcUI.Areas.Admin.Models;

namespace ToDo.MvcUI.Areas.Admin.ViewModels
{
    public class ProjectViewModel
    {
        public List<DepartmentItem> Departments { get; set; }
        public List<ServiceItem> Services { get; set; }
        public List<ProjectItem> Projects { get; set; }
    }
}
