using ToDo.MvcUI.Areas.Admin.Models;

namespace ToDo.MvcUI.Areas.Admin.ViewModels
{
    public class ProjectParticipantViewModel
    {
        public List<ProjectParticipantItem> ProjectParticipants { get; set; }
        public List<UserItem> Users { get; set; }
        public List<ProjectItem> Projects { get; set; }
    }
}
