using System;
using System.Threading;
using System.Threading.Tasks;
using StockExchangeYahooFinance.Models;

namespace StockExchangeYahooFinance.Services.Menu
{
    internal class YahooCompanies : IMenu
    {
        public string Description => "Add a list of yahoo companies to database.";
        public async Task Execute(ApiRequest.ApiRequest execTask, RequestModel model)
        {
            await execTask.YahooCompanies();
        }
    }

    internal class StockExchangeForCompanies : IMenu
    {
        public string Description => "Import List of yahoo exchanges from XML file.";
        public async Task Execute(ApiRequest.ApiRequest execTask, RequestModel model)
        {
            await execTask.YahooExchanges();
        }
    }

    internal class CurrenciesExchange : IMenu
    {
        public string Description => "Show Currency Exchange.";
        public async Task Execute(ApiRequest.ApiRequest execTask, RequestModel model)
        {
            var cancellation = new CancellationTokenSource(Timeout.Infinite);
            await execTask.XchangeTask(TimeSpan.FromSeconds(5), cancellation.Token);
        }
    }
    internal class ImportCompaniesNasdaq : IMenu
    {
        public string Description => "Import list of the companies into the database from NASDAQ!";
        public async Task Execute(ApiRequest.ApiRequest execTask, RequestModel model)
        {
            var cancellation = new CancellationTokenSource(Timeout.Infinite);
            await execTask.ImportCompanies(TimeSpan.FromSeconds(7), cancellation.Token);
        }
    }

    internal class ImportCurrenciesTask : IMenu
    {
        public string Description => "Import the list of the Currencies from ISO Currencies web site.";
        public async Task Execute(ApiRequest.ApiRequest execTask, RequestModel model)
        {
            await execTask.ImportCurrencies();
        }
    }

    internal class StockExchangeJson : IMenu
    {
        public string Description => "Check for stock market for the list of selected tickers (Data will be returned in JSON format)!";
        public async Task Execute(ApiRequest.ApiRequest execTask, RequestModel model)
        {
            var cancellation = new CancellationTokenSource(Timeout.Infinite);
            await execTask.StockExchangeTask(TimeSpan.FromMilliseconds(900), cancellation.Token);
        }
    }

    internal class StockExchangeTaskParseCsv : IMenu
    {
        public string Description => "Check for stock market for the list of selected tickers (Data will be returned in CSV format)!";
        public async Task Execute(ApiRequest.ApiRequest execTask, RequestModel model)
        {
            await execTask.StockExchangeParseCsv();
        }
    }

    internal class YahooHistoricalDataCsv : IMenu
    {
        public string Description => "Check for yahoo historical data for selected company! (Data will be returned in CSV format)!";
        public async Task Execute(ApiRequest.ApiRequest execTask, RequestModel model)
        {
            await execTask.YahooHistoricalDataCsv(model);
        }
    }

    internal class YahooHistoricalDataQuery : IMenu
    {
        public string Description => "Check for yahoo historical data for selected company! (Data will be returned in Json format)!";
        public async Task Execute(ApiRequest.ApiRequest execTask, RequestModel model)
        {
            Console.WriteLine("Please enter the symbol!");
            var symbol = Console.ReadLine();
            model.Ticker = symbol;
            await execTask.YahooHistoricalDataQuery(model);
        }
    }

    internal class YahooCompanyProfile : IMenu
    {
        public string Description => "Get Yahoo Company Profile for selected company! (Data will be returned in Json format)!";
        public async Task Execute(ApiRequest.ApiRequest execTask, RequestModel model)
        {
            Console.WriteLine("Please enter the symbol!");
            var symbol = Console.ReadLine();
            model.Ticker = symbol;
            await execTask.YahooCompanyProfile(model);
        }
    }

    internal class YahooCompanyProfileSummaryRequest : IMenu
    {
        public string Description => "Get Yahoo Company Profile Summary for selected company! (Data will be returned in Json format)!";
        public async Task Execute(ApiRequest.ApiRequest execTask, RequestModel model)
        {
            Console.WriteLine("Please enter the symbol!");
            var symbol = Console.ReadLine();
            model.Ticker = symbol;
            await execTask.YahooCompanyProfileSummary(model);
        }
    }

    internal class YahooCompanyByName : IMenu
    {
        public string Description => "Get Yahoo Company Profile for selected company! (Data will be returned in Json format)!";
        public async Task Execute(ApiRequest.ApiRequest execTask, RequestModel model)
        {
            Console.WriteLine("Please enter the symbol!");
            var symbol = Console.ReadLine();
            model.Ticker = symbol;
            await execTask.AddYahooCompanyByName(model);
        }
    }

    internal class YahooRssByCompanyName : IMenu
    {
        public string Description => "Get Yahoo Company RSS Feed! (Data will be returned in Json format)!";
        public async Task Execute(ApiRequest.ApiRequest execTask, RequestModel model)
        {
            Console.WriteLine("Please enter the symbol!");
            var symbol = Console.ReadLine();
            model.Ticker = symbol;
            await execTask.YahooRssFeed(model);
        }
    }
    internal class YahooCompanyIncomeStatementHistory : IMenu
    {
        public string Description => "Get Yahoo Company Income History! (Data will be returned in Json format)!";
        public async Task Execute(ApiRequest.ApiRequest execTask, RequestModel model)
        {
            Console.WriteLine("Please enter the symbol!");
            var symbol = Console.ReadLine();
            model.Ticker = symbol;
            await execTask.YahooIncomeStatementHistory(model);
        }
    }

    internal class YahooCompanyIncomeStatementHistoryQuarterly : IMenu
    {
        public string Description => "Get Yahoo Company Income History Quarterly! (Data will be returned in Json format)!";
        public async Task Execute(ApiRequest.ApiRequest execTask, RequestModel model)
        {
            Console.WriteLine("Please enter the symbol!");
            var symbol = Console.ReadLine();
            model.Ticker = symbol;
            await execTask.YahooIncomeStatementHistoryQuarterly(model);
        }
    }

    internal class YahooCompanyCashflowStatementHistory : IMenu
    {
        public string Description => "Get Yahoo Company Cash Flow Statement History! (Data will be returned in Json format)!";
        public async Task Execute(ApiRequest.ApiRequest execTask, RequestModel model)
        {
            Console.WriteLine("Please enter the symbol!");
            var symbol = Console.ReadLine();
            model.Ticker = symbol;
            await execTask.YahooCashFlowStatementHistory(model);
        }
    }

    internal class YahooCashflowStatementHistoryQuarterlyRequest : IMenu
    {
        public string Description => "Get Yahoo Company Cash Flow Statement History Quarterly! (Data will be returned in Json format)!";
        public async Task Execute(ApiRequest.ApiRequest execTask, RequestModel model)
        {
            Console.WriteLine("Please enter the symbol!");
            var symbol = Console.ReadLine();
            model.Ticker = symbol;
            await execTask.YahooCashflowStatementHistoryQuarterly(model);
        }
    }


    internal class YahooMajorHoldersBreakdownRequest : IMenu
    {
        public string Description => "Get Yahoo Company Major Holders Breakdown! (Data will be returned in Json format)!";
        public async Task Execute(ApiRequest.ApiRequest execTask, RequestModel model)
        {
            Console.WriteLine("Please enter the symbol!");
            var symbol = Console.ReadLine();
            model.Ticker = symbol;
            await execTask.YahooMajorHoldersBreakdown(model);
        }
    }

    internal class YahooRecommendationTrendRequest : IMenu
    {
        public string Description => "Get Yahoo Company Recommendation Trend! (Data will be returned in Json format)!";
        public async Task Execute(ApiRequest.ApiRequest execTask, RequestModel model)
        {
            Console.WriteLine("Please enter the symbol!");
            var symbol = Console.ReadLine();
            model.Ticker = symbol;
            await execTask.YahooRecommendationTrend(model);
        }
    }

    internal class YahooUpgradeDowngradeHistoryRequest : IMenu
    {
        public string Description => "Get Yahoo Company Upgrade Downgrade History! (Data will be returned in Json format)!";
        public async Task Execute(ApiRequest.ApiRequest execTask, RequestModel model)
        {
            Console.WriteLine("Please enter the symbol!");
            var symbol = Console.ReadLine();
            model.Ticker = symbol;
            await execTask.YahooUpgradeDowngradeHistory(model);
        }
    }

    internal class YahooInstitutionOwnershipRequest : IMenu
    {
        public string Description => "Get Yahoo Company Institution Ownership! (Data will be returned in Json format)!";
        public async Task Execute(ApiRequest.ApiRequest execTask, RequestModel model)
        {
            Console.WriteLine("Please enter the symbol!");
            var symbol = Console.ReadLine();
            model.Ticker = symbol;
            await execTask.YahooInstitutionOwnership(model);
        }
    }

    internal class YahooFinancialDataRequest : IMenu
    {
        public string Description => "Get Yahoo Company Financial Data! (Data will be returned in Json format)!";
        public async Task Execute(ApiRequest.ApiRequest execTask, RequestModel model)
        {
            Console.WriteLine("Please enter the symbol!");
            var symbol = Console.ReadLine();
            model.Ticker = symbol;
            await execTask.YahooFinancialData(model);
        }
    }
    internal class YahooMajorDirectHoldersRequest : IMenu
    {
        public string Description => "Get Yahoo Company Major Direct Holders! (Data will be returned in Json format)!";
        public async Task Execute(ApiRequest.ApiRequest execTask, RequestModel model)
        {
            Console.WriteLine("Please enter the symbol!");
            var symbol = Console.ReadLine();
            model.Ticker = symbol;
            await execTask.YahooMajorDirectHolders(model);
        }
    }

    internal class YahooFundOwnershipRequest : IMenu
    {
        public string Description => "Get Yahoo Company Fund Ownership! (Data will be returned in Json format)!";
        public async Task Execute(ApiRequest.ApiRequest execTask, RequestModel model)
        {
            Console.WriteLine("Please enter the symbol!");
            var symbol = Console.ReadLine();
            model.Ticker = symbol;
            await execTask.YahooFundOwnership(model);
        }
    }

    internal class YahooInsiderTransactionsRequest : IMenu
    {
        public string Description => "Get Yahoo Company Insider Transactions! (Data will be returned in Json format)!";
        public async Task Execute(ApiRequest.ApiRequest execTask, RequestModel model)
        {
            Console.WriteLine("Please enter the symbol!");
            var symbol = Console.ReadLine();
            model.Ticker = symbol;
            await execTask.YahooInsiderTransactions(model);
        }
    }

    internal class YahooInsiderHoldersRequest : IMenu
    {
        public string Description => "Get Yahoo Company Insider Holders! (Data will be returned in Json format)!";
        public async Task Execute(ApiRequest.ApiRequest execTask, RequestModel model)
        {
            Console.WriteLine("Please enter the symbol!");
            var symbol = Console.ReadLine();
            model.Ticker = symbol;
            await execTask.YahooInsiderHolders(model);
        }
    }

    internal class YahooBalanceSheetHistoryRequest : IMenu
    {
        public string Description => "Get Yahoo Company Balance Sheet History! (Data will be returned in Json format)!";
        public async Task Execute(ApiRequest.ApiRequest execTask, RequestModel model)
        {
            Console.WriteLine("Please enter the symbol!");
            var symbol = Console.ReadLine();
            model.Ticker = symbol;
            await execTask.YahooBalanceSheetHistory(model);
        }
    }
}
