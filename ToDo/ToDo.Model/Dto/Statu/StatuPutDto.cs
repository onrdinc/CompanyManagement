using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Model.Dto.Milestone
{
    public class StatuPutDto : IDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
