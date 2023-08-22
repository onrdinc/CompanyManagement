using Microsoft.AspNetCore.Mvc;
using ToDo.MvcUI.Areas.User.Filters;

namespace ToDo.MvcUI.Areas.User.Controllers
{
    [Area("User")]
    [SessionAspect]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
