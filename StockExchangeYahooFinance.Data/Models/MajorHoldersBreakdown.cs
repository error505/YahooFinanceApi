using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class MajorHoldersBreakdown
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompaniesId { get; set; }
        public Companies Companies { get; set; }
        public double InsidersPercentHeld { get; set; }
        public double InstitutionsPercentHeld { get; set; }
        public double InstitutionsFloatPercentHeld { get; set; }
        public int InstitutionsCount { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
