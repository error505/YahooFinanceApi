using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class History
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompaniesId { get; set; }
        public Companies Companies { get; set; }
        public string Date { get; set; }
        public Double Open { get; set; }
        public Double High { get; set; }
        public Double Low { get; set; }
        public Double Close { get; set; }
        public Double Volume { get; set; }
        public Double AdjClose { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
