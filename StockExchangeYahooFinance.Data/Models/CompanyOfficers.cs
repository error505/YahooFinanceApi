using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class CompanyOfficers
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompaniesId { get; set; }
        public Companies Companies { get; set; }
        public string CompanyProfileId { get; set; }
        public CompanyProfile CompanyProfile { get; set; }
        public int MaxAge { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Title { get; set; }
        public string FiscalYear { get; set; }
        public int TotalPay { get; set; }
        public int ExercisedValue { get; set; }
        public int UnexercisedValue { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
