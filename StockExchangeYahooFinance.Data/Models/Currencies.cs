using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class Currencies
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Entity { get; set; }

        public string Currency { get; set; }

        public string Code { get; set; }

        public int NumericCode { get; set; }

        public string MinorUnit { get; set; }

    }
}
