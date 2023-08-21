namespace ToDo.MvcUI.Areas.Admin.Models.Dtos.Job
{
    public class NewJobDto
    {
        public int StatuId { get; set; }
        public string? JobTitle { get; set; }
        public string? Detail { get; set; }
        public int ProjectId { get; set; }
        public int LabelId { get; set; }
        public int UserId { get; set; }
    }
}
