using Infrastructure.DataAccess.Interfaces;
using ToDo.Model.Entities;

namespace ToDo.DataAccess.Interfaces
{
    public interface IAboutUsRepository : IBaseRepository<AboutUs>
    {
        Task<AboutUs> GetByIdAsync(int Id, params string[] includeList);

    }
}
