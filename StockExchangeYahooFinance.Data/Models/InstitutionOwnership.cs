using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class InstitutionOwnership
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompaniesId { get; set; }
        public Companies Companies { get; set; }
        public string ReportDate { get; set; }
        public string Organization { get; set; }
        public double PctHeld { get; set; }
        public double Position { get; set; }
        public double Value { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
