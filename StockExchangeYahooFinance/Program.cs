﻿using System;
using Microsoft.Practices.Unity;
using StockExchangeYahooFinance.Mappings;
using StockExchangeYahooFinance.Models;
using StockExchangeYahooFinance.Services.ApiRequest;
using StockExchangeYahooFinance.Services.Menu;

namespace StockExchangeYahooFinance
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }
        private static void Run()
        {
            var container = new UnityContainer();
            ContainerBootstrapper.RegisterTypes(container);
            var request = container.Resolve<ApiRequest>();
            var model = new RequestModel();
            var menu = new IMenu[]
            {
                new YahooCompanies(),
                new StockExchangeForCompanies(),
                new CurrenciesExchange(),
                new ImportCurrenciesTask(),
                new ImportCompaniesNasdaq(),
                new StockExchangeJson(),
                new StockExchangeTaskParseCsv(),
                new YahooHistoricalDataCsv(),
                new YahooHistoricalDataQuery(),
                new YahooCompanyProfile(),
                new YahooCompanyByName(),
                new YahooRssByCompanyName(),
                new YahooCompanyIncomeStatementHistory(),
                new YahooCompanyCashflowStatementHistory(),
                new YahooMajorHoldersBreakdownRequest(),
                new YahooRecommendationTrendRequest(), 
                new YahooUpgradeDowngradeHistoryRequest(),
                new YahooInstitutionOwnershipRequest(), 
                new YahooFinancialDataRequest(), 
                new YahooCashflowStatementHistoryQuarterlyRequest(), 
                new YahooCompanyIncomeStatementHistoryQuarterly(), 
                new YahooCompanyProfileSummaryRequest(),  
                new YahooMajorDirectHoldersRequest(), 
                new YahooFundOwnershipRequest(), 
                new YahooInsiderTransactionsRequest(), 
                new YahooInsiderHoldersRequest(), 
                new YahooBalanceSheetHistoryRequest(), 
                new YahooBalanceSheetHistoryQuarterlyRequest(), 
                new YahooDefaultKeyStatisticsRequest(), 
                new YahooEarningsTrendRequest(), 
            };

            while (true)
            {
                Console.WriteLine("Welcome to Stock Exchange Scrapper.");
                Console.WriteLine("What do you want to do?");

                // This loop creates a list of commands:
                for (var i = 0; i < menu.Length; i++)
                {
                    Console.WriteLine("{0}. {1}", i + 1, menu[i].Description);
                }

                // Read until the input is valid.
                string selected;
                int commandIndex;
                do
                {
                    selected = Console.ReadLine();
                }
                while (!int.TryParse(selected, out commandIndex) || commandIndex > menu.Length);
                // Execute the command.
                menu[commandIndex - 1].Execute(request, model);
            }
        }
    }
}
