using Infrastructure.Utilities.ApiResponses;
using ToDo.Model.Dto.CompanyTeam;
using ToDo.Model.Entities;

namespace ToDo.Business.Interfaces
{
    public interface ICompanyTeamBs
    {
        Task<ApiResponse<List<CompanyTeamGetDto>>> GetCompanyTeamsAsync(params string[] includeList);
        Task<ApiResponse<CompanyTeamGetDto>> GetByIdAsync(int Id, params string[] includeList);
        Task<ApiResponse<CompanyTeam>> InsertAsync(CompanyTeamPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(CompanyTeamPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int Id);
    }
}
