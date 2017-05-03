using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class CalendarEarnings
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompaniesId { get; set; }
        public Companies Companies { get; set; }
        public string CalendarEventsId { get; set; }
        public CalendarEvents CalendarEvents { get; set; }
        public string EarningsDate { get; set; }
        public string EarningsAverage { get; set; }
        public string EarningsLow { get; set; }
        public string EarningsHigh { get; set; }
        public string RevenueAverage { get; set; }
        public string RevenueLow { get; set; }
        public string RevenueHigh { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
