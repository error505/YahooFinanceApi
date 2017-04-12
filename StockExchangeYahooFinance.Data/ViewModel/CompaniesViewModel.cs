using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.ViewModel
{
    public class CompaniesViewModel
    {

        public string Symbol { get; set; }

        public string Name { get; set; }

        public string Sector { get; set; }


        public string Industry { get; set; }

        public string Region { get; set; }

        public string IPOyear { get; set; }

        public string ADR_TSO { get; set; }

        public string MarketCap { get; set; }

        public string LastSale { get; set; }
    }
}
