using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using ToDo.Business.Interfaces;
using ToDo.Model.Dto.JobLabel;
using ToDo.Model.Dto.User;

namespace ToDo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobLabelController : BaseController
    {
        private readonly IJobLabelBs _jobLabelBs;

        public JobLabelController(IJobLabelBs jobLabelBs)
        {
            _jobLabelBs = jobLabelBs;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<JobLabelGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<JobLabelGetDto>))]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _jobLabelBs.GetByIdAsync(id, "Project", "Job", "Label");
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

            var response = await _jobLabelBs.GetJobLabelsAsync("Project", "Job", "Label");

            return await SendResponseAsync(response);

        }

        [HttpPost]
        public async Task<IActionResult> SaveNewJobLabel([FromBody] JobLabelPostDto dto)
        {
            var response = await _jobLabelBs.InsertAsync(dto);
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
        public async Task<IActionResult> UpdateJobLabel([FromBody] JobLabelPutDto dto)
        {
            var response = await _jobLabelBs.UpdateAsync(dto);
            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobLabel(int Id)
        {
            var response = await _jobLabelBs.DeleteAsync(Id);

            return await SendResponseAsync(response);
        }
    }
}
