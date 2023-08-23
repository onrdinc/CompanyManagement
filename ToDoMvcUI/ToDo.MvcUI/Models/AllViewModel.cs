using ToDo.MvcUI.Areas.Admin.Models;
using ToDo.MvcUI.Areas.Admin.ViewModels;

namespace ToDo.MvcUI.Models
{
    public class AllViewModel
    {
        public List<UserItem> users {  get; set; }
        public List<ProjectItem> projects {  get; set; }
        public List<ServiceItem> services {  get; set; }
        public List<AboutUsItem> about {  get; set; }
        public List<DepartmentItem> departments {  get; set; }
        public int UserCount { get; set; }
        public int DepartmentCount { get; set; }
        public int ProjectCount { get; set; }
        public int JobCount { get; set; }
        public int ServiceCount { get; set; }
    }
}
