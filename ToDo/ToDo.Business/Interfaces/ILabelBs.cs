using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model.Dto.Label;
using ToDo.Model.Dto.User;
using ToDo.Model.Entities;

namespace ToDo.Business.Interfaces
{
    public interface ILabelBs
    {
        Task<ApiResponse<List<LabelGetDto>>> GetLabelsAsync(params string[] includeList);
        Task<ApiResponse<LabelGetDto>> GetByIdAsync(int Id, params string[] includeList);
        Task<ApiResponse<LabelGetDto>> InsertAsync(LabelPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(LabelPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int Id);
    }
}
