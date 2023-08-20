using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Business.Implementations;
using ToDo.Business.Interfaces;
using ToDo.Model.Dto.MilestoneJob;
using ToDo.Model.Dto.User;

namespace ToDo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MilestoneJobController : BaseController
    {
        private readonly IMilestoneJobBs _milestoneJobBs;

        public MilestoneJobController(IMilestoneJobBs milestoneJobBs)
        {
            _milestoneJobBs = milestoneJobBs;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<MilestoneJobGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<MilestoneJobGetDto>))]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _milestoneJobBs.GetByIdAsync(id, "Milestone", "Job");
            return await SendResponseAsync(response);



        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<MilestoneJobGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<MilestoneJobGetDto>>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetMilestoneJobs()
        {

            var response = await _milestoneJobBs.GetMilestoneJobsAsync("Milestone", "Job");

            return await SendResponseAsync(response);

        }

        [HttpPost]
        public async Task<IActionResult> SaveNewUser([FromBody] MilestoneJobPostDto dto)
        {
            var response = await _milestoneJobBs.InsertAsync(dto);
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
        public async Task<IActionResult> UpdateJobs([FromBody] MilestoneJobPutDto dto)
        {
            var response = await _milestoneJobBs.UpdateAsync(dto);
            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobs(int Id)
        {
            var response = await _milestoneJobBs.DeleteAsync(Id);

            return await SendResponseAsync(response);
        }
    }
}
