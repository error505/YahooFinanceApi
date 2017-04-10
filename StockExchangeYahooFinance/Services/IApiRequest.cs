using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using StockExchangeYahooFinance.ConfigData;

namespace StockExchangeYahooFinance.Services
{
    public interface IApiRequest
    {
        Task RepeatActionEvery(TimeSpan interval, CancellationToken cancellationToken, string tickers);

        List<FinanceModel> ParseCsv();
    }
}
