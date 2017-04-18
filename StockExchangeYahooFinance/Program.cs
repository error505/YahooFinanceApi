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

namespace StockExchangeYahooFinance
{
    internal class Program
    {
        private const string Tickers = "AAPL,GOOG,GOOGL,YHOO,TSLA,INTC,AMZN,BIDU,ORCL,MSFT,ORCL,ATVI,NVDA,LNKD,NFLX,A,AZZ,SHLM,ADES,PIH,SAFT,SANM,SASR,FLWS,FCCY,SRCE,VNET";
        private const string Commodities = "GC=F,ZG=F,SI=F,ZI=F,PL=F,HG=F,PA=F,CL=F,HO=F,NG=F,RB=F,BZ=F,B0=F,C=F,O=F,KW=F,RR=F,SM=F,BO=F,S=F,FC=F,LH=F,LC=F,CC=F,KC=F,CT=F,LB=F,OJ=F,SB=F";
        private const string CsvData = "snbaopl1c1d1cm6";

        private const string allComp = "http://finance.yahoo.com/lookup/all?";
        private const string Curencies =
            "%22EURBAM%22,%20%22USDJPY%22,%20%22USDBGN%22,%20%22USDCZK%22,%20%22USDDKK%22,%20%22USDGBP%22,%20%22USDHUF%22,%20%22USDLTL%22,%20%22USDLVL%22,%20%22USDPLN%22,%20%22USDRON%22,%20%22USDSEK%22,%20%22USDCHF%22,%20%22USDNOK%22,%20%22USDHRK%22,%20%22USDRUB%22,%20%22USDTRY%22,%20%22USDAUD%22,%20%22USDBRL%22,%20%22USDCAD%22,%20%22USDCNY%22,%20%22USDHKD%22,%20%22USDIDR%22,%20%22USDILS%22,%20%22USDINR%22,%20%22USDKRW%22,%20%22USDMXN%22,%20%22USDMYR%22,%20%22USDNZD%22,%20%22USDPHP%22,%20%22USDSGD%22,%20%22USDTHB%22,%20%22USDZAR%22,%20%22USDISK%22";

        private static IConfigurationRoot Configuration { get; set; }

        private static void Main()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            Run();
        }

        //Will Be needed later when transform to web app
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<YahooFinanceDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("YFConnection")));
        }

        private static void Run()
        {
            var container = new UnityContainer();
            ContainerBootstrapper.RegisterTypes(container);
            var request = container.Resolve<ApiRequest>();
            var cancellation = new CancellationTokenSource(Timeout.Infinite);
            var cancellation2 = new CancellationTokenSource(9);
            var financeQueryUrl = Configuration["Urls:FinanceQueryUrl"];
            var financeUrl = Configuration["Urls:FinanceQueryUrl"] + $"(%22{Tickers}%22)" + Configuration["Urls:Format"] + Configuration["Urls:Enviroment"];
            var commoditiesUrl = Configuration["Urls:FinanceQueryUrl"] + $"(%22{Commodities}%22)" + Configuration["Urls:Format"] + Configuration["Urls:Enviroment"];
            var csvUrl = Configuration["Urls:CsvUrl"] + $"{Tickers}&f={CsvData}";
            var xChangeUrl = Configuration["Urls:XchangeUrl"] + $"({Curencies})" + Configuration["Urls:Format"] + Configuration["Urls:Enviroment"];
            //For JSON data for Companies
            //request.StockExchangeTask(TimeSpan.FromMilliseconds(900), cancellation.Token, financeUrl).Wait(cancellation.Token);
            //request.ImportCurrencies(Configuration["Urls:CurrencyUrl"]).Wait(cancellation.Token);
            //request.ImportCompanies(TimeSpan.FromSeconds(7), cancellation.Token, Configuration["Urls:CompaniesCSV"] + Configuration["Urls:CompaniesCSVRegion"] + Configuration["Urls:ComaniesCSVDownload"], Configuration["Urls:CompaniesRegion"]).Wait(cancellation.Token);
            request.YahooCompanies(allComp).Wait(cancellation.Token);
            //For JSON data for Commodities
            //request.RepeatActionEvery(TimeSpan.FromMilliseconds(900), cancellation.Token, commoditiesUrl).Wait(cancellation.Token);
            //For currency x change
            //request.XchangeTask(TimeSpan.FromSeconds(5), cancellation.Token, xChangeUrl).Wait(cancellation.Token);
            //If you want to use CSV Parsing use this method
            //request.StockExchangeParseCsv(csvUrl);
        }
    }
}
