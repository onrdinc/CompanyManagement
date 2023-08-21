using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ToDo.MvcUI.Areas.Admin.Extensions;
using ToDo.MvcUI.Areas.Admin.Filters;
using ToDo.MvcUI.Areas.Admin.HttpApiServices;
using ToDo.MvcUI.Areas.Admin.Models;
using ToDo.MvcUI.Areas.Admin.Models.Dtos.ProjectDtos;
using ToDo.MvcUI.Areas.Admin.Models.Dtos.ProjectParticipant;
using ToDo.MvcUI.Areas.Admin.ViewModels;

namespace ToDo.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionAspect]
    public class ProjectParticipantController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpApiService _httpApiService;
        public ProjectParticipantController(IWebHostEnvironment webHostEnvironment, IHttpApiService httpApiService)
        {
            _webHostEnvironment = webHostEnvironment;
            _httpApiService = httpApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var userResponse = await _httpApiService.GetData<ResponseBody<List<UserItem>>>("/user", token.Token);

            var participantResponse = id == null
  ? await _httpApiService.GetData<ResponseBody<List<ProjectParticipantItem>>>("/ProjectParticipant", token.Token)
  : await _httpApiService.GetData<ResponseBody<List<ProjectParticipantItem>>>($"/projectparticipant/getByProjectId?id={id}", token.Token);

            //var participantResponse = await _httpApiService.GetData<ResponseBody<List<ProjectParticipantItem>>>("/ProjectParticipant", token.Token);
            var projectResponse = await _httpApiService.GetData<ResponseBody<List<ProjectItem>>>("/project", token.Token);
            ProjectParticipantViewModel vm = new ProjectParticipantViewModel();
            vm.Users = userResponse.Data;
            vm.ProjectParticipants = participantResponse.Data;
            vm.Projects = projectResponse.Data;
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> GetProjectParticipant(int id)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var response =
              await _httpApiService.GetData<ResponseBody<ProjectParticipantItem>>($"/projectparticipant/{id}", token.Token);

            return Json(new { 
                Duty = response.Data.Duty, 
                UserId = response.Data.User.Id,
                PicturePath = response.Data.User.PicturePath, 
                ProjectId = response.Data.Project.Id, 
                ProjectName = response.Data.Project.Name, 
                UserNameSurname = response.Data.User.Name +" "+ response.Data.User.Surname,  });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var response = await _httpApiService.DeleteData<ResponseBody<NoData>>($"/projectparticipant/{id}", token.Token);

            if (response.StatusCode == 200)
                return Json(new { IsSuccess = true, Message = "Kayıt Başarıyla Silindi" });

            return Json(new { IsSuccess = false, Message = "Kayıt Silinemedi", ErrorMessages = response.ErrorMessages });
        }

        public async Task<IActionResult> Save(NewProjectParticipantDto dto)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            //anonim nesne
            var postObj = new
            {
                Duty = dto.Duty,
                UserId = dto.UserId,
                ProjectId = dto.ProjectId,
               

            };

            var response = await _httpApiService.PostData<ResponseBody<ProjectParticipantItem>>("/projectparticipant", JsonSerializer.Serialize(postObj), token.Token);

            //ya da response.statuscode == 201
            if (response.StatusCode.ToString().StartsWith("2"))
            {
                return Json(new { IsSuccess = true, Message = "Başarıyla Kaydedildi", Id = response.Data.Id });

            }
            else
            {
                return Json(new { IsSuccess = false, Messages = response.ErrorMessages });
            }
        }

        public async Task<IActionResult> Update(ProjectParticipantPutDto dto)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            //anonim nesne
            var postObj = new
            {
                Id = dto.Id,
                Duty = dto.Duty,
                UserId = dto.UserId,
                ProjectId = dto.ProjectId,
            };

            var response = await _httpApiService.PutData<ResponseBody<ProjectParticipantItem>>("/projectparticipant", JsonSerializer.Serialize(postObj), token.Token);

            //ya da response.statuscode == 201
            if (response.StatusCode.ToString().StartsWith("2"))
            {
                return Json(new { IsSuccess = true, Message = "Başarıyla Güncellendi" });

            }
            else
            {
                return Json(new { IsSuccess = false, Messages = response.ErrorMessages });
            }





        }

    }
}
