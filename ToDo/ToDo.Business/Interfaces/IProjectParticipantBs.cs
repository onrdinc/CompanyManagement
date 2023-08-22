using Infrastructure.Utilities.ApiResponses;
using ToDo.Model.Dto.Job;
using ToDo.Model.Dto.ProjectParticipant;
using ToDo.Model.Dto.User;
using ToDo.Model.Entities;

namespace ToDo.Business.Interfaces
{
    public interface IProjectParticipantBs
    {
        Task<ApiResponse<List<ProjectParticipantGetDto>>> GetUsersAsync(params string[] includeList);
        Task<ApiResponse<ProjectParticipantGetDto>> GetByIdAsync(int Id, params string[] includeList);
        Task<ApiResponse<ProjectParticipantGetDto>> InsertAsync(ProjectParticipantPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(ProjectParticipantPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int Id);
        Task<ApiResponse<List<ProjectParticipantGetDto>>> GetByParticipantAsync(int projectId, params string[] includeList);
        Task<ApiResponse<List<ProjectParticipantGetDto>>> GetByUserProjectAsync(int userId, params string[] includeList);

    }
}
