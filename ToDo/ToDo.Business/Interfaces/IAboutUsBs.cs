using Infrastructure.Utilities.ApiResponses;
using ToDo.Model.Dto.AboutUs;

namespace ToDo.Business.Interfaces
{
    public interface IAboutUsBs
    {
        Task<ApiResponse<List<AboutUsGetDto>>> GetAboutUsAsync(params string[] includeList);
        Task<ApiResponse<AboutUsGetDto>> GetByIdAsync(int Id, params string[] includeList);
        Task<ApiResponse<AboutUsGetDto>> InsertAsync(AboutUsPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(AboutUsPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int Id);
    }
}
