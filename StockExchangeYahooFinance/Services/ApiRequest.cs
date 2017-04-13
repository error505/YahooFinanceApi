﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using StockExchangeYahooFinance.ConfigData;
using StockExchangeYahooFinance.Data;
using StockExchangeYahooFinance.Data.Models;
using StockExchangeYahooFinance.DbContext;
using StockExchangeYahooFinance.Repository;
using StockExchangeYahooFinance.Data.ViewModel;

namespace StockExchangeYahooFinance.Services
{
    public class ApiRequest : IApiRequest
    {
        private readonly YahooFinanceDbContext _context;
        private readonly StockExchangeRepository _repository;

        public ApiRequest(YahooFinanceDbContext context, StockExchangeRepository repository)
        {
            _context = context;
            _repository = repository;
        }
        /// <summary>
        /// Get JSON data from yahoo finance and parse it
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task StockExchangeTask(TimeSpan interval, CancellationToken cancellationToken, string url)
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
                    var json = WebRequest(url);
                    var d = new FinanceData();
                    dynamic data = JObject.Parse(json);
                    var quote = data.query.results.quote;
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
        /// Get CSV from yahoo finance and parse it
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public List<FinanceModel> StockExchangeParseCsv(string url)
        {
            //Call web request
            var csvData = WebRequest(url);
            //Parse CSV
            var rows = csvData.Replace("\r", "").Split('\n');
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
            }

            Console.Read();

            return prices;
        }

        /// <summary>
        /// For Currency XCHANGE
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="url"></param>
        /// <returns>List of Currencies with id, bid, name, rate, date....</returns>
        public async Task XchangeTask(TimeSpan interval, CancellationToken cancellationToken, string url)
        {

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

        private bool IdExists(string id)
        {
            return _context.FinanceModel.Any(e => e.Id == id);
        }

        public async Task ImportCompanies(TimeSpan interval, CancellationToken cancellationToken, string url, string region)
        {

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
                var reg = new Region { Name = region };
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

        public async Task ImportCurrencies(string url)
        {

            try
            {
                var csvData = WebRequest(url);
                XDocument currency = XDocument.Parse(csvData);

                //Get data from string
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
    }
}

