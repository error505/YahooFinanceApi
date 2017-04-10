using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using StockExchangeYahooFinance.ConfigData;

namespace StockExchangeYahooFinance.Services
{
    public class ApiRequest : IApiRequest
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
        public async Task RepeatActionEvery(TimeSpan interval, CancellationToken cancellationToken, string url, string tickers, string format, string env)
        {
            // still not in use anywhere....
            var financeModel = new List<FinanceModel>();
            while (true)
            {
                var task = Task.Delay(interval, cancellationToken);
                try
                {
                    await task;
                    Console.Clear();
                    string json;
                    using (var web = new WebClient())
                    {
                        json = web.DownloadString(url + tickers + format + env);
                    }

                    var v = JObject.Parse(json);
                    var d = new FinanceData();
                    dynamic data = JObject.Parse(json);
                    var quote = data.query.results.quote; //Use later
                    foreach (var i in quote)
                    {
                        var f = new FinanceModel();
                        var symbol = i.SelectToken(d.Symbol);
                        f.Symbol = symbol.ToString();
                        var price = i.SelectToken(d.LastTradePriceOnly);
                        f.LastTradePriceOnly = price.ToString();
                        var lastTime = i.SelectToken(d.LastTradeDate);
                        f.LastTradeDate = lastTime.ToString();
                        var change = i.SelectToken(d.Change);
                        f.Change = change.ToString();
                        var name = i.SelectToken(d.Name);
                        f.Name = name.ToString();
                        financeModel.Add(f);
                        var value = ((JValue)change).Value;
                        if (value != null && (decimal)change < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{name}:{symbol} : {price} : {lastTime} : {change}");
                        }
                        if (value == null || (decimal)change <= 0) continue;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{name} : {symbol} : {price} : {lastTime} : {change}");
                    }
                }

                catch (TaskCanceledException)
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Get CSV from yahoo finance and parse it
        /// </summary>
        /// <param name="url"></param>
        /// <param name="tickers"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<FinanceModel> ParseCsv(string url, string tickers, string data)
        {
            //Add parameters in URL for more info
            var csvUrl = url + $"{tickers}&f={data}";
            string csvData;

            using (var web = new WebClient())
            {
                csvData = web.DownloadString(csvUrl);
            }

            var rows = csvData.Replace("\r", "").Split('\n');

            var prices = (from row in rows
                where !string.IsNullOrEmpty(row)
                select row.Split(',')
                into cols
                select new FinanceModel
                {
                    Symbol = cols[0], Name = cols[1], Bid = (cols[2]), Ask = (cols[3]), Open = (cols[4]), PreviousClose = (cols[5]), LastTradePriceOnly = (cols[6]), Change = cols[7]
                }).ToList();
            foreach (var price in prices)
            {
                Console.WriteLine("{0} ({1})  Bid:{2} Offer:{3} Last:{4} Open: {5} PreviousClose:{6} Change:{7}",
                    price.Name, price.Symbol, price.Bid, price.Ask, price.LastTradePriceOnly, price.Open,
                    price.PreviousClose, price.Change);
            }
            Console.Read();
            return prices;
        }

    }
}
