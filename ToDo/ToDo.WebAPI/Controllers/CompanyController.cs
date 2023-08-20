using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Business.Implementations;
using ToDo.Business.Interfaces;
using ToDo.Model.Dto.Company;
using ToDo.Model.Dto.User;
using ToDo.Model.Entities;

namespace ToDo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : BaseController
    {
        private readonly ICompanyBs _companyBs;

        public CompanyController(ICompanyBs companyBs)
        {
            _companyBs = companyBs;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<CompanyGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<CompanyGetDto>))]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _companyBs.GetByIdAsync(id);
            return await SendResponseAsync(response);



        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<CompanyGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<CompanyGetDto>>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {

            var response = await _companyBs.GetCompanysAsync();

            return await SendResponseAsync(response);

        }

        [HttpPost]
        public async Task<IActionResult> SaveNewCompany([FromBody] CompanyPostDto dto)
        {
            var response = await _companyBs.InsertAsync(dto);
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
        public async Task<IActionResult> UpdateCompany([FromBody] CompanyPutDto dto)
        {
            var response = await _companyBs.UpdateAsync(dto);
            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int Id)
        {
            var response = await _companyBs.DeleteAsync(Id);

            return await SendResponseAsync(response);
        }
    }
}


      