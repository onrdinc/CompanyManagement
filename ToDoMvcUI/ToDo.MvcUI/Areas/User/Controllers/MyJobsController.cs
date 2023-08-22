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
    public class MyJobsController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        public MyJobsController(IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var jobResponse =  await _httpApiService.GetData<ResponseBody<List<JobItem>>>($"/job/getByUserId?id={id}", token.Token);

            JobViewModel vm = new JobViewModel();
            vm.Jobs = jobResponse.Data;
            return View(vm);
        }
    }
}
