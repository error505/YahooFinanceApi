using System;
using System.Collections.Generic;
using System.Globalization;
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
        private static readonly YModulesFields YMF = new YModulesFields();
        private static readonly YahooModules YM = new YahooModules();
        //Initialize FinanceData
        private static readonly FinanceData FinanceData = new FinanceData();
        private readonly CallWebRequest _callWebRequest = new CallWebRequest();
        private readonly ParsersConverters _parsersConvertert = new ParsersConverters();
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
                        if (value != null && Convert.ToDouble(change) < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{name}:{symbol} : {price} : {lastTime} : {change}");
                        }
                        if (value == null || Convert.ToDouble(change <= 0)) continue;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{name} : {symbol} : {price} : {lastTime} : {change}");
                        await _repository.AddFinanceModel(f);
                    }
                }
                catch (TaskCanceledException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
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
                      "(%22" + model.Ticker + "%22)" + YQ.And + YQ.StartDate + "2012-09-11" +
                      YQ.And + YQ.EndDate + "2014-02-11" + Cfg.Format + Cfg.Enviroment +
                      Cfg.CallBack;
            try
            {
                Console.Clear();
                var json = await _callWebRequest.WebRequest(url);
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
            catch (TaskCanceledException ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
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
            Console.Clear();
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
            catch (TaskCanceledException ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
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
                var json = await _callWebRequest.WebRequest(url);
                //dynamic data = JObject.Parse(json.Result);
                //var profile = data.quoteSummary.result;
                var d = JObject.Parse(json);
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
                            if (unExercisedValue != null && unExercisedValue.Count() != 0)
                            {
                                var unexcValue = s["unexercisedValue"]["raw"];
                                compOffices.UnexercisedValue = (int)(unexcValue);
                            }
                            if (totalPay != null && totalPay.Count() != 0)
                            {
                                var row = s["totalPay"]["raw"];
                                compOffices.TotalPay = (int)(row);
                            }
                            if (exercisedValue != null && exercisedValue.Count() != 0)
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
            catch (TaskCanceledException ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }
        }
        //TODO: Finish this call and create others for all other modules and create repository functions for each module
        /// <summary>
        /// Get Company Profile from Yahoo finance
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task YahooIncomeStatementHistory(RequestModel model)
        {
            var modules = new YahooModules();
            var url = Cfg.YahooQuoteSummary + model.Ticker + Cfg.YFormated + Cfg.YModules + modules.IncomeStatementHistory + Cfg.YCorsDomain;
            try
            {
                Console.Clear();
                var json = await _callWebRequest.WebRequest(url);
                var d = JObject.Parse(json);
                var symbolId = await _repository.GetCompanyByName(model.Ticker);
                var incomeStatementHistory = d["quoteSummary"]["result"][0][YM.IncomeStatementHistory][YM.IncomeStatementHistory];
                string incomeStatementHistoryId = null;
                var companyExists = true;
                while (companyExists)
                {
                    if (symbolId != null)
                    {
                        foreach (var i in incomeStatementHistory)
                        {
                            var iSh = new IncomeStatementHistory();
                            var endDate = i.SelectToken(YMF.EndDate);
                            string formatedEndDate = null;
                            if (endDate != null && endDate.Count() != 0)
                            {
                                formatedEndDate = endDate["fmt"].ToString();
                                iSh.EndDate = formatedEndDate;
                            }
                            var totalRevenue = i.SelectToken(YMF.TotalRevenue);
                            string totalRevenueRaw = null;
                            if (totalRevenue != null && totalRevenue.Count() != 0)
                            {
                                totalRevenueRaw = totalRevenue["raw"].ToString();
                                iSh.TotalRevenue = totalRevenueRaw;
                            }
                            var costOfRevenue = i.SelectToken(YMF.CostOfRevenue);
                            if (costOfRevenue != null && costOfRevenue.Count() != 0)
                            {
                                var costOfRevenueRaw = costOfRevenue["raw"].ToString();
                                iSh.CostOfRevenue = costOfRevenueRaw;
                            }
                            var grossProfit = i.SelectToken(YMF.GrossProfit);
                            if (grossProfit != null && grossProfit.Count() != 0)
                            {
                                var grossProfitRaw = grossProfit["raw"].ToString();
                                iSh.GrossProfit = grossProfitRaw;
                            }
                            var researchDevelopment = i.SelectToken(YMF.ResearchDevelopment);
                            if (researchDevelopment != null && researchDevelopment.Count() != 0)
                            {
                                var researchDevelopmentRaw = researchDevelopment["raw"].ToString();
                                iSh.ResearchDevelopment = researchDevelopmentRaw;
                            }
                            var sellingGeneralAdministrative = i.SelectToken(YMF.SellingGeneralAdministrative);
                            if (sellingGeneralAdministrative != null && sellingGeneralAdministrative.Count() != 0)
                            {
                                var sellingGeneralAdministrativeRaw = sellingGeneralAdministrative["raw"].ToString();
                                iSh.SellingGeneralAdministrative = sellingGeneralAdministrativeRaw;
                            }
                            var nonRecurring = i.SelectToken(YMF.NonRecurring);
                            if (nonRecurring != null && nonRecurring.Count() != 0)
                            {
                                var nonRecurringRaw = nonRecurring["raw"].ToString();
                                iSh.NonRecurring = nonRecurringRaw;
                            }
                            var otherOperatingExpenses = i.SelectToken(YMF.OtherOperatingExpenses);
                            if (otherOperatingExpenses != null && otherOperatingExpenses.Count() != 0)
                            {
                                var otherOperatingExpensesRaw = otherOperatingExpenses["raw"].ToString();
                                iSh.OtherOperatingExpenses = otherOperatingExpensesRaw;
                            }
                            var totalOperatingExpenses = i.SelectToken(YMF.TotalOperatingExpenses);
                            if (totalOperatingExpenses != null && totalOperatingExpenses.Count() != 0)
                            {
                                var totalOperatingExpensesRaw = totalOperatingExpenses["raw"].ToString();
                                iSh.TotalOperatingExpenses = totalOperatingExpensesRaw;
                            }
                            var operatingIncome = i.SelectToken(YMF.OperatingIncome);
                            if (operatingIncome != null && operatingIncome.Count() != 0)
                            {
                                var operatingIncomeRaw = operatingIncome["raw"].ToString();
                                iSh.OperatingIncome = operatingIncomeRaw;
                            }
                            var totalOtherIncomeExpenseNet = i.SelectToken(YMF.TotalOtherIncomeExpenseNet);
                            if (totalOtherIncomeExpenseNet != null && totalOtherIncomeExpenseNet.Count() != 0)
                            {
                                var totalOtherIncomeExpenseNetRaw = totalOtherIncomeExpenseNet["raw"].ToString();
                                iSh.TotalOtherIncomeExpenseNet = totalOtherIncomeExpenseNetRaw;
                            }
                            var ebit = i.SelectToken(YMF.Ebit);
                            if (ebit != null && ebit.Count() != 0)
                            {
                                var ebitRaw = ebit["raw"].ToString();
                                iSh.Ebit = ebitRaw;
                            }
                            var interestExpense = i.SelectToken(YMF.InterestExpense);
                            if (interestExpense != null && interestExpense.Count() != 0)
                            {
                                var interestExpenseRaw = interestExpense["raw"].ToString();
                                iSh.InterestExpense = interestExpenseRaw;
                            }
                            var incomeBeforeTax = i.SelectToken(YMF.IncomeBeforeTax);
                            if (incomeBeforeTax != null && incomeBeforeTax.Count() != 0)
                            {
                                var incomeBeforeTaxRaw = incomeBeforeTax["raw"].ToString();
                                iSh.IncomeBeforeTax = incomeBeforeTaxRaw;
                            }
                            var incomeTaxExpense = i.SelectToken(YMF.IncomeTaxExpense);
                            if (incomeTaxExpense != null && incomeTaxExpense.Count() != 0)
                            {
                                var incomeTaxExpenseRaw = incomeTaxExpense["raw"].ToString();
                                iSh.IncomeTaxExpense = incomeTaxExpenseRaw;
                            }
                            var minorityInterest = i.SelectToken(YMF.MinorityInterest);
                            if (minorityInterest != null && minorityInterest.Count() != 0)
                            {
                                var minorityInterestRaw = minorityInterest["raw"].ToString();
                                iSh.MinorityInterest = minorityInterestRaw;
                            }
                            var discontinuedOperations = i.SelectToken(YMF.DiscontinuedOperations);
                            if (discontinuedOperations != null && discontinuedOperations.Count() != 0)
                            {
                                var discontinuedOperationsRaw = discontinuedOperations["raw"].ToString();
                                iSh.DiscontinuedOperations = discontinuedOperationsRaw;
                            }
                            var extraordinaryItems = i.SelectToken(YMF.ExtraordinaryItems);
                            if (extraordinaryItems != null && extraordinaryItems.Count() != 0)
                            {
                                var extraordinaryItemsRaw = extraordinaryItems["raw"].ToString();
                                iSh.ExtraordinaryItems = extraordinaryItemsRaw;
                            }
                            var effectOfAccountingCharges = i.SelectToken(YMF.EffectOfAccountingCharges);
                            if (effectOfAccountingCharges != null && effectOfAccountingCharges.Count() != 0)
                            {
                                var effectOfAccountingChargesRaw = effectOfAccountingCharges["raw"].ToString();
                                iSh.EffectOfAccountingCharges = effectOfAccountingChargesRaw;
                            }
                            var otherItems = i.SelectToken(YMF.OtherItems);
                            if (otherItems != null && otherItems.Count() != 0)
                            {
                                var otherItemsRaw = otherItems["raw"].ToString();
                                iSh.OtherItems = otherItemsRaw;
                            }
                            var netIncome = i.SelectToken(YMF.NetIncome);
                            if (netIncome != null && netIncome.Count() != 0)
                            {
                                var netIncomeRaw = netIncome["raw"].ToString();
                                iSh.NetIncome = netIncomeRaw;
                            }
                            var netIncomeApplicableToCommonShares = i.SelectToken(YMF.NetIncomeApplicableToCommonShares);
                            if (netIncomeApplicableToCommonShares != null && netIncomeApplicableToCommonShares.Count() != 0)
                            {
                                var netIncomeApplicableToCommonSharesRaw = netIncomeApplicableToCommonShares["raw"].ToString();
                                iSh.NetIncomeApplicableToCommonShares = netIncomeApplicableToCommonSharesRaw;
                            }
                            var netIncomeFromContinuingOps = i.SelectToken(YMF.NetIncomeFromContinuingOps);
                            if (netIncomeFromContinuingOps != null && netIncomeFromContinuingOps.Count() != 0)
                            {
                                var netIncomeFromContinuingOpsRaw = netIncomeApplicableToCommonShares["raw"].ToString();
                                iSh.NetIncomeFromContinuingOps = netIncomeFromContinuingOpsRaw;
                            }
                            Console.WriteLine($"{model.Ticker} : {formatedEndDate} : {totalRevenueRaw}");
                            iSh.CompaniesId = symbolId.Id;
                            iSh.CreatedByUser = Cfg.UserName;
                            incomeStatementHistoryId = iSh.Id;
                            await _repository.AddIncomeStatementHistory(iSh);
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
            catch (TaskCanceledException ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task YahooCashFlowStatementHistory(RequestModel model)
        {
            var modules = new YahooModules();
            var url = Cfg.YahooQuoteSummary + model.Ticker + Cfg.YFormated + Cfg.YModules + modules.CashflowStatementHistory + Cfg.YCorsDomain;
            try
            {
                Console.Clear();
                var json = await _callWebRequest.WebRequest(url);
                var d = JObject.Parse(json);
                var symbolId = await _repository.GetCompanyByName(model.Ticker);
                var cashflowStatement = d["quoteSummary"]["result"][0][YM.CashflowStatementHistory]["cashflowStatements"];
                string incomeStatementHistoryId = null;
                var companyExists = true;
                while (companyExists)
                {
                    if (symbolId != null)
                    {
                        foreach (var i in cashflowStatement)
                        {
                            var cfsh = new CashflowStatement();
                            var endDate = i.SelectToken(YMF.EndDate);
                            string formatedEndDate = null;
                            if (endDate != null && endDate.Count() != 0)
                            {
                                formatedEndDate = endDate["fmt"].ToString();
                                cfsh.EndDate = formatedEndDate;
                            }
                            var depreciation = i.SelectToken(YMF.Depreciation);
                            string depreciationRaw = null;
                            if (depreciation != null && depreciation.Count() != 0)
                            {
                                depreciationRaw = depreciation["raw"].ToString();
                                cfsh.Depreciation = depreciationRaw;
                            }
                            
                            var otherCashflowsFromFinancingActivities = i.SelectToken(YMF.OtherCashflowsFromFinancingActivities);
                            if (otherCashflowsFromFinancingActivities != null && otherCashflowsFromFinancingActivities.Count() != 0)
                            {
                                var otherCashflowsFromFinancingActivitiesRaw = otherCashflowsFromFinancingActivities["raw"].ToString();
                                cfsh.OtherCashflowsFromFinancingActivities = otherCashflowsFromFinancingActivitiesRaw;
                            }
                            var changeToInventory = i.SelectToken(YMF.ChangeToInventory);
                            if (changeToInventory != null && changeToInventory.Count() != 0)
                            {
                                var changeToInventoryRaw = changeToInventory["raw"].ToString();
                                cfsh.ChangeToInventory = changeToInventoryRaw;
                            }
                            var capitalExpenditures = i.SelectToken(YMF.CapitalExpenditures);
                            if (capitalExpenditures != null && capitalExpenditures.Count() != 0)
                            {
                                var capitalExpendituresRaw = capitalExpenditures["raw"].ToString();
                                cfsh.CapitalExpenditures = capitalExpendituresRaw;
                            }
                            var netIncome = i.SelectToken(YMF.NetIncome);
                            if (netIncome != null && netIncome.Count() != 0)
                            {
                                var netIncomeRaw = netIncome["raw"].ToString();
                                cfsh.NetIncome = netIncomeRaw;
                            }
                            var changeToNetincome = i.SelectToken(YMF.ChangeToNetincome);
                            if (changeToNetincome != null && changeToNetincome.Count() != 0)
                            {
                                var changeToNetincomeRaw = changeToNetincome["raw"].ToString();
                                cfsh.ChangeToNetincome = changeToNetincomeRaw;
                            }
                            var changeToAccountReceivables = i.SelectToken(YMF.ChangeToAccountReceivables);
                            if (changeToAccountReceivables != null && changeToAccountReceivables.Count() != 0)
                            {
                                var changeToAccountReceivablesRaw = changeToAccountReceivables["raw"].ToString();
                                cfsh.ChangeToAccountReceivables = changeToAccountReceivablesRaw;
                            }
                            var changeToLiabilities = i.SelectToken(YMF.ChangeToLiabilities);
                            if (changeToLiabilities != null && changeToLiabilities.Count() != 0)
                            {
                                var changeToLiabilitiesRaw = changeToLiabilities["raw"].ToString();
                                cfsh.ChangeToLiabilities = changeToLiabilitiesRaw;
                            }
                            var changeToOperatingActivities = i.SelectToken(YMF.ChangeToOperatingActivities);
                            if (changeToOperatingActivities != null && changeToOperatingActivities.Count() != 0)
                            {
                                var changeToOperatingActivitiesRaw = changeToOperatingActivities["raw"].ToString();
                                cfsh.ChangeToOperatingActivities = changeToOperatingActivitiesRaw;
                            }
                            var totalCashFromOperatingActivities = i.SelectToken(YMF.TotalCashFromOperatingActivities);
                            if (totalCashFromOperatingActivities != null && totalCashFromOperatingActivities.Count() != 0)
                            {
                                var totalCashFromOperatingActivitiesRaw = totalCashFromOperatingActivities["raw"].ToString();
                                cfsh.TotalCashFromOperatingActivities = totalCashFromOperatingActivitiesRaw;
                            }
                            var investments = i.SelectToken(YMF.Investments);
                            if (investments != null && investments.Count() != 0)
                            {
                                var investmentsRaw = investments["raw"].ToString();
                                cfsh.Investments = investmentsRaw;
                            }
                            var otherCashflowsFromInvestingActivities = i.SelectToken(YMF.OtherCashflowsFromInvestingActivities);
                            if (otherCashflowsFromInvestingActivities != null && otherCashflowsFromInvestingActivities.Count() != 0)
                            {
                                var otherCashflowsFromInvestingActivitiesRaw = otherCashflowsFromInvestingActivities["raw"].ToString();
                                cfsh.OtherCashflowsFromInvestingActivities = otherCashflowsFromInvestingActivitiesRaw;
                            }
                            var totalCashflowsFromInvestingActivities = i.SelectToken(YMF.TotalCashflowsFromInvestingActivities);
                            if (totalCashflowsFromInvestingActivities != null && totalCashflowsFromInvestingActivities.Count() != 0)
                            {
                                var totalCashflowsFromInvestingActivitiesRaw = totalCashflowsFromInvestingActivities["raw"].ToString();
                                cfsh.TotalCashflowsFromInvestingActivities = totalCashflowsFromInvestingActivitiesRaw;
                            }
                            var dividendsPaid = i.SelectToken(YMF.DividendsPaid);
                            if (dividendsPaid != null && dividendsPaid.Count() != 0)
                            {
                                var dividendsPaidRaw = dividendsPaid["raw"].ToString();
                                cfsh.DividendsPaid = dividendsPaidRaw;
                            }
                            var salePurchaseOfStock = i.SelectToken(YMF.SalePurchaseOfStock);
                            if (salePurchaseOfStock != null && salePurchaseOfStock.Count() != 0)
                            {
                                var salePurchaseOfStockRaw = salePurchaseOfStock["raw"].ToString();
                                cfsh.SalePurchaseOfStock = salePurchaseOfStockRaw;
                            }
                            var netBorrowings = i.SelectToken(YMF.NetBorrowings);
                            if (netBorrowings != null && netBorrowings.Count() != 0)
                            {
                                var netBorrowingsRaw = netBorrowings["raw"].ToString();
                                cfsh.NetBorrowings = netBorrowingsRaw;
                            }
                            var totalCashFromFinancingActivities = i.SelectToken(YMF.TotalCashFromFinancingActivities);
                            if (totalCashFromFinancingActivities != null && totalCashFromFinancingActivities.Count() != 0)
                            {
                                var totalCashFromFinancingActivitiesRaw = totalCashFromFinancingActivities["raw"].ToString();
                                cfsh.TotalCashFromFinancingActivities = totalCashFromFinancingActivitiesRaw;
                            }
                            var effectOfExchangeRate = i.SelectToken(YMF.EffectOfExchangeRate);
                            if (effectOfExchangeRate != null && effectOfExchangeRate.Count() != 0)
                            {
                                var effectOfExchangeRateRaw = effectOfExchangeRate["raw"].ToString();
                                cfsh.EffectOfExchangeRate = effectOfExchangeRateRaw;
                            }
                            var changeInCash = i.SelectToken(YMF.ChangeInCash);
                            if (changeInCash != null && changeInCash.Count() != 0)
                            {
                                var changeInCashRaw = changeInCash["raw"].ToString();
                                cfsh.ChangeInCash = changeInCashRaw;
                            }                           
                            Console.WriteLine($"{model.Ticker} : {formatedEndDate} : {depreciationRaw}");
                            cfsh.CompaniesId = symbolId.Id;
                            cfsh.CreatedByUser = Cfg.UserName;
                            incomeStatementHistoryId = cfsh.Id;
                            await _repository.AddCashflowStatementHistory(cfsh);
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
            catch (TaskCanceledException ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task YahooMajorHoldersBreakdown(RequestModel model)
        {
            var modules = new YahooModules();
            var url = Cfg.YahooQuoteSummary + model.Ticker + Cfg.YFormated + Cfg.YModules + modules.MajorHoldersBreakdown + Cfg.YCorsDomain;
            try
            {
                Console.Clear();
                var json = await _callWebRequest.WebRequest(url);
                var d = JObject.Parse(json);
                var symbolId = await _repository.GetCompanyByName(model.Ticker);
                var majorHoldersBreakdown = d["quoteSummary"]["result"][0][YM.MajorHoldersBreakdown];
                string majorHoldersBreakdownId = null;
                var companyExists = true;
                while (companyExists)
                {
                    if (symbolId != null)
                    {                      
                            var cfsh = new MajorHoldersBreakdown();
                            var insidersPercentHeld = majorHoldersBreakdown.SelectToken(YMF.InsidersPercentHeld);
                            if (insidersPercentHeld != null && insidersPercentHeld.Count() != 0)
                            {
                                var insidersPercentHeldRaw = (double)insidersPercentHeld["raw"];
                                cfsh.InsidersPercentHeld = insidersPercentHeldRaw;
                            }
                            var institutionsPercentHeld = majorHoldersBreakdown.SelectToken(YMF.InstitutionsPercentHeld);
                            if (institutionsPercentHeld != null && institutionsPercentHeld.Count() != 0)
                            {
                                var institutionsPercentHeldRaw = (double)institutionsPercentHeld["raw"];
                                cfsh.InstitutionsPercentHeld = institutionsPercentHeldRaw;
                            }
                            var institutionsFloatPercentHeld = majorHoldersBreakdown.SelectToken(YMF.InstitutionsFloatPercentHeld);
                            if (institutionsFloatPercentHeld != null && institutionsFloatPercentHeld.Count() != 0)
                            {
                                var institutionsFloatPercentHeldRaw = (double)institutionsFloatPercentHeld["raw"];
                                cfsh.InstitutionsFloatPercentHeld = institutionsFloatPercentHeldRaw;
                            }
                            var institutionsCount = majorHoldersBreakdown.SelectToken(YMF.InstitutionsCount);
                            if (institutionsCount != null && institutionsCount.Count() != 0)
                            {
                                var institutionsCountRaw = (int)institutionsCount["raw"];
                                cfsh.InstitutionsCount = institutionsCountRaw;
                            }
                            
                            Console.WriteLine($"{model.Ticker}");
                            cfsh.CompaniesId = symbolId.Id;
                            cfsh.CreatedByUser = Cfg.UserName;
                            majorHoldersBreakdownId = cfsh.Id;
                            await _repository.AddMajorHoldersBreakdown(cfsh);
                        
                        companyExists = false;
                    }
                    else
                    {
                        await AddYahooCompanyByName(model);
                        symbolId = await _repository.GetCompanyByName(model.Ticker);
                    }
                }
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }
        }

        public async Task YahooInstitutionOwnership(RequestModel model)
        {
            var modules = new YahooModules();
            var url = Cfg.YahooQuoteSummary + model.Ticker + Cfg.YFormated + Cfg.YModules + modules.MajorHoldersBreakdown + Cfg.YCorsDomain;
            try
            {
                Console.Clear();
                var json = await _callWebRequest.WebRequest(url);
                var d = JObject.Parse(json);
                var symbolId = await _repository.GetCompanyByName(model.Ticker);
                var institutionOwnership = d["quoteSummary"]["result"][0][YM.InstitutionOwnership]["ownershipList"];
                string majorHoldersBreakdownId = null;
                var companyExists = true;
                while (companyExists)
                {
                    if (symbolId != null)
                    {
                        var cfsh = new InstitutionOwnership();
                        var reportDate = institutionOwnership.SelectToken(YMF.ReportDate);
                        if (reportDate != null && reportDate.Count() != 0)
                        {
                            var reportDateFmt = reportDate["fmt"].ToString();
                            cfsh.ReportDate = reportDateFmt;
                        }
                        var organization = institutionOwnership.SelectToken(YMF.Organization);
                        if (organization != null ) cfsh.Organization = organization.ToString();

                        var pctHeld = institutionOwnership.SelectToken(YMF.PctHeld);
                        if (pctHeld != null && pctHeld.Count() != 0)
                        {
                            var pctHeldRaw = (double)pctHeld["raw"];
                            cfsh.PctHeld = pctHeldRaw;
                        }
                        var position = institutionOwnership.SelectToken(YMF.Position);
                        if (position != null && position.Count() != 0)
                        {
                            var positionRaw = (double)position["raw"];
                            cfsh.Position = positionRaw;
                        }
                        var value = institutionOwnership.SelectToken(YMF.Value);
                        if (value != null && value.Count() != 0)
                        {
                            var valueRaw = (double)value["raw"];
                            cfsh.Value = valueRaw;
                        }

                        Console.WriteLine($"{model.Ticker}");
                        cfsh.CompaniesId = symbolId.Id;
                        cfsh.CreatedByUser = Cfg.UserName;
                        await _repository.AddInstitutionOwnership(cfsh);
                        companyExists = false;
                    }
                    else
                    {
                        await AddYahooCompanyByName(model);
                        symbolId = await _repository.GetCompanyByName(model.Ticker);
                    }
                }
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }
        }

        public async Task YahooRecommendationTrend(RequestModel model)
        {
            var modules = new YahooModules();
            var url = Cfg.YahooQuoteSummary + model.Ticker + Cfg.YFormated + Cfg.YModules + modules.RecommendationTrend + Cfg.YCorsDomain;
            try
            {
                Console.Clear();
                var json = await _callWebRequest.WebRequest(url);
                var d = JObject.Parse(json);
                var symbolId = await _repository.GetCompanyByName(model.Ticker);
                var recommendationTrend = d["quoteSummary"]["result"][0][YM.RecommendationTrend]["trend"];
                var companyExists = true;
                while (companyExists)
                {
                    if (symbolId != null)
                    {
                        foreach (var i in recommendationTrend)
                        {
                            var cfsh = new RecommendationTrend();
                            var period = i.SelectToken(YMF.Period);
                            if (period != null) cfsh.Period = period.ToString();
                            var strongBuy = i.SelectToken(YMF.StrongBuy);
                            if (strongBuy != null) cfsh.StrongBuy = Convert.ToDouble(strongBuy);
                            var buy = i.SelectToken(YMF.Buy);
                            if (buy != null) cfsh.Buy = Convert.ToDouble(buy);
                            var hold = i.SelectToken(YMF.Hold);
                            if (hold != null) cfsh.Hold = Convert.ToDouble(hold);
                            var sell = i.SelectToken(YMF.Sell);
                            if (sell != null) cfsh.Sell = Convert.ToDouble(sell);
                            var strongSell = i.SelectToken(YMF.StrongSell);
                            if (strongSell != null) cfsh.StrongSell = Convert.ToDouble(strongSell);
                            Console.WriteLine($"{model.Ticker} : {period} : {strongBuy} : {buy} : {sell}");
                            cfsh.CompaniesId = symbolId.Id;
                            cfsh.CreatedByUser = Cfg.UserName;
                            await _repository.AddRecommendationTrend(cfsh);
                            companyExists = false;
                        }
                    }
                    else
                    {
                        await AddYahooCompanyByName(model);
                        symbolId = await _repository.GetCompanyByName(model.Ticker);
                    }
                }
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }
        }

        public async Task YahooUpgradeDowngradeHistory(RequestModel model)
        {
            var modules = new YahooModules();
            var url = Cfg.YahooQuoteSummary + model.Ticker + Cfg.YFormated + Cfg.YModules + modules.UpgradeDowngradeHistory + Cfg.YCorsDomain;
            try
            {
                Console.Clear();
                var json = await _callWebRequest.WebRequest(url);
                var d = JObject.Parse(json);
                var symbolId = await _repository.GetCompanyByName(model.Ticker);
                var upgradeDowngradeHistory = d["quoteSummary"]["result"][0][YM.UpgradeDowngradeHistory]["history"];
                var companyExists = true;
                while (companyExists)
                {
                    if (symbolId != null)
                    {
                        foreach (var i in upgradeDowngradeHistory)
                        {
                            var cfsh = new UpgradeDowngradeHistory();
                            var epochGradeDate = i.SelectToken(YMF.EpochGradeDate);
                            DateTime grandDateNormal = new DateTime();
                            if (epochGradeDate != null) grandDateNormal = _parsersConvertert.UnixTimeStampToDateTime(Convert.ToDouble(epochGradeDate));
                            if (epochGradeDate != null) cfsh.EpochGradeDate = grandDateNormal.ToString(CultureInfo.InvariantCulture);
                            var firm = i.SelectToken(YMF.Firm);
                            if (firm != null) cfsh.Firm = firm.ToString();
                            var toGrade = i.SelectToken(YMF.ToGrade);
                            if (toGrade != null) cfsh.ToGrade = toGrade.ToString();
                            var fromGrade = i.SelectToken(YMF.FromGrade);
                            if (fromGrade != null) cfsh.FromGrade = fromGrade.ToString();
                            var action = i.SelectToken(YMF.Action);
                            if (action != null) cfsh.Action = action.ToString();                            
                            Console.WriteLine($"{model.Ticker} : {grandDateNormal} : {firm} : {toGrade} : {action}");
                            cfsh.CompaniesId = symbolId.Id;
                            cfsh.CreatedByUser = Cfg.UserName;
                            await _repository.AddUpgradeDowngradeHistory(cfsh);
                            companyExists = false;
                        }
                    }
                    else
                    {
                        await AddYahooCompanyByName(model);
                        symbolId = await _repository.GetCompanyByName(model.Ticker);
                    }
                }
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task YahooHistoricalDataCsv(RequestModel model)
        {
            var symbol = "s=";
            var startDate = "c=";
            var url = Cfg.YahooHistoryCsv + symbol + model.Ticker;
            try
            {
                var csvData = await _callWebRequest.WebRequest(url);
                var rows = _parsersConvertert.ParseCsv(csvData);
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
            var request = await _callWebRequest.WebRequest(url);
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
                    var json = await _callWebRequest.WebRequest(url);
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
                catch (TaskCanceledException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
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
                    var data = await _callWebRequest.WebRequest(urlTosend);
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
                var data = await _callWebRequest.WebRequest(urlTosend);
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
                var csvData = await _callWebRequest.WebRequest(url);

                //Parse CSV
                var rows = _parsersConvertert.ParseCsv(csvData);
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
                var csvData = await _callWebRequest.WebRequest(Cfg.IsoCurrencyUrl);
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
    }
}

