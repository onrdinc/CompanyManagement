using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Business.Interfaces;
using ToDo.Model.Dto.Department;
using ToDo.Model.Dto.Wage;

namespace ToDo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WageController : BaseController
    {
        private readonly IWageBs _wageBs;
        private readonly IMapper _mapper;

        public WageController(IWageBs wageBs, IMapper mapper)
        {
            _wageBs = wageBs;
            _mapper = mapper;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<WageGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<WageGetDto>))]
        #endregion

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _wageBs.GetByIdAsync(id,"User");
            return await SendResponseAsync(response);

        }


        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<WageGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<WageGetDto>>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetWages()
        {
            
            var response = await _wageBs.GetWagesAsync("User");

            return await SendResponseAsync(response);

        }


        [HttpPost]
        public async Task<IActionResult> SaveNewWage([FromBody] WagePostDto dto)
        {
            var response = await _wageBs.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
                return await SendResponseAsync(response);
            else
                return CreatedAtAction(nameof(GetById), new { id = response.Data.Id }, response);

        }

        #region Swagger Doc
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        #endregion
        [HttpPut]
        public async Task<IActionResult> UpdateWage([FromBody] WagePutDto dto)
        {
            var response = await _wageBs.UpdateAsync(dto);
            return await SendResponseAsync(response);



        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWage(int Id)
        {
            var response = await _wageBs.DeleteAsync(Id);

            return await SendResponseAsync(response);
        }

    }

}
