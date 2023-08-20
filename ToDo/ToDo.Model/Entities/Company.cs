using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Model.Entities
{
    [Table("Companys")]

    public class Company : IEntity
    {
        [Key]
        public int Id { get; set; }
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
