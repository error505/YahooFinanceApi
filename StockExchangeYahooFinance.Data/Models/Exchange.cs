using System;
using System.ComponentModel.DataAnnotations;

namespace StockExchangeYahooFinance.Data.Models
{
    public class Exchange
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string StockExchangeId { get; set; }
        public string Suffix { get; set; }
        public string Delay { get; set; }
        public string DataProvider { get; set; }
        public string OpeningTimeLocal { get; set; }
        public string ClosingTimeLocal { get; set; }
        public string UtcOffsetStandardTime { get; set; }
        public string TradingDays { get; set; }

        public string RegionId { get; set; }

        public Region Region { get; set; }

        public string CountryId { get; set; }

        public Country Country { get; set; }

        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
