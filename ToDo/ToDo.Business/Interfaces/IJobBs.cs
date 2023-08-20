using Infrastructure.Utilities.ApiResponses;
using ToDo.Model.Dto.Job;
using ToDo.Model.Entities;

namespace ToDo.Business.Interfaces
{
    public interface IJobBs
    {
        Task<ApiResponse<List<JobGetDto>>> GetJobsAsync(params string[] includeList);
        Task<ApiResponse<JobGetDto>> GetByIdAsync(int Id, params string[] includeList);
        Task<ApiResponse<Job>> InsertAsync(JobPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(JobPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int Id);
    }
}
