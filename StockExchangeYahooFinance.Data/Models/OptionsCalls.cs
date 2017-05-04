using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class OptionsCalls
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompaniesId { get; set; }
        public Companies Companies { get; set; }
        public string PercentChange { get; set; }
        public string OpenInterest { get; set; }
        public string Strike { get; set; }
        public string Change { get; set; }
        public string InTheMoney { get; set; }
        public string ImpliedVolatility { get; set; }
        public string Volume { get; set; }
        public string Ask { get; set; }
        public string ContractSymbol { get; set; }
        public string Currency { get; set; }
        public string Expiration { get; set; }
        public string ContractSize { get; set; }
        public string Bid { get; set; }
        public string LastPrice { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
