using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using HtmlAgilityPack;
using Newtonsoft.Json;
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
        private static readonly ConfigManager Cfg = new ConfigManager();
        //Initialize YqlQuery
        private static readonly YqlQuery YQ = new YqlQuery();
        //Initialize FinanceData
        private static readonly FinanceData FinanceData = new FinanceData();
        private readonly CallWebRequest _callWebRequest = new CallWebRequest();
        private static readonly YahooCompProfile YahooCompProfile = new YahooCompProfile();
        private static readonly YahooRssFeed _YahooRssFeed = new YahooRssFeed();
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
            var url = Cfg.YahooBaseUrl + YQ.SelectAll + Cfg.YahooQuotes + YQ.WhereSimbol +
                      YQ.In + "(%22" + Cfg.Tickers + "%22)" + Cfg.Format + Cfg.Enviroment +
                      Cfg.CallBack;
            var financeModel = new List<FinanceModel>();
            while (true)
            {
                var task = Task.Delay(interval, cancellationToken);
                try
                {
                    await task;
                    Console.Clear();
                    var json = _callWebRequest.WebRequest(url);
                    dynamic data = JObject.Parse(json.Result);
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
        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task YahooHistoricalDataQuery(RequestModel model)
        {
            var url = Cfg.YahooBaseUrl + YQ.SelectAll + Cfg.YahooHistoricalData +
                      YQ.WhereSimbol +
                      "(%22" + Cfg.SymbolTicker + "%22)" + YQ.And + YQ.StartDate + "2012-09-11" +
                      YQ.And + YQ.EndDate + "2014-02-11" + Cfg.Format + Cfg.Enviroment +
                      Cfg.CallBack;
            try
            {
                Console.Clear();
                var json = WebRequest(url);
                dynamic data = JObject.Parse(json);
                var quote = data.query.results.quote;
                var symbolId = await _repository.GetCompanyByName(Cfg.SymbolTicker);
                foreach (var i in quote)
                {
                    var h = new History();
                    h.CompaniesId = symbolId.Id;
                    var open = i.SelectToken(FinanceData.Open);
                    h.Open = open.ToString();
                    var high = i.SelectToken(FinanceData.High);
                    h.High = high.ToString();
                    var low = i.SelectToken(FinanceData.Low);
                    h.Low = low.ToString();
                    var date = i.SelectToken(FinanceData.Date);
                    var close = Convert.ToDouble(i.SelectToken(FinanceData.Close));
                    h.Date = Convert.ToDateTime(date.ToString());
                    h.Close = close;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{symbolId.Name}:{Cfg.SymbolTicker} : {open} : {high} : {low} : {close}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{symbolId.Name}:{Cfg.SymbolTicker} : {open} : {high} : {low} : {close}");
                    await _repository.AddHistory(h);
                }
            }
            catch (TaskCanceledException)
            {
                return;
            }
        }
        //TODO: Finish Rss feed scrapping
        /// <summary>
        /// Return Rss feed news for selected ticker
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task YahooRssFeed(RequestModel model)
        {
            var url = Cfg.YahooBaseUrl + YQ.SelectAll + YQ.Rss +
                      YQ.Where + YQ.Url + "=" + "%22" + Cfg.YahooRssUrl +
                       model.Ticker + "%22" + Cfg.Format + Cfg.Enviroment +
                      Cfg.CallBack;
            try
            {
                Console.Clear();
                var json = await _callWebRequest.WebRequest(url);
                dynamic data = JObject.Parse(json);
                var quote = data.query.results.item;
                //var symbolId = await _repository.GetCompanyByName(Cfg.SymbolTicker);
                foreach (var i in quote)
                {
                    var desc = i.SelectToken(_YahooRssFeed.Description).ToString();
                    var title = i.SelectToken(_YahooRssFeed.Title).ToString();
                    var link = i.SelectToken(_YahooRssFeed.Link).ToString();
                    var pubDate = i.SelectToken(_YahooRssFeed.PubDate).ToString();
                    Console.WriteLine($"{model.Ticker}: {desc} : {title} : {link} : {pubDate}");
                }
            }
            catch (TaskCanceledException)
            {
                return;
            }
        }


        /// <summary>
        /// Get Company Profile from Yahoo finance
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task YahooCompanyProfile(RequestModel model)
        {
            var modules = new YahooModules();
            var url = Cfg.YahooQuoteSummary + model.Ticker + Cfg.YFormated + Cfg.YModules + modules.AssetProfile + Cfg.YCorsDomain;
            try
            {
                Console.Clear();
                var json = _callWebRequest.WebRequest(url);
                //dynamic data = JObject.Parse(json.Result);
                //var profile = data.quoteSummary.result;
                var d = JObject.Parse(json.Result);
                var symbolId = await _repository.GetCompanyByName(model.Ticker);
                var assetProfile = d["quoteSummary"]["result"][0];
                var companyOfficers = (JArray)d["quoteSummary"]["result"][0]["assetProfile"]["companyOfficers"];
                //IList<string> categoriesText = companyOfficers.Select(c => (string)c).ToList();
                string companyProfileId = null;
                var companyExists = true;
                while (companyExists)
                {
                    if (symbolId != null)
                    {
                        foreach (var i in assetProfile.First)
                        {
                            var h = new CompanyProfile();
                            var address1 = i.SelectToken(YahooCompProfile.Address1);
                            var city = i.SelectToken(YahooCompProfile.City);
                            var zip = i.SelectToken(YahooCompProfile.Zip);
                            var country = i.SelectToken(YahooCompProfile.Country);
                            var phone = i.SelectToken(YahooCompProfile.Phone);
                            var website = i.SelectToken(YahooCompProfile.Website);
                            var fax = i.SelectToken(YahooCompProfile.Fax);
                            var industry = i.SelectToken(YahooCompProfile.Industry);
                            var industrySymbol = i.SelectToken(YahooCompProfile.IndustrySymbol);
                            var industryId = await _repository.GetIndustryByName(industry.ToString());
                            var sector = i.SelectToken(YahooCompProfile.Sector);
                            var sectorId = await _repository.GetSectorByNameAddNonExisting(sector.ToString());
                            var longBusinessSummary = i.SelectToken(YahooCompProfile.LongBusinessSummary);
                            var fullTimeEmployees = i.SelectToken(YahooCompProfile.FullTimeEmployees);
                            var auditRisk = i.SelectToken(YahooCompProfile.AuditRisk);
                            var boardRisk = i.SelectToken(YahooCompProfile.BoardRisk);
                            var compensationRisk = i.SelectToken(YahooCompProfile.CompensationRisk);
                            var shareHolderRightsRisk = i.SelectToken(YahooCompProfile.ShareHolderRightsRisk);
                            var overallRisk = i.SelectToken(YahooCompProfile.OverallRisk);
                            var governanceEpochDate = i.SelectToken(YahooCompProfile.GovernanceEpochDate);
                            var compensationAsOfEpochDate = i.SelectToken(YahooCompProfile.CompensationAsOfEpochDate);
                            if (symbolId != null) h.CompaniesId = symbolId.Id;
                            if (address1 != null) h.Address1 = address1.ToString();
                            if (city != null) h.City = city.ToString();
                            if (zip != null) h.Zip = zip.ToString();
                            if (phone != null) h.Phone = phone.ToString();
                            if (fax != null) h.Fax = fax.ToString();
                            if (website != null) h.Website = website.ToString();
                            if (industryId != null) h.IndustryId = industryId.Id;
                            h.IndustrySymbolId = null;
                            if (sectorId != null) h.SectorId = sectorId.Id;
                            if (longBusinessSummary != null) h.LongBusinessSummary = longBusinessSummary.ToString();
                            if (fullTimeEmployees != null) h.FullTimeEmployees = (int)fullTimeEmployees;
                            if (auditRisk != null) h.AuditRisk = (int)auditRisk;
                            if (boardRisk != null) h.BoardRisk = (int)boardRisk;
                            if (compensationRisk != null) h.CompensationRisk = (int)compensationRisk;
                            if (shareHolderRightsRisk != null) h.ShareHolderRightsRisk = (int)shareHolderRightsRisk;
                            if (overallRisk != null) h.OverallRisk = (int)overallRisk;
                            if (governanceEpochDate != null) h.GovernanceEpochDate = Convert.ToInt32(governanceEpochDate);
                            if (compensationAsOfEpochDate != null) h.CompensationAsOfEpochDate = Convert.ToInt32(compensationAsOfEpochDate);
                            Console.WriteLine($"{symbolId.Name}:{Cfg.SymbolTicker} : {address1} : {city} : {zip} : {phone}");
                            await _repository.AddCompanyProfile(h);
                            companyProfileId = h.Id;
                        }
                        foreach (var s in companyOfficers)
                        {
                            var compOffices = new CompanyOfficers();
                            var maxAge = s.SelectToken(YahooCompProfile.MaxAge);
                            var name = s.SelectToken(YahooCompProfile.Name);
                            var age = s.SelectToken(YahooCompProfile.Age);
                            var title = s.SelectToken(YahooCompProfile.Title);
                            var fiscalYear = s.SelectToken(YahooCompProfile.FiscalYear);
                            var totalPay = s.SelectToken(YahooCompProfile.TotalPay);
                            var exercisedValue = s.SelectToken(YahooCompProfile.ExercisedValue);
                            var unExercisedValue = s.SelectToken(YahooCompProfile.UnexercisedValue);
                            if (unExercisedValue != null)
                            {
                                var unexcValue = s["unexercisedValue"]["raw"];
                                compOffices.UnexercisedValue = (int)(unexcValue);
                            }
                            if (totalPay != null)
                            {
                                var row = s["totalPay"]["raw"];
                                compOffices.TotalPay = (int)(row);
                            }
                            if (exercisedValue != null)
                            {
                                var longExercisedValue = s["exercisedValue"]["raw"];
                                compOffices.ExercisedValue = (int)(longExercisedValue);
                            }
                            if (companyProfileId != null) compOffices.CompanyProfileId = companyProfileId;
                            if (symbolId != null) compOffices.CompaniesId = symbolId.Id;
                            if (maxAge != null) compOffices.MaxAge = Convert.ToInt32(maxAge);
                            if (name != null) compOffices.Name = name.ToString();
                            if (age != null) compOffices.Age = Convert.ToInt32(age);
                            if (title != null) compOffices.Title = title.ToString();
                            if (fiscalYear != null) compOffices.FiscalYear = fiscalYear.ToString();
                            await _repository.AddCompanyOfficers(compOffices);
                            Console.WriteLine($"{name} : {age} : {title} : {fiscalYear}");
                        }
                        companyExists = false;
                    }
                    else
                    {
                        await AddYahooCompanyByName(model);
                        symbolId = await _repository.GetCompanyByName(model.Ticker);
                    }
                }
            }
            catch (TaskCanceledException)
            {
                return;
            }
        }

        public async Task YahooHistoricalDataCsv(RequestModel model)
        {
            var symbol = "s=";
            var startDate = "c=";
            var url = Cfg.YahooHistoryCsv + symbol + model.Ticker;
            try
            {
                var csvData = WebRequest(url);
                var rows = ParseCsv(csvData);
                var symbolId = await _repository.GetCompanyByName(model.Ticker);
                if (symbolId == null)
                {
                    await AddYahooCompanyByName(model);
                    symbolId = await _repository.GetCompanyByName(model.Ticker);
                }
                var historyCsv = new List<History>();
                try
                {
                    historyCsv.AddRange(from row in rows.Skip(1)
                        where !string.IsNullOrEmpty(row)
                        select row.Split(',')
                        into cols
                        let datum = cols[0]
                        let open = Convert.ToDouble(cols[1])
                        let high = Convert.ToDouble(cols[2])
                        let low = Convert.ToDouble(cols[3])
                        let close = Convert.ToDouble(cols[4])
                        let volume = Convert.ToInt32(cols[5])
                        let adjClose = Convert.ToDouble(cols[6])
                        select new History()
                        {
                            CompaniesId = symbolId.Id,
                            Date = datum,
                            Open = open,
                            High = high,
                            Low = low,
                            Close = close,
                            Volume = volume,
                            AdjClose = adjClose,
                            CreatedByUser = Cfg.UserName
                        });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                Console.Clear();
                foreach (var hs in historyCsv)
                {
                    var history = new History()
                    {
                        CompaniesId = hs.CompaniesId,
                        Date = hs.Date,
                        Open = hs.Open,
                        High = hs.High,
                        Low = hs.Low,
                        Close = hs.Close,
                        Volume = hs.Volume,
                        AdjClose = hs.AdjClose,
                        CreatedByUser = hs.CreatedByUser
                    };
                    Console.WriteLine(
                        $"Name {symbolId.Name}: Ticker {model.Ticker} : Date {hs.Date} : Open {hs.Open} : High {hs.High} : Low {hs.Low} : Close {hs.Close} : Volume {hs.Volume} : Adj Close{hs.AdjClose}");
                    await _repository.AddHistory(history);
                }
            }
            catch (TaskCanceledException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Get CSV from yahoo finance and parse it
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task StockExchangeParseCsv()
        {
            var url = Cfg.CsvUrl + $"{Cfg.Tickers}&f={Cfg.CsvData}";
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
            var url = Cfg.YahooBaseUrl + YQ.SelectAll + Cfg.YahooXchange + YQ.WherePair +
                      YQ.In + "(%22" + Cfg.Curencies + "%22)" + Cfg.Format + Cfg.Enviroment +
                      Cfg.CallBack;
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
                    var urlTosend = Cfg.YahooLookupAll + s + c + t + "s" + m + "ALL" + b + i + bypass;
                    var data = WebRequest(urlTosend);
                    var doc = new HtmlDocument();
                    doc.LoadHtml(data);

                    var allRowNodes = doc.DocumentNode.SelectNodes("//tr[contains(@class, 'yui-dt')]");
                    if (allRowNodes == null) continue;
                    foreach (var item in allRowNodes)
                    {
                        //if (item == allRowNodes.First()) continue;
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

        public async Task AddYahooCompanyByName(RequestModel model)
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

            for (var i = 0; i <= 200; i += 20)
            {
                var urlTosend = Cfg.YahooLookupAll + s + model.Ticker + t + "s" + m + "ALL" + b + i + bypass;
                var data = WebRequest(urlTosend);
                var doc = new HtmlDocument();
                doc.LoadHtml(data);

                var allRowNodes = doc.DocumentNode.SelectNodes("//tr[contains(@class, 'yui-dt')]");
                if (allRowNodes == null) continue;
                foreach (var item in allRowNodes)
                {

                    var com = item.FirstChild.InnerText;
                    var tickerName = item.ChildNodes[1].InnerText;
                    var lastTrade = item.ChildNodes[2].InnerText;
                    var type = item.ChildNodes[3].InnerText;
                    var industryN = item.ChildNodes[4].InnerText;
                    var exchangeId = item.ChildNodes[5].InnerText;
                    var exc = new Exchange() {StockExchangeId = exchangeId};
                    var excId = await _repository.AddExchange(exc);
                    //var sector = new Sector { Name = sec };
                    var industry = new Industry {Name = industryN};
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
            var url = Cfg.NasdqCompanies + Cfg.NasdqRegionCsv + Cfg.NasdqRender;
            try
            {
                var csvData = WebRequest(url);

                //Parse CSV
                var rows = ParseCsv(csvData);
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
                var reg = new Region { Name = Cfg.NasdqRegion };
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
                var csvData = WebRequest(Cfg.IsoCurrencyUrl);
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
            try
            {
                using (var web = new WebClient())
                {
                    try
                    {
                        web.Encoding = Encoding.UTF8;
                        var urlEncoded = WebUtility.UrlEncode(url);
                        web.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/57.0.2987.133 Safari/537.36";
                        var webResponseData = web.DownloadString(url);
                        return webResponseData;
                    }
                    catch (WebException e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }

                }
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            //Make web request

        }

        private static IEnumerable<string> ParseCsv(string csvData)
        {
            var rows = csvData.Replace("\r", "").Split('\n');
            return rows;
        }
    }
}

