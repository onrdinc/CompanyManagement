using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Business.Interfaces;
using ToDo.Model.Dto.AboutUs;

namespace ToDo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class AboutUsController : BaseController
    {
        private readonly IAboutUsBs _aboutUsBs;
        private readonly IMapper _mapper;

        public AboutUsController(IAboutUsBs aboutUsBs, IMapper mapper)
        {
            _aboutUsBs = aboutUsBs;
            _mapper = mapper;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<AboutUsGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<AboutUsGetDto>))]
        #endregion

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _aboutUsBs.GetByIdAsync(id);
            return await SendResponseAsync(response);

        }


        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<AboutUsGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<AboutUsGetDto>>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetAbouts()
        {
            ;
            var response = await _aboutUsBs.GetAboutUsAsync();

            return await SendResponseAsync(response);

        }


        [HttpPost]
        public async Task<IActionResult> SaveNewAbout([FromBody] AboutUsPostDto dto)
        {
            var response = await _aboutUsBs.InsertAsync(dto);
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
        public async Task<IActionResult> UpdateAbout([FromBody] AboutUsPutDto dto)
        {
            var response = await _aboutUsBs.UpdateAsync(dto);
            return await SendResponseAsync(response);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            var response = await _aboutUsBs.DeleteAsync(id);

            return await SendResponseAsync(response);
        }

    }

}
