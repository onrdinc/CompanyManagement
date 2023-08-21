using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserBs _userBs;

        public UserController(IUserBs userBs)
        {
            _userBs = userBs;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<UserGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<UserGetDto>))]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response =await _userBs.GetByIdAsync(id,"Department");
            return await SendResponseAsync(response);



        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<UserGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<UserGetDto>>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            
            var response =await _userBs.GetUsersAsync("Department");

            return await SendResponseAsync(response);

        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<UserGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        #endregion

        [HttpPost]
        public async Task<IActionResult> SaveNewUser([FromBody] UserPostDto dto)
        {
            var response = await _userBs.InsertAsync(dto);
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
        public async Task<IActionResult> UpdateUser([FromBody] UserPutDto dto)
        {
            var response = await _userBs.UpdateAsync(dto);
            return await SendResponseAsync(response);



        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            var response = await _userBs.DeleteAsync(Id);

            return await SendResponseAsync(response);
        }


    }
}
