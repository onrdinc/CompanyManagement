using Microsoft.AspNetCore.Mvc;
using ToDo.MvcUI.Areas.Admin.Filters;

namespace ToDo.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class HomeController : Controller
    {
        [SessionAspect]
        [LogAspect]
        public IActionResult Index()
        {
          
            return View();
        }
    }
}
