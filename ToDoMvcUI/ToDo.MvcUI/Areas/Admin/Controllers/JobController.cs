using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ToDo.MvcUI.Areas.Admin.Extensions;
using ToDo.MvcUI.Areas.Admin.Filters;
using ToDo.MvcUI.Areas.Admin.HttpApiServices;
using ToDo.MvcUI.Areas.Admin.Models;
using ToDo.MvcUI.Areas.Admin.Models.Dtos.Job;
using ToDo.MvcUI.Areas.Admin.Models.Dtos.ProjectDtos;
using ToDo.MvcUI.Areas.Admin.Models.Dtos.ProjectParticipant;
using ToDo.MvcUI.Areas.Admin.ViewModels;

namespace ToDo.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionAspect]
    public class JobController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        public JobController(IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

  
            var projectResponse = await _httpApiService.GetData<ResponseBody<List<ProjectItem>>>("/project", token.Token);
            var labelResponse = await _httpApiService.GetData<ResponseBody<List<LabelItem>>>("/label", token.Token);
            var statuResponse = await _httpApiService.GetData<ResponseBody<List<StatuItem>>>("/statu", token.Token);
            var userResponse = await _httpApiService.GetData<ResponseBody<List<UserItem>>>("/user", token.Token);
            var jobResponse = await _httpApiService.GetData<ResponseBody<List<JobItem>>>("/job", token.Token);
            //List<ProjectParticipantItem> users = new List<ProjectParticipantItem>(); 
            //foreach (var item in projectResponse.Data)
            //{
            //    foreach (var user in userResponse.Data)
            //    {
            //        if(item.Id == user.Project.Id)
            //        {
            //            users.Add(user);
            //        }
            //    }
            //}
            JobViewModel vm = new JobViewModel();
            //vm.Users = users;
            vm.Users = userResponse.Data;
            vm.Labels = labelResponse.Data;
            vm.Statuses = statuResponse.Data;
            vm.Jobs = jobResponse.Data;
            vm.Projects = projectResponse.Data;
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> GetJob(int id)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var response =
              await _httpApiService.GetData<ResponseBody<JobItem>>($"/job/{id}", token.Token);

            return Json(new { 
                JobTitle = response.Data.JobTitle, 
                Detail = response.Data.Detail, 
                StatuId = response.Data.Statu.Id, 
                LabelId = response.Data.Label.Id, 
                LabelName = response.Data.Label.Name, 
                StatuName = response.Data.Statu.Name, 
                ProjectName = response.Data.Project.Name, 
                ProjectId = response.Data.Project.Id,
                UserId = response.Data.User.Id,
                UserNameSurname = response.Data.User.Name +" "+ response.Data.User.Surname
            });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var response = await _httpApiService.DeleteData<ResponseBody<NoData>>($"/job/{id}", token.Token);

            if (response.StatusCode == 200)
                return Json(new { IsSuccess = true, Message = "Kayıt Başarıyla Silindi" });

            return Json(new { IsSuccess = false, Message = "Kayıt Silinemedi", ErrorMessages = response.ErrorMessages });
        }

        public async Task<IActionResult> Save(NewJobDto dto)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            //anonim nesne
            var postObj = new
            {
                JobTitle = dto.JobTitle,
                Detail = dto.Detail,
                LabelId = dto.LabelId,
                StatuId = dto.StatuId,
                ProjectId = dto.ProjectId,
                UserId = dto.UserId,

            };

            var response = await _httpApiService.PostData<ResponseBody<JobItem>>("/job", JsonSerializer.Serialize(postObj), token.Token);

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

        public async Task<IActionResult> Update(JobPutDto dto)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            //anonim nesne
            var postObj = new
            {
                Id = dto.Id,
                JobTitle = dto.JobTitle,
                Detail = dto.Detail,
                LabelId = dto.LabelId,
                StatuId = dto.StatuId,
                ProjectId = dto.ProjectId,
                UserId = dto.UserId,

            };

            var response = await _httpApiService.PutData<ResponseBody<JobItem>>("/job", JsonSerializer.Serialize(postObj), token.Token);

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
