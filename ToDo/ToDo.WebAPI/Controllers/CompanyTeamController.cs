using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Business.Implementations;
using ToDo.Business.Interfaces;
using ToDo.Model.Dto.CompanyTeam;
using ToDo.Model.Dto.Department;
using ToDo.Model.Dto.Project;

namespace ToDo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyTeamController : BaseController
    {
        private readonly ICompanyTeamBs _companyTeamBs;
        private readonly IMapper _mapper;

        public CompanyTeamController(ICompanyTeamBs companyTeamBs,IMapper mapper)
        {
            _companyTeamBs = companyTeamBs;
            _mapper = mapper;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<CompanyTeamGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<CompanyTeamGetDto>))]
        #endregion

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var response = await _companyTeamBs.GetByIdAsync(Id, "Company","Department","User");
            return await SendResponseAsync(response);

        }


        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<CompanyTeamGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<CompanyTeamGetDto>>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            ;
            var response = await _companyTeamBs.GetCompanyTeamsAsync("Company", "Department", "User");

            return await SendResponseAsync(response);
        }


        [HttpPost]
        public async Task<IActionResult> SaveNewCompany([FromBody] CompanyTeamPostDto dto)
        {
            var response = await _companyTeamBs.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
                return await SendResponseAsync(response);
            else
                return CreatedAtAction(nameof(GetById), new { id = response.Data.Id }, response.Data);

        }

        #region Swagger Doc
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        #endregion
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] CompanyTeamPutDto dto)
        {
            var response = await _companyTeamBs.UpdateAsync(dto);
            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            var response = await _companyTeamBs.DeleteAsync(Id);

            return await SendResponseAsync(response);
        }
    }
}
