using Infrastructure.Utilities.ApiResponses;
using ToDo.Model.Dto.Contact;

namespace ToDo.Business.Interfaces
{
    public interface IContactBs
    {
        Task<ApiResponse<List<ContactGetDto>>> GetContactsAsync(params string[] includeList);
        Task<ApiResponse<ContactGetDto>> GetByIdAsync(int Id, params string[] includeList);
        Task<ApiResponse<ContactGetDto>> InsertAsync(ContactPostDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int Id);
    }
}
