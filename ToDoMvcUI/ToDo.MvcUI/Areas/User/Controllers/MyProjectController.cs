using Microsoft.AspNetCore.Mvc;
using ToDo.MvcUI.Areas.Admin.Extensions;
using ToDo.MvcUI.Areas.Admin.HttpApiServices;
using ToDo.MvcUI.Areas.Admin.Models;
using ToDo.MvcUI.Areas.Admin.ViewModels;
using ToDo.MvcUI.Areas.User.Filters;

namespace ToDo.MvcUI.Areas.User.Controllers
{
    [Area("User")]
    [SessionAspect]
    public class MyProjectController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        public MyProjectController(IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var projectResponse = await _httpApiService.GetData<ResponseBody<List<ProjectParticipantItem>>>($"/projectparticipant/getByUserId?id={id}", token.Token);

            ProjectParticipantViewModel vm = new ProjectParticipantViewModel();
            vm.ProjectParticipants = projectResponse.Data;
            return View(vm);
        }
    }
}
