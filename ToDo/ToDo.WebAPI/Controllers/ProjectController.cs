using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Business.Interfaces;
using ToDo.Model.Dto.Project;

namespace ToDo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectController : BaseController
    {
        private readonly IProjectBs _projectBs;
        private readonly IMapper _mapper;
        public ProjectController(IProjectBs projectBs, IMapper mapper)
        {
            _projectBs = projectBs;
            _mapper = mapper;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<ProjectGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<ProjectGetDto>))]
        #endregion

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var response = await _projectBs.GetByIdAsync(Id, "Service","Department");
            return await SendResponseAsync(response);

        }


        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<ProjectGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<ProjectGetDto>>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            ;
            var response = await _projectBs.GetProjectsAsync("Service", "Department");

            return await SendResponseAsync(response);

        }


        [HttpPost]
        public async Task<IActionResult> SaveNewProject([FromBody] ProjectPostDto dto)
        {
            var response = await _projectBs.InsertAsync(dto);
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
        public async Task<IActionResult> UpdateProject([FromBody] ProjectPutDto dto)
        {
            var response = await _projectBs.UpdateAsync(dto);
            return await SendResponseAsync(response);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int Id)
        {
            var response = await _projectBs.DeleteAsync(Id);

            return await SendResponseAsync(response);
        }
    }
}
