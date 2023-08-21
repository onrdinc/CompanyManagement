using Infrastructure.Utilities.ApiResponses;
using ToDo.Model.Dto.Milestone;
using ToDo.Model.Entities;

namespace ToDo.Business.Interfaces
{
    public interface IStatuBs
    {
        Task<ApiResponse<List<StatuGetDto>>> GetStatusAsync(params string[] includeList);
        Task<ApiResponse<StatuGetDto>> GetByIdAsync(int Id, params string[] includeList);
        Task<ApiResponse<StatuGetDto>> InsertAsync(StatuPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(StatuPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int Id);
    }
}
