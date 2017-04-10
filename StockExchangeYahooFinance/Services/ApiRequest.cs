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
        public async Task RepeatActionEvery(TimeSpan interval, CancellationToken cancellationToken, string tickers)
        {
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
                        var smallQuery =
                            "https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20csv%20where%20url%3D%27http%3A%2F%2Fdownload.finance.yahoo.com%2Fd%2Fquotes.csv%3Fs%3DACA.PA%26f%3Dsl1d1t1c1ohgv%26e%3D.csv%27%20and%20columns%3D%27symbol%2Cprice%2Cdate%2Ctime%2Cchange%2Ccol1%2Chigh%2Clow%2Ccol2%27&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";
                        var ecb = "http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";
                        var gold =
                            "https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.quote%20where%20symbol%20in%20(%22GC=F%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys&callback=";
                        var curencyXML =
                            "http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.xchange%20where%20pair%20in%20(%22EURBAM%22,%20%22USDJPY%22,%20%22USDBGN%22,%20%22USDCZK%22,%20%22USDDKK%22,%20%22USDGBP%22,%20%22USDHUF%22,%20%22USDLTL%22,%20%22USDLVL%22,%20%22USDPLN%22,%20%22USDRON%22,%20%22USDSEK%22,%20%22USDCHF%22,%20%22USDNOK%22,%20%22USDHRK%22,%20%22USDRUB%22,%20%22USDTRY%22,%20%22USDAUD%22,%20%22USDBRL%22,%20%22USDCAD%22,%20%22USDCNY%22,%20%22USDHKD%22,%20%22USDIDR%22,%20%22USDILS%22,%20%22USDINR%22,%20%22USDKRW%22,%20%22USDMXN%22,%20%22USDMYR%22,%20%22USDNZD%22,%20%22USDPHP%22,%20%22USDSGD%22,%20%22USDTHB%22,%20%22USDZAR%22,%20%22USDISK%22)&env=store://datatables.org/alltableswithkeys";
                        var curencyUrl =
                            "http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.xchange%20where%20pair%20in%20(%22EURBAM%22,%20%22USDJPY%22,%20%22USDBGN%22,%20%22USDCZK%22,%20%22USDDKK%22,%20%22USDGBP%22,%20%22USDHUF%22,%20%22USDLTL%22,%20%22USDLVL%22,%20%22USDPLN%22,%20%22USDRON%22,%20%22USDSEK%22,%20%22USDCHF%22,%20%22USDNOK%22,%20%22USDHRK%22,%20%22USDRUB%22,%20%22USDTRY%22,%20%22USDAUD%22,%20%22USDBRL%22,%20%22USDCAD%22,%20%22USDCNY%22,%20%22USDHKD%22,%20%22USDIDR%22,%20%22USDILS%22,%20%22USDINR%22,%20%22USDKRW%22,%20%22USDMXN%22,%20%22USDMYR%22,%20%22USDNZD%22,%20%22USDPHP%22,%20%22USDSGD%22,%20%22USDTHB%22,%20%22USDZAR%22,%20%22USDISK%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys&callback=";
                        var curencyAllUSD =
                            "http://finance.yahoo.com/webservice/v1/symbols/allcurrencies/quote?format=json";
                        var url =
                            $"https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.quotes%20where%20symbol%20in%20(%22{tickers}%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys&callback=";
                        json = web.DownloadString(url);
                    }

                    var v = JObject.Parse(json);
                    var d = new FinanceData();
                    dynamic data = JObject.Parse(json);
                    var quote = data.query.results.quote;
                    List<FinanceModel> financeModel = new List<FinanceModel>();
                    foreach (var i in v["query"]["results"]["quote"])
                    {
                        var f = new FinanceModel();
                        var symbol = i.SelectToken(d.Symbol);
                        var ticker = symbol;
                        f.Symbol = symbol.ToString();
                        financeModel.Add(f);
                        var price = i.SelectToken(d.LastTradePriceOnly);
                        var lastTime = i.SelectToken(d.LastTradeDate);
                        var change = i.SelectToken(d.Change);
                        var name = i.SelectToken(d.Name);
                        if (change.Value<string>() == "")
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"{name} : {ticker} : {price} : {lastTime} : 0.00");
                        }
                        if (change.Value<string>() != null && (decimal) change < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{name}:{ticker} : {price} : {lastTime} : {change}");
                        }
                        if (change.Value<string>() == null || (decimal) change <= 0) continue;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{name} : {ticker} : {price} : {lastTime} : {change}");
                    }
                }

                catch (TaskCanceledException)
                {
                    return;
                }
            }
        }


        public List<FinanceModel> ParseCsv()
        {
            //Add parameters in URL for more info
            var csvUrl = "http://finance.yahoo.com/d/quotes.csv?s=AAPL+GOOG+MSFT&f=snbaopl1c1";
            string csvData;

            using (WebClient web = new WebClient())
            {
                csvData = web.DownloadString(csvUrl);
            }

            var rows = csvData.Replace("\r", "").Split('\n');

            List<FinanceModel> prices = (from row in rows
                where !string.IsNullOrEmpty(row)
                select row.Split(',')
                into cols
                select new FinanceModel
                {
                    Symbol = cols[0], Name = cols[1], Bid = (cols[2]), Ask = (cols[3]), Open = (cols[4]), PreviousClose = (cols[5]), LastTradePriceOnly = (cols[6]), Change = cols[7]
                }).ToList();
            foreach (var price in prices)
            {
                Console.WriteLine("{0} ({1})  Bid:{2} Offer:{3} Last:{4} Open: {5} PreviousClose:{6} Change:{7}", price.Name, price.Symbol, price.Bid, price.Ask, price.LastTradePriceOnly, price.Open, price.PreviousClose, price.Change);
            }
            Console.Read();
            return prices;
        }

    }
}
