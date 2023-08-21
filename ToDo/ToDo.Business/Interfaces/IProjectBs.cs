using Infrastructure.Utilities.ApiResponses;
using ToDo.Model.Dto.Project;
using ToDo.Model.Dto.User;
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
        Task<ApiResponse<List<ProjectGetDto>>> GetByProjectDepartmentAsync(int departmentId, params string[] includeList);
        Task<ApiResponse<List<ProjectGetDto>>> GetByProjectServiceAsync(int serviceId, params string[] includeList);
    }
}
