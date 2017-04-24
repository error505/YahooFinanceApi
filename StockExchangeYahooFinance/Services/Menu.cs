using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Services
{

    internal class YahooCompanies : IMenu
    {
        public string Description => "Add a list of yahoo companies to database.";
        public async Task Execute(ApiRequest execTask)
        {
            await execTask.YahooCompanies();
        }
    }

    internal class StockExchangeForCompanies : IMenu
    {
        public string Description => "Import List of yahoo exchanges from XML file.";
        public async Task Execute(ApiRequest execTask)
        {
            await execTask.YahooExchanges();
        }
    }

    internal class CurrenciesExchange : IMenu
    {
        public string Description => "Show Currency Exchange.";
        public async Task Execute(ApiRequest execTask)
        {
            var cancellation = new CancellationTokenSource(Timeout.Infinite);
            await execTask.XchangeTask(TimeSpan.FromSeconds(5), cancellation.Token);
        }
    }
    internal class ImportCompaniesNasdaq : IMenu
    {
        public string Description => "Import list of the companies into the database from NASDAQ!";
        public async Task Execute(ApiRequest execTask)
        {
            var cancellation = new CancellationTokenSource(Timeout.Infinite);
            await execTask.ImportCompanies(TimeSpan.FromSeconds(7), cancellation.Token);
        }
    }

    internal class ImportCurrenciesTask : IMenu
    {
        public string Description => "Import the list of the Currencies from ISO Currencies web site.";
        public async Task Execute(ApiRequest execTask)
        {
            await execTask.ImportCurrencies();
        }
    }

    internal class StockExchangeJson : IMenu
    {
        public string Description => "Check for stock market for the list of selected tickers (Data will be returned in JSON format)!";
        public async Task Execute(ApiRequest execTask)
        {
            var cancellation = new CancellationTokenSource(Timeout.Infinite);
            await execTask.StockExchangeTask(TimeSpan.FromMilliseconds(900), cancellation.Token);
        }
    }

    internal class StockExchangeTaskParseCsv : IMenu
    {
        public string Description => "Check for stock market for the list of selected tickers (Data will be returned in CSV format)!";
        public async Task Execute(ApiRequest execTask)
        {
            var cancellation = new CancellationTokenSource(Timeout.Infinite);
            await execTask.StockExchangeParseCsv();
        }
    }
}
