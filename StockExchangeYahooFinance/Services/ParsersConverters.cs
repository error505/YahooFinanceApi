using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Services
{
    public class ParsersConverters
    {
        public DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public IEnumerable<string> ParseCsv(string csvData)
        {
            var rows = csvData.Replace("\r", "").Split('\n');
            return rows;
        }
    }
}
