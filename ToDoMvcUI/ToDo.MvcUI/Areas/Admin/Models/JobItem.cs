namespace ToDo.MvcUI.Areas.Admin.Models
{
    public class JobItem
    {
        public int Id { get; set; }
        public string? JobTitle { get; set; }
        public string? Detail { get; set; }
        public StatuItem Statu { get; set; }
        public ProjectItem Project { get; set; }
        public LabelItem Label { get; set; }
        public UserItem User { get; set; }
    }
}
