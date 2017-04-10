using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StockExchangeYahooFinance.ConfigData;

namespace StockExchangeYahooFinance.Services
{
    public interface IApiRequest
    {
        /// <summary>
        /// Get JSON data from yahoo finance and parse it
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="url"></param>
        /// <param name="tickers"></param>
        /// <param name="format"></param>
        /// <param name="env"></param>
        /// <returns></returns>
        Task RepeatActionEvery(TimeSpan interval, CancellationToken cancellationToken, string url, string tickers, string format, string env);

        /// <summary>
        /// Get CSV from yahoo finance and parse it
        /// </summary>
        /// <param name="url"></param>
        /// <param name="tickers"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        List<FinanceModel> ParseCsv(string url, string tickers, string data);

    }
}
