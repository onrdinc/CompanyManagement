namespace ToDo.MvcUI.Areas.Admin.Models
{
    public class WageItem
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public UserItem User { get; set; }
    }
}
