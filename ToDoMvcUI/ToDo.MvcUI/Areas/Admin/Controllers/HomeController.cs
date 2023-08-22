using Microsoft.AspNetCore.Mvc;
using ToDo.MvcUI.Areas.Admin.Extensions;
using ToDo.MvcUI.Areas.Admin.Filters;
using ToDo.MvcUI.Areas.Admin.HttpApiServices;
using ToDo.MvcUI.Areas.Admin.Models;
using ToDo.MvcUI.Areas.Admin.ViewModels;

namespace ToDo.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionAspect]

    public class HomeController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        public HomeController( IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }

        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");
            var userResponse = await _httpApiService.GetData<ResponseBody<List<UserItem>>>("/user", token.Token);
            var departmentResponse = await _httpApiService.GetData<ResponseBody<List<DepartmentItem>>>("/department", token.Token);
            var projectResponse = await _httpApiService.GetData<ResponseBody<List<ProjectItem>>>("/project", token.Token);
            var serviceResponse = await _httpApiService.GetData<ResponseBody<List<ProjectItem>>>("/service", token.Token);
            var jobResponse = await _httpApiService.GetData<ResponseBody<List<ProjectItem>>>("/job", token.Token);

            StatisticsViewModel vm = new StatisticsViewModel();
            vm.UserCount = userResponse.Count;
            vm.DepartmentCount = departmentResponse.Count;
            vm.ProjectCount = projectResponse.Count;
            vm.JobCount = jobResponse.Count;
            vm.ServiceCount = serviceResponse.Count;
            return View(vm);
        }
    }
}
