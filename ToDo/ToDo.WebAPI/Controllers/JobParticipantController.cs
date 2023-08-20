using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Business.Implementations;
using ToDo.Business.Interfaces;
using ToDo.Model.Dto.JobParticipant;
using ToDo.Model.Dto.User;

namespace ToDo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobParticipantController : BaseController
    {
        private readonly IJobParticipantBs _jobParticipantBs;

        public JobParticipantController(IJobParticipantBs jobParticipantBs)
        {
            _jobParticipantBs = jobParticipantBs;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<JobParticipantGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<JobParticipantGetDto>))]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _jobParticipantBs.GetByIdAsync(id, "Project", "Job", "User");
            return await SendResponseAsync(response);



        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<JobParticipantGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<JobParticipantGetDto>>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {

            var response = await _jobParticipantBs.GetUsersAsync("Project", "Job", "User");

            return await SendResponseAsync(response);

        }

        [HttpPost]
        public async Task<IActionResult> SaveNewUser([FromBody] JobParticipantPostDto dto)
        {
            var response = await _jobParticipantBs.InsertAsync(dto);
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
        public async Task<IActionResult> UpdateUser([FromBody] JobParticipantPutDto dto)
        {
            var response = await _jobParticipantBs.UpdateAsync(dto);
            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            var response = await _jobParticipantBs.DeleteAsync(Id);

            return await SendResponseAsync(response);
        }
    }
}
