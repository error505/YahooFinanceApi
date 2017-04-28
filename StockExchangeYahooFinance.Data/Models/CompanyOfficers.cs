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
        public int MaxAge { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Title { get; set; }
        public string FiscalYear { get; set; }
        public long TotalPay { get; set; }
        public long ExercisedValue { get; set; }
        public long UnexercisedValue { get; set; }

    }
}
