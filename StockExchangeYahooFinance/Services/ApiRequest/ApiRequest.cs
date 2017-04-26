﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using StockExchangeYahooFinance.ConfigData;
using StockExchangeYahooFinance.Data.Models;
using StockExchangeYahooFinance.Data.ViewModel;
using StockExchangeYahooFinance.Helpers;
using StockExchangeYahooFinance.Models;
using StockExchangeYahooFinance.Repository;

namespace StockExchangeYahooFinance.Services.ApiRequest
{
    public class ApiRequest : IApiRequest
    {
        private readonly StockExchangeRepository _repository;
        //Initialize ConfigManager
        private static readonly ConfigManager CfgManager = new ConfigManager();
        //Initialize YqlQuery
        private static readonly YqlQuery YqlQuery = new YqlQuery();
        //Initialize FinanceData
        private static readonly FinanceData FinanceData = new FinanceData();
        public ApiRequest(StockExchangeRepository repository)
        {
            //Get repository
            _repository = repository;
        }
        /// <summary>
        /// Get JSON data from yahoo finance and parse it
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="url"></param>
        /// <returns>List of companies</returns>
        public async Task StockExchangeTask(TimeSpan interval, CancellationToken cancellationToken)
        {
            var url = CfgManager.YahooBaseUrl + YqlQuery.SelectAll + CfgManager.YahooQuotes + YqlQuery.WhereSimbol +
                      YqlQuery.In + "(%22" + CfgManager.Tickers + "%22)" + CfgManager.Format + CfgManager.Enviroment +
                      CfgManager.CallBack;
            var financeModel = new List<FinanceModel>();
            while (true)
            {
                var task = Task.Delay(interval, cancellationToken);
                try
                {
                    await task;
                    Console.Clear();
                    var json = WebRequest(url);
                    dynamic data = JObject.Parse(json);
                    var quote = data.query.results.quote;
                    foreach (var i in quote)
                    {
                        var f = new FinanceModel();
                        var symbol = i.SelectToken(FinanceData.Symbol);
                        f.Symbol = symbol.ToString();
                        var price = i.SelectToken(FinanceData.LastTradePriceOnly);
                        f.LastTradePriceOnly = price.ToString();
                        var lastTime = i.SelectToken(FinanceData.LastTradeDate);
                        f.LastTradeDate = lastTime.ToString();
                        var change = i.SelectToken(FinanceData.Change);
                        f.Change = change.ToString();
                        var name = i.SelectToken(FinanceData.Name);
                        f.Name = name.ToString();
                        financeModel.Add(f);
                        var value = ((JValue)change).Value;
                        if (value != null && (float)change < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{name}:{symbol} : {price} : {lastTime} : {change}");
                        }
                        if (value == null || (float)change <= 0) continue;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{name} : {symbol} : {price} : {lastTime} : {change}");
                        await _repository.AddFinanceModel(f);
                    }
                }
                catch (TaskCanceledException)
                {
                    return;
                }
            }
        }
        //TODO
        //public async Task YahooHistoricalData(RequestModel model)
        //{
        //    var url = CfgManager.YahooBaseUrl + YqlQuery.SelectAll + CfgManager.YahooHistoricalData +
        //              YqlQuery.WhereSimbol +
        //              "(%22" + CfgManager.SymbolTicker + "%22)" + YqlQuery.And + YqlQuery.StartDate + "2012-09-11" +
        //              YqlQuery.And + YqlQuery.EndDate + "2014-02-11" + CfgManager.Format + CfgManager.Enviroment +
        //              CfgManager.CallBack;
        //        try
        //        {
        //            Console.Clear();
        //            var json = WebRequest(url);
        //            dynamic data = JObject.Parse(json);
        //            var quote = data.query.results.quote;
        //            foreach (var i in quote)
        //            {
        //                var f = new History();
        //                var symbol = i.SelectToken(FinanceData.Symbol);
        //                f.Symbol = symbol.ToString();
        //                var Open = i.SelectToken(FinanceData.Open);
        //                f.Open = Open.ToString();
        //                var high = i.SelectToken(FinanceData.High);
        //                f.High = high.ToString();
        //                var low = i.SelectToken(FinanceData.Low);
        //                f.Low = low.ToString();
        //                var date = i.SelectToken(FinanceData.Date);
        //                f.StartDate = date.ToString();

        //                    Console.ForegroundColor = ConsoleColor.Red;
        //                    Console.WriteLine($"{name}:{symbol} : {price} : {lastTime} : {change}");

        //                Console.ForegroundColor = ConsoleColor.Green;
        //                Console.WriteLine($"{name} : {symbol} : {price} : {lastTime} : {change}");
        //                await _repository.AddHistory(f);
        //            }
        //        }
        //        catch (TaskCanceledException)
        //        {
        //            return;
        //        }
        //}

        /// <summary>
        /// Get CSV from yahoo finance and parse it
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task StockExchangeParseCsv()
        {
            var url = CfgManager.CsvUrl + $"{CfgManager.Tickers}&f={CfgManager.CsvData}";
            //Call web request
            var request = WebRequest(url);
            //Parse CSV
            var rows = request.Replace("\r", "").Split('\n');
            //Get data from string
            var prices = (from row in rows
                where !string.IsNullOrEmpty(row)
                select row.Split(',')
                into cols
                select new FinanceModel
                {
                    Symbol = cols[0],
                    Name = cols[1],
                    Bid = (cols[2]),
                    Ask = (cols[3]),
                    Open = (cols[4]),
                    PreviousClose = (cols[5]),
                    LastTradePriceOnly = (cols[6]),
                    Change = cols[7]
                }).ToList();
            //Write data in console
            foreach (var price in prices)
            {
                Console.WriteLine("{0} ({1})  Bid:{2} Offer:{3} Last:{4} Open: {5} PreviousClose:{6} Change:{7}",
                    price.Name, price.Symbol, price.Bid, price.Ask, price.LastTradePriceOnly, price.Open,
                    price.PreviousClose, price.Change);
                await _repository.AddFinanceModel(price);
            }
            Console.Read();
        }

        /// <summary>
        /// For Currency XCHANGE
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="url"></param>
        /// <returns>List of Currencies with id, bid, name, rate, date....</returns>
        public async Task XchangeTask(TimeSpan interval, CancellationToken cancellationToken)
        {
            var url = CfgManager.YahooBaseUrl + YqlQuery.SelectAll + CfgManager.YahooXchange + YqlQuery.WherePair +
                      YqlQuery.In + "(%22" + CfgManager.Curencies + "%22)" + CfgManager.Format + CfgManager.Enviroment +
                      CfgManager.CallBack;
            while (true)
            {
                var task = Task.Delay(interval, cancellationToken);
                try
                {
                    await task;
                    Console.Clear();
                    var json = WebRequest(url);
                    var d = new FinanceData();
                    dynamic data = JObject.Parse(json);
                    var quote = data.query.results.rate;
                    foreach (var i in quote)
                    {
                        var id = i.SelectToken(d.Id);
                        var rate = i.SelectToken(d.Rate);
                        var date = i.SelectToken(d.Date);
                        var time = i.SelectToken(d.Time);
                        var ask = i.SelectToken(d.Ask);
                        var bid = i.SelectToken(d.Bid);
                        var name = i.SelectToken(d.Name);
                        var value = ((JValue)rate).Value;

                        if (value != null && (decimal)rate < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{name}:{id} : {rate} : {date + time} : {ask}: {bid}");
                        }

                        if (value == null || (decimal)rate <= 0) continue;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{name} : {id} : {rate} : {date + time} : {ask} : {bid}");
                    }
                }
                catch (TaskCanceledException)
                {
                    return;
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task YahooCompanies()
        {
            //Search term
            const string s = "s=";
            //All, Stocks, Mutual funds,...
            const string t = "&t=";
            //Country
            const string m = "&m=";
            //Number of items
            const string b = "&b=";
            //To put it in tables
            const string bypass = "&bypass=true";
            const string alphabet = "abcdefghijklmnopqrstuvwxyz0123456789";
            //var results = new List<string>();
            foreach (var c in alphabet)
            {
                for (var i = 0; i <= 2042; i += 20)
                {
                    var urlTosend = CfgManager.YahooLookupAll + s + c + t + "s" + m + "ALL" + b + i + bypass;
                    var data = WebRequest(urlTosend);
                    var doc = new HtmlDocument();
                    doc.LoadHtml(data);

                    var allRowNodes = doc.DocumentNode.SelectNodes("//tr[contains(@class, 'yui-dt')]");
                    if (allRowNodes == null) continue;
                    foreach (var item in allRowNodes)
                    {
                        if (item == allRowNodes.First()) continue;
                        var com = item.FirstChild.InnerText;
                        var tickerName = item.ChildNodes[1].InnerText;
                        var lastTrade = item.ChildNodes[2].InnerText;
                        var type = item.ChildNodes[3].InnerText;
                        var industryN = item.ChildNodes[4].InnerText;
                        var exchangeId = item.ChildNodes[5].InnerText;
                        var exc = new Exchange() { StockExchangeId = exchangeId };
                        var excId = await _repository.AddExchange(exc);
                        //var sector = new Sector { Name = sec };
                        var industry = new Industry { Name = industryN };
                        var indId = await _repository.AddIndustry(industry);
                        //var secId = await _repository.AddSector(sector);
                        var companies = new Companies()
                        {
                            Symbol = com,
                            Name = tickerName,
                            LastSale = lastTrade,
                            //SectorId = secId,
                            IndustryId = indId,
                            //RegionId = regId,
                            ExchangeId = excId
                        };
                        await _repository.AddCompany(companies);
                        //results.Add(com + "\t" + tickerName + "\t" + lastTrade + "\t" + type + "\t" + industry + "\t" + exchange);
                        Console.WriteLine(com + "\t" + tickerName + "\t" + lastTrade + "\t" + type + "\t" + industryN +
                                          "\t" + exchangeId);
                    }
                }
            }
            //SaveData(results);
            //return results;
        }
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task YahooExchanges()
        {
            var doc = new XmlDocument();
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            // Find Exchanges Template XML
            var xmlFilePath = Path.Combine(dir, "ConfigData", "StockExchanges" + ".xml");
            //Load XML into created XML document
            doc.Load(xmlFilePath);
            var nsmgrDoc = new XmlNamespaceManager(doc.NameTable);
            var companyElements = doc.SelectNodes("StockExchanges/StockExchange", nsmgrDoc);
            foreach (XmlElement item in companyElements)
            {
                var id = item.Attributes[0].Value;
                var suffix = item.Attributes[1].Value;
                var delayMinutes = item.Attributes[2].Value;
                var openingTimeLocal = item.Attributes[3].Value;
                var closingTimeLocal = item.Attributes[4].Value;
                var utcOffsetStandardTime = item.Attributes[5].Value;
                var country = item.Attributes[6].Value;
                var name = item.Attributes[7].Value;
                var tradingDays = item.Attributes[8].Value;

                //var reg = new Region { Name = region };
                //var regId = await _repository.AddRegion(reg);
                //var sector = new Sector { Name = sec };
                var countryAdd = new Country() {Name = country };
                var countryId = await _repository.AddCountry(countryAdd);
                //var secId = await _repository.AddSector(sector);
                var exchange = new Exchange()
                {
                    StockExchangeId = id,
                    Suffix = suffix,
                    Delay = delayMinutes,
                    OpeningTimeLocal = openingTimeLocal,
                    ClosingTimeLocal = closingTimeLocal,
                    UtcOffsetStandardTime = utcOffsetStandardTime,
                    CountryId = countryId,
                    Name = name,
                    TradingDays = tradingDays,
                };
                await _repository.AddExchange(exchange);
            }

            //SaveData(results);
            //return results;
        }
        /// <summary>
        /// test
        /// </summary>
        /// <param name="results"></param>
        //private static void SaveData(IEnumerable<string> results)
        //{
        //    File.AppendAllLines(@"C:\Users\Igor\Desktop\stocks.txt", results);
        //}

        /// <summary>
        ///
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="url"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        public async Task ImportCompanies(TimeSpan interval, CancellationToken cancellationToken)
        {
            var url = CfgManager.NasdqCompanies + CfgManager.NasdqRegionCsv + CfgManager.NasdqRender;
            try
            {
                var csvData = WebRequest(url);
                //Parse CSV
                var rows = csvData.Replace("\r", "").Split('\n');
                //Get data from string
                var companies = (from row in rows
                    where !string.IsNullOrEmpty(row)
                    let csvSplit = new Regex("((?<=\")[^\"]*(?=\"(,|$)+)|(?<=,|^)[^,\"]*(?=,|$))").Matches(row)
                    let cols = row.Split(',')
                    select new CompaniesViewModel()
                    {
                        Symbol = csvSplit[0].ToString(),
                        Name = csvSplit[1].ToString(),
                        LastSale = csvSplit[2].ToString(),
                        MarketCap = csvSplit[3].ToString(),
                        ADR_TSO = csvSplit[4].ToString(),
                        IPOyear = csvSplit[5].ToString(),
                        Sector = csvSplit[7].ToString(),
                        Industry = csvSplit[6].ToString()
                    }).ToList();
                var reg = new Region { Name = CfgManager.NasdqRegion };
                var regId = await _repository.AddRegion(reg);
                //Write data in console
                foreach (var comp in companies.Skip(1))
                {
                    var n = comp.Name.Replace("\"", "");
                    var s = comp.Symbol.Replace("\"", "");
                    var i = comp.Industry.Replace("\"", "");
                    var sec = comp.Sector.Replace("\"", "");
                    var sector = new Sector { Name = sec };
                    var industry = new Industry { Name = i };
                    var indId = await _repository.AddIndustry(industry);
                    var secId = await _repository.AddSector(sector);
                    var company = new Companies
                    {
                        IndustryId = indId,
                        SectorId = secId,
                        Name = comp.Name.Replace("\"", ""),
                        Symbol = comp.Symbol.Replace("\"", ""),
                        RegionId = regId,
                        ADR_TSO = comp.ADR_TSO.Replace("\"", ""),
                        IPOyear = comp.IPOyear.Replace("\"", ""),
                        LastSale = comp.LastSale.Replace("\"", ""),
                        MarketCap = comp.MarketCap.Replace("\"", "")
                    };
                    await _repository.AddCompany(company);
                    Console.WriteLine("{0} ({1})  Industry:{2}",
                        n, s, i);
                }
                Console.Read();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.Read();
                throw;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task ImportCurrencies()
        {
            try
            {
                var csvData = WebRequest(CfgManager.IsoCurrencyUrl);
                var currency = XDocument.Parse(csvData);
                //Write data in console
                var query = from c in currency.Descendants("CcyNtry")
                    let element = c.Element("Ccy")
                    where element != null
                    let o = c.Element("CcyNm")
                    where o != null
                    let xElement1 = c.Element("CtryNm")
                    where xElement1 != null
                    let element1 = c.Element("CcyNbr")
                    where element1 != null
                    let o1 = c.Element("CcyMnrUnts")
                    where o1 != null
                    select
                    new Currencies()
                    {
                        Code = element.Value,
                        Currency = o.Value,
                        Entity = xElement1.Value,
                        NumericCode = Convert.ToInt32(element1.Value),
                        MinorUnit = o1.Value
                    };
                foreach (var c in query)
                {
                    await _repository.AddCurrency(c);
                    Console.WriteLine(c.Currency,c.Entity,c.Code);
                }

                Console.Read();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.Read();
                throw;
            }
        }

        /// <summary>
        /// Call web API
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static string WebRequest(string url)
        {
            string webResponseData;
            //Make web request
            using (var web = new WebClient())
            {
                webResponseData = web.DownloadString(url);
            }
            return webResponseData;
        }
    }
}
