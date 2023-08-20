using Infrastructure.Utilities.ApiResponses;
using ToDo.Model.Dto.Company;
using ToDo.Model.Entities;

namespace ToDo.Business.Interfaces
{
    public interface ICompanyBs
    {
        Task<ApiResponse<List<CompanyGetDto>>> GetCompanysAsync(params string[] includeList);
        Task<ApiResponse<CompanyGetDto>> GetByIdAsync(int Id, params string[] includeList);
        Task<ApiResponse<Company>> InsertAsync(CompanyPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(CompanyPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int Id);
    }
}
