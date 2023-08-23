using Microsoft.AspNetCore.Mvc;
using ToDo.MvcUI.Areas.Admin.HttpApiServices;
using ToDo.MvcUI.Areas.Admin.Models;
using ToDo.MvcUI.Models;

namespace ToDo.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        public HomeController(IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }

        public async Task<IActionResult> Index()
        {
            var userResponse = await _httpApiService.GetData<ResponseBody<List<UserItem>>>("/user");
            var departmentResponse = await _httpApiService.GetData<ResponseBody<List<DepartmentItem>>>("/department");
            var projectResponse = await _httpApiService.GetData<ResponseBody<List<ProjectItem>>>("/project");
            var serviceResponse = await _httpApiService.GetData<ResponseBody<List<ServiceItem>>>("/service");
            var jobResponse = await _httpApiService.GetData<ResponseBody<List<ProjectItem>>>("/job");
            var aboutResponse = await _httpApiService.GetData<ResponseBody<List<AboutUsItem>>>("/aboutus");

            AllViewModel vm = new AllViewModel();
            vm.users = userResponse.Data;
            vm.departments = departmentResponse.Data;
            vm.projects = projectResponse.Data;
            vm.services = serviceResponse.Data;
            vm.about = aboutResponse.Data;
            vm.UserCount = userResponse.Data.Count;
            vm.DepartmentCount = departmentResponse.Data.Count;
            vm.ProjectCount = projectResponse.Data.Count;
            vm.JobCount = jobResponse.Data.Count;
            vm.ServiceCount = serviceResponse.Data.Count;

            return View(vm);
        }

    }
}