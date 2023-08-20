using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model.Dto.JobLabel;
using ToDo.Model.Dto.User;
using ToDo.Model.Entities;

namespace ToDo.Business.Interfaces
{
    public interface IJobLabelBs
    {
        Task<ApiResponse<List<JobLabelGetDto>>> GetJobLabelsAsync(params string[] includeList);
        Task<ApiResponse<JobLabelGetDto>> GetByIdAsync(int Id, params string[] includeList);
        Task<ApiResponse<JobLabel>> InsertAsync(JobLabelPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(JobLabelPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int Id);
    }
}
