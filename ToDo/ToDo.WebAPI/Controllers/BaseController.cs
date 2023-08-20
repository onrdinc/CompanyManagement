using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [NonAction] // Bu bir endpoint değil, dolayısıyla clientlar buraya erişemezler
        public async Task<IActionResult> SendResponseAsync<T>(ApiResponse<T> response)
        {
            if (response.StatusCode == StatusCodes.Status204NoContent)
                return new ObjectResult(null) { StatusCode = response.StatusCode };

            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
