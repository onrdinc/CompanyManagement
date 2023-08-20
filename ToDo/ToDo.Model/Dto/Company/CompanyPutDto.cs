using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Model.Dto.Company
{
    public class CompanyPutDto : IDto
    {
        public string? CompanyName { get; set; }
        public string? CompanyTitle { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? TaxNumber { get; set; }
        public string? TaxAdministration { get; set; }
        public string? WebSite { get; set; }
        public string? CompanyAbout { get; set; }
    }
}
