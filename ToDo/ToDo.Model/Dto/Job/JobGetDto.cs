using Infrastructure.Model;
using ToDo.Model.Dto.Label;
using ToDo.Model.Dto.Milestone;
using ToDo.Model.Dto.Project;
using ToDo.Model.Dto.ProjectParticipant;
using ToDo.Model.Dto.User;

namespace ToDo.Model.Dto.Job
{
    public class JobGetDto : IDto
    {
        public int Id { get; set; }
        public string? JobTitle { get; set; }
        public string? Detail { get; set; }

        public ProjectGetDto? Project { get; set; }
        public StatuGetDto? Statu { get; set; }
        public LabelGetDto? Label { get; set; }
        public UserGetDto? User { get; set; }
        public int JobCount { get; set; }

    }
}
