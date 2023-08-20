using Infrastructure.Utilities.ApiResponses;
using ToDo.Model.Dto.Department;
using ToDo.Model.Entities;

namespace ToDo.Business.Interfaces
{
    public interface IDepartmentBs
    {
        Task<ApiResponse<List<DepartmentGetDto>>> GetDepartmentsAsync(params string[] includeList);
        Task<ApiResponse<DepartmentGetDto>> GetByIdAsync(int Id, params string[] includeList);
        Task<ApiResponse<Department>> InsertAsync(DepartmentPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(DepartmentPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int Id);
    }
}
