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
        /// <returns></returns>
        Task RepeatActionEvery(TimeSpan interval, CancellationToken cancellationToken, string url);

        /// <summary>
        /// Get CSV from yahoo finance and parse it
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        List<FinanceModel> ParseCsv(string url);

    }
}
