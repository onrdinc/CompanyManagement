using Infrastructure.Utilities.ApiResponses;
using ToDo.Model.Dto.Project;
using ToDo.Model.Entities;

namespace ToDo.Business.Interfaces
{
    public interface IProjectBs
    {
        Task<ApiResponse<List<ProjectGetDto>>> GetProjectsAsync(params string[] includeList);
        Task<ApiResponse<ProjectGetDto>> GetByIdAsync(int Id, params string[] includeList);
        Task<ApiResponse<ProjectGetDto>> InsertAsync(ProjectPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(ProjectPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int Id);
    }
}
