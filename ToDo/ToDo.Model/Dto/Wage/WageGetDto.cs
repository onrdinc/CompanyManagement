using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model.Dto.User;

namespace ToDo.Model.Dto.Wage
{
    public class WageGetDto : IDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public UserGetDto User { get; set; }
    }
}
