using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model.Dto.AboutUs;
using ToDo.Model.Dto.Department;

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
