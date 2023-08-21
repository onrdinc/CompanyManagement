using Infrastructure.Utilities.ApiResponses;
using ToDo.Model.Dto.Service;

namespace ToDo.Business.Interfaces
{
    public interface IServiceBs
    {
        Task<ApiResponse<List<ServiceGetDto>>> GetServicesAsync(params string[] includeList);
        Task<ApiResponse<ServiceGetDto>> GetByIdAsync(int Id, params string[] includeList);
        Task<ApiResponse<ServiceGetDto>> InsertAsync(ServicePostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(ServicePutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int Id);
    }
}
