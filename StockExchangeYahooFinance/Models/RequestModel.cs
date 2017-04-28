using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Models
{
    public class RequestModel
    {
        public string Ticker { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public List<string> TickersList { get; set; }
        public List<string> CurrencyList { get; set; }
        public string Region { get; set; }
        public string Currency { get; set; }
    }
}
