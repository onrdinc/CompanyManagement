using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Business.Implementations;
using ToDo.Business.Interfaces;
using ToDo.Model.Dto.Milestone;
using ToDo.Model.Dto.User;

namespace ToDo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MilestoneController : BaseController
    {
        private readonly IMilestoneBs _milestoneBs;

        public MilestoneController(IMilestoneBs milestoneBs)
        {
             _milestoneBs = milestoneBs;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<MilestoneGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<MilestoneGetDto>))]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _milestoneBs.GetByIdAsync(id, "Project");
            return await SendResponseAsync(response);



        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<MilestoneGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<MilestoneGetDto>>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {

            var response = await _milestoneBs.GetMilestonesAsync("Project");

            return await SendResponseAsync(response);

        }

        [HttpPost]
        public async Task<IActionResult> SaveNewMilestone([FromBody] MilestonePostDto dto)
        {
            var response = await _milestoneBs.InsertAsync(dto);
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
        public async Task<IActionResult> UpdateMilestone([FromBody] MilestonePutDto dto)
        {
            var response = await _milestoneBs.UpdateAsync(dto);
            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMilestone(int Id)
        {
            var response = await _milestoneBs.DeleteAsync(Id);

            return await SendResponseAsync(response);
        }
    }
}
