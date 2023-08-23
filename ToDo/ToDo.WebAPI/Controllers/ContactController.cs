using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Business.Implementations;
using ToDo.Business.Interfaces;
using ToDo.Model.Dto.Contact;
using ToDo.Model.Dto.Department;

namespace ToDo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ContactController : BaseController
    {
        private readonly IContactBs _contactBs;
        private readonly IMapper _mapper;

        public ContactController(IContactBs contactBs, IMapper mapper)
        {
            _contactBs = contactBs;
            _mapper = mapper;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<ContactGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<ContactGetDto>))]
        #endregion

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _contactBs.GetByIdAsync(id);
            return await SendResponseAsync(response);

        }


        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<ContactGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<ContactGetDto>>))]
        #endregion
        [HttpGet]
        [AllowAnonymous]

        public async Task<IActionResult> GetContacts()
        {
            ;
            var response = await _contactBs.GetContactsAsync();

            return await SendResponseAsync(response);

        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SaveNewContact([FromBody] ContactPostDto dto)
        {
            var response = await _contactBs.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
                return await SendResponseAsync(response);
            else
                return CreatedAtAction(nameof(GetById), new { id = response.Data.Id }, response);

        }

      

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var response = await _contactBs.DeleteAsync(id);

            return await SendResponseAsync(response);
        }
    }
}
