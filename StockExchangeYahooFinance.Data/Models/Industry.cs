using System;
using System.ComponentModel.DataAnnotations;

namespace StockExchangeYahooFinance.Data.Models
{
    public class Industry
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }

        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
