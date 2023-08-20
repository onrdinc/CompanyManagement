using Infrastructure.Model;
using ToDo.Model.Dto.Company;

namespace ToDo.Model.Dto.Department
{
    public class DepartmentGetDto : IDto
    {
        public int CompanyId { get; set; }
        public string? Name { get; set; }
        public CompanyGetDto? Company { get; set; }

    }
}
