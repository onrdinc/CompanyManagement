using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Business.Implementations;
using ToDo.Business.Interfaces;
using ToDo.Model.Dto.Label;
using ToDo.Model.Dto.User;

namespace ToDo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelController : BaseController
    {
        private readonly ILabelBs _labelBs;
        public LabelController(ILabelBs labelBs)
        {
            _labelBs = labelBs;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<LabelGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<LabelGetDto>))]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _labelBs.GetByIdAsync(id, "Project");
            return await SendResponseAsync(response);



        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<LabelGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<LabelGetDto>>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetLabels()
        {

            var response = await _labelBs.GetLabelsAsync("Project");

            return await SendResponseAsync(response);

        }

        [HttpPost]
        public async Task<IActionResult> SaveNewLabel([FromBody] LabelPostDto dto)
        {
            var response = await _labelBs.InsertAsync(dto);
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
        public async Task<IActionResult> UpdateLabel([FromBody] LabelPutDto dto)
        {
            var response = await _labelBs.UpdateAsync(dto);
            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLabel(int Id)
        {
            var response = await _labelBs.DeleteAsync(Id);

            return await SendResponseAsync(response);
        }
    }
}
