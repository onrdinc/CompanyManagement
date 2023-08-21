namespace ToDo.MvcUI.Areas.Admin.Models.Dtos.ProjectParticipant
{
    public class NewProjectParticipantDto
    {
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public string Duty { get; set; }

    }
}
