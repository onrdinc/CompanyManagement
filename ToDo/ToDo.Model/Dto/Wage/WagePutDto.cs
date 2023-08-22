using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Model.Dto.Wage
{
    public class WagePutDto : IDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
    }
}
