using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Business.Implementations;
using ToDo.Business.Interfaces;
using ToDo.Model.Dto.Job;
using ToDo.Model.Dto.User;

namespace ToDo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : BaseController
    {
        private readonly IJobBs _jobBs;

        public JobController(IJobBs jobBs)
        {
            _jobBs = jobBs;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<JobGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<JobGetDto>))]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _jobBs.GetByIdAsync(id, "Project", "Milestone");
            return await SendResponseAsync(response);



        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<JobGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<JobGetDto>>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {

            var response = await _jobBs.GetJobsAsync("Project", "Milestone");

            return await SendResponseAsync(response);

        }

        [HttpPost]
        public async Task<IActionResult> SaveNewJob([FromBody] JobPostDto dto)
        {
            var response = await _jobBs.InsertAsync(dto);
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
        public async Task<IActionResult> UpdateJob([FromBody] JobPutDto dto)
        {
            var response = await _jobBs.UpdateAsync(dto);
            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int Id)
        {
            var response = await _jobBs.DeleteAsync(Id);

            return await SendResponseAsync(response);
        }
    }
}
