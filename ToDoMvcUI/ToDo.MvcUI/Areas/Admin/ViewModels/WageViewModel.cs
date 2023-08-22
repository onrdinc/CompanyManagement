using ToDo.MvcUI.Areas.Admin.Models;

namespace ToDo.MvcUI.Areas.Admin.ViewModels
{
    public class WageViewModel
    {
        public List<WageItem> Wages { get; set; }
        public List<UserItem> Users { get; set; }
    }
}
