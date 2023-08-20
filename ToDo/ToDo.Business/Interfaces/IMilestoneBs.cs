using Infrastructure.Utilities.ApiResponses;
using ToDo.Model.Dto.Milestone;
using ToDo.Model.Entities;

namespace ToDo.Business.Interfaces
{
    public interface IMilestoneBs
    {
        Task<ApiResponse<List<MilestoneGetDto>>> GetMilestonesAsync(params string[] includeList);
        Task<ApiResponse<MilestoneGetDto>> GetByIdAsync(int Id, params string[] includeList);
        Task<ApiResponse<Milestone>> InsertAsync(MilestonePostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(MilestonePutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int Id);
    }
}
