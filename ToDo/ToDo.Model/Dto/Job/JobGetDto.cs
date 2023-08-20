using Infrastructure.Model;
using ToDo.Model.Dto.Milestone;
using ToDo.Model.Dto.Project;

namespace ToDo.Model.Dto.Job
{
    public class JobGetDto : IDto
    {
        public int MilestoneId { get; set; }
        public string? JobTitle { get; set; }
        public string? Detail { get; set; }
        public int ProjectId { get; set; }

        public ProjectGetDto? Project { get; set; }
        public MilestoneGetDto? Milestone { get; set; }
    }
}
