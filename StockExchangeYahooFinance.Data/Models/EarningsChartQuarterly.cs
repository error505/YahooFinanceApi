using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class EarningsChartQuarterly
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompaniesId { get; set; }
        public Companies Companies { get; set; }
        public string EarningsId { get; set; }
        public Earnings Earnings { get; set; }
        public string Date { get; set; }
        public string Actual { get; set; }
        public string Estimate { get; set; }
        public string CurrentQuarterEstimate { get; set; }
        public string CurrentQuarterEstimateDate { get; set; }
        public string CurrentQuarterEstimateYear { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
