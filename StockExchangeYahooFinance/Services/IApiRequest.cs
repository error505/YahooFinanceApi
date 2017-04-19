using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StockExchangeYahooFinance.ConfigData;
using StockExchangeYahooFinance.Data;
using StockExchangeYahooFinance.Data.Models;

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
        Task StockExchangeTask(TimeSpan interval, CancellationToken cancellationToken, string url);

        /// <summary>
        /// Get CSV from yahoo finance and parse it
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        List<FinanceModel> StockExchangeParseCsv(string url);
        /// <summary>
        /// For Currency XCHANGE
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="url"></param>
        /// <returns>List of Currencies with id, bid, name, rate, date....</returns>
        Task XchangeTask(TimeSpan interval, CancellationToken cancellationToken, string url);
        /// <summary>
        ///
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="url"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        Task ImportCompanies(TimeSpan interval, CancellationToken cancellationToken, string url, string region);
        /// <summary>
        ///
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Task ImportCurrencies(string url);
        /// <summary>
        ///
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Task YahooCompanies(string url);
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        Task YahooExchanges();
    }
}
