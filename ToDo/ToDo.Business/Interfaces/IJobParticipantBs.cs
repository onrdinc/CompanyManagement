using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model.Dto.JobParticipant;
using ToDo.Model.Dto.User;
using ToDo.Model.Entities;

namespace ToDo.Business.Interfaces
{
    public interface IJobParticipantBs
    {
        Task<ApiResponse<List<JobParticipantGetDto>>> GetUsersAsync(params string[] includeList);
        Task<ApiResponse<JobParticipantGetDto>> GetByIdAsync(int Id, params string[] includeList);
        Task<ApiResponse<JobParticipant>> InsertAsync(JobParticipantPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(JobParticipantPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int Id);
    }
}
