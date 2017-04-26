using System;
using Microsoft.Practices.Unity;
using StockExchangeYahooFinance.Mappings;
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
            var menu = new IMenu[]
            {
                new YahooCompanies(),
                new StockExchangeForCompanies(),
                new CurrenciesExchange(),
                new ImportCurrenciesTask(),
                new ImportCompaniesNasdaq(),
                new StockExchangeJson(),
                new StockExchangeTaskParseCsv(),
            };

            var container = new UnityContainer();
            ContainerBootstrapper.RegisterTypes(container);
            var request = container.Resolve<ApiRequest>();

            while (true)
            {
                Console.WriteLine("Welcome to YahooFinanceApi.");
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
                menu[commandIndex - 1].Execute(request);
            }
        }
    }
}
