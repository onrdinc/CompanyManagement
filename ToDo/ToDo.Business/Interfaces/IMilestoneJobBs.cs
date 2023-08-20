using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model.Dto.MilestoneJob;
using ToDo.Model.Entities;

namespace ToDo.Business.Interfaces
{
    public interface IMilestoneJobBs
    {
        Task<ApiResponse<List<MilestoneJobGetDto>>> GetMilestoneJobsAsync(params string[] includeList);
        Task<ApiResponse<MilestoneJobGetDto>> GetByIdAsync(int Id, params string[] includeList);
        Task<ApiResponse<MilestoneJob>> InsertAsync(MilestoneJobPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(MilestoneJobPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int Id);
    }
}
