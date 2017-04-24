using System;
using System.IO;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Practices.Unity;
using StockExchangeYahooFinance.Mappings;
using StockExchangeYahooFinance.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StockExchangeYahooFinance.ConfigData;
using StockExchangeYahooFinance.DbContext;
using StockExchangeYahooFinance.Repository;

namespace StockExchangeYahooFinance
{
    internal class Program
    {
        private static IConfigurationRoot Configuration { get; set; }
        private static IServiceProvider ServiceProvider { get; set; }
        private static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           .AddEnvironmentVariables();
            Configuration = builder.Build();

            var contextOptions = new DbContextOptionsBuilder()
            .UseSqlServer(Configuration.GetConnectionString("YFConnection"))
            .Options;

            IServiceCollection services = new ServiceCollection()
                .AddDbContext<YahooFinanceDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("YFConnection")))
            .AddSingleton(contextOptions)
            .AddScoped<YahooFinanceDbContext>();
            ServiceProvider = services.BuildServiceProvider();

            Run();
        }
        //Will Be needed later when transform to web app
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<YahooFinanceDbContext>(options =>
                     options.UseSqlServer(Configuration.GetConnectionString("YFConnection")))
                .AddSingleton<IConfiguration>(Configuration)
                .AddLogging()
                .AddScoped<IApiRequest, ApiRequest>()
                .AddScoped<IStockExchangeRepository, StockExchangeRepository>()
                .BuildServiceProvider();
            services.AddTransient<ApiRequest>();
            services.AddTransient<StockExchangeRepository>();
            var loggerFactory = new LoggerFactory();
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
