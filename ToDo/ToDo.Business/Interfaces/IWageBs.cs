using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model.Dto.Wage;

namespace ToDo.Business.Interfaces
{
    public interface IWageBs
    {
        Task<ApiResponse<List<WageGetDto>>> GetWagesAsync(params string[] includeList);
        Task<ApiResponse<WageGetDto>> GetByIdAsync(int Id, params string[] includeList);
        Task<ApiResponse<WageGetDto>> InsertAsync(WagePostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(WagePutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int Id);
    }
}
