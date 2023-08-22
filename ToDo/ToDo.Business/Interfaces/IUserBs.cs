using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model.Dto.AdminUser;
using ToDo.Model.Dto.Department;
using ToDo.Model.Dto.Project;
using ToDo.Model.Dto.User;
using ToDo.Model.Entities;

namespace ToDo.Business.Interfaces
{
    public interface IUserBs
    {
        Task<ApiResponse<List<UserGetDto>>> GetUsersAsync(params string[] includeList);
        Task<ApiResponse<UserGetDto>> GetByIdAsync(int Id, params string[] includeList);
        Task<ApiResponse<UserGetDto>> InsertAsync(UserPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(UserPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int Id);
        Task<ApiResponse<List<UserGetDto>>> GetByDepartmentAsync(int departmentId, params string[] includeList);
        Task<ApiResponse<UserGetDto>> LogIn(string nickname, string password, params string[] includeList);

    }
}
