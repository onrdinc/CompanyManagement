using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Business.Implementations;
using ToDo.Business.Interfaces;
using ToDo.Model.Dto.Department;
using ToDo.Model.Dto.Service;

namespace ToDo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : BaseController
    {
        private readonly IServiceBs _serviceBs;
        private readonly IMapper _mapper;

        public ServiceController(IServiceBs serviceBs, IMapper mapper)
        {
            _serviceBs = serviceBs;
            _mapper = mapper;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<ServiceGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<ServiceGetDto>))]
        #endregion

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var response = await _serviceBs.GetByIdAsync(Id);
            return await SendResponseAsync(response);

        }


        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<ServiceGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<ServiceGetDto>>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetServices()
        {
            ;
            var response = await _serviceBs.GetServicesAsync();

            return await SendResponseAsync(response);

        }


        [HttpPost]
        public async Task<IActionResult> SaveNewService([FromBody] ServicePostDto dto)
        {
            var response = await _serviceBs.InsertAsync(dto);
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
        public async Task<IActionResult> UpdateDepartment([FromBody] ServicePutDto dto)
        {
            var response = await _serviceBs.UpdateAsync(dto);
            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int Id)
        {
            var response = await _serviceBs.DeleteAsync(Id);

            return await SendResponseAsync(response);
        }
    }
}
