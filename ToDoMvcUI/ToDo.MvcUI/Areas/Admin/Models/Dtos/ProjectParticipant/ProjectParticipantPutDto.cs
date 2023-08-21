namespace ToDo.MvcUI.Areas.Admin.Models.Dtos.ProjectParticipant
{
    public class ProjectParticipantPutDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public string Duty { get; set; }

    }
}
