﻿using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Business.Interfaces;
using ToDo.Model.Dto.Department;
using ToDo.Model.Dto.Project;

namespace ToDo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentBs _departmentBs;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentBs departmentBs,IMapper mapper)
        {
            _departmentBs = departmentBs;
            _mapper = mapper;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<DepartmentGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<DepartmentGetDto>))]
        #endregion

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var response = await _departmentBs.GetByIdAsync(Id, "Company");
            return await SendResponseAsync(response);

        }


        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<DepartmentGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<DepartmentGetDto>>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            ;
            var response = await _departmentBs.GetDepartmentsAsync("Company");

            return await SendResponseAsync(response);

        }


        [HttpPost]
        public async Task<IActionResult> SaveNewCompany([FromBody] DepartmentPostDto dto)
        {
            var response = await _departmentBs.InsertAsync(dto);
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
        public async Task<IActionResult> UpdateProduct([FromBody] DepartmentPutDto dto)
        {
            var response = await _departmentBs.UpdateAsync(dto);
            return await SendResponseAsync(response);



        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            var response = await _departmentBs.DeleteAsync(Id);

            return await SendResponseAsync(response);
        }

    }
}
