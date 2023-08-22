using Infrastructure.Model;

namespace ToDo.Model.Dto.Department
{
    public class DepartmentGetDto : IDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
