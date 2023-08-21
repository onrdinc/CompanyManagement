using ToDo.MvcUI.Areas.Admin.Models;

namespace ToDo.MvcUI.Areas.Admin.ViewModels
{
    public class JobViewModel
    {
        public List<LabelItem> Labels { get; set; }
        public List<StatuItem> Statuses { get; set; }
        public List<ProjectItem> Projects { get; set; }
        public List<JobItem> Jobs { get; set; }
        public List<UserItem> Users { get; set; }
    }
}
