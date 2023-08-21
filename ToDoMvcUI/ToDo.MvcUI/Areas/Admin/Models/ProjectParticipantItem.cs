namespace ToDo.MvcUI.Areas.Admin.Models
{
    public class ProjectParticipantItem
    {
        public int Id { get; set; }
        public ProjectItem Project { get; set; }
        public UserItem User { get; set; }
        public string Duty { get; set; }

    }
}
