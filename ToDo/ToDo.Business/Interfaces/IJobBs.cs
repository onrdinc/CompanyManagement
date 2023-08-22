using Infrastructure.Utilities.ApiResponses;
using ToDo.Model.Dto.Job;
using ToDo.Model.Dto.User;
using ToDo.Model.Entities;

namespace ToDo.Business.Interfaces
{
    public interface IJobBs
    {
        Task<ApiResponse<List<JobGetDto>>> GetJobsAsync(params string[] includeList);
        Task<ApiResponse<JobGetDto>> GetByIdAsync(int Id, params string[] includeList);
        Task<ApiResponse<JobGetDto>> InsertAsync(JobPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(JobPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int Id);
        Task<ApiResponse<List<JobGetDto>>> GetByProjectJobAsync(int projectId, params string[] includeList);
        Task<ApiResponse<List<JobGetDto>>> GetByUserJobAsync(int userId, params string[] includeList);
    }
}
