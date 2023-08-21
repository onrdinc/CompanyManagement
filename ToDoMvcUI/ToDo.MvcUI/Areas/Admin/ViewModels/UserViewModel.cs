using ToDo.MvcUI.Areas.Admin.Models;

namespace ToDo.MvcUI.Areas.Admin.ViewModels
{
    public class UserViewModel
    {
        public List<UserItem> Users { get; set; }
        public List<DepartmentItem> Departments { get; set; }
    }
}
