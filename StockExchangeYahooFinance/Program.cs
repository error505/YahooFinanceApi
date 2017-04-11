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
        private const string CsvUrl = "http://finance.yahoo.com/d/quotes.csv?s=";
        private const string DataTableEnv = "&env=store://datatables.org/alltableswithkeys&callback=";
        private const string Format = "&format=json";
        private const string FinanceQueryUrl = "https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.quotes%20where%20symbol%20in%20";
        private const string CsvData = "snbaopl1c1d1cm6";
        private const string Curencies =
            "%22EURBAM%22,%20%22USDJPY%22,%20%22USDBGN%22,%20%22USDCZK%22,%20%22USDDKK%22,%20%22USDGBP%22,%20%22USDHUF%22,%20%22USDLTL%22,%20%22USDLVL%22,%20%22USDPLN%22,%20%22USDRON%22,%20%22USDSEK%22,%20%22USDCHF%22,%20%22USDNOK%22,%20%22USDHRK%22,%20%22USDRUB%22,%20%22USDTRY%22,%20%22USDAUD%22,%20%22USDBRL%22,%20%22USDCAD%22,%20%22USDCNY%22,%20%22USDHKD%22,%20%22USDIDR%22,%20%22USDILS%22,%20%22USDINR%22,%20%22USDKRW%22,%20%22USDMXN%22,%20%22USDMYR%22,%20%22USDNZD%22,%20%22USDPHP%22,%20%22USDSGD%22,%20%22USDTHB%22,%20%22USDZAR%22,%20%22USDISK%22";
        private const string XchangeUrl = "http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.xchange%20where%20pair%20in%20";

        //All other API Usage only for future needs
        //private const string smallQuery =
        //    "https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20csv%20where%20url%3D%27http%3A%2F%2Fdownload.finance.yahoo.com%2Fd%2Fquotes.csv%3Fs%3DACA.PA%26f%3Dsl1d1t1c1ohgv%26e%3D.csv%27%20and%20columns%3D%27symbol%2Cprice%2Cdate%2Ctime%2Cchange%2Ccol1%2Chigh%2Clow%2Ccol2%27&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";
        //private const string ecb = "http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";
        //private const string curencyAllUSD =
        //    "http://finance.yahoo.com/webservice/v1/symbols/allcurrencies/quote?format=json";
        public static IConfigurationRoot Configuration { get; set; }

        private static void Main()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json");
            builder.Build();
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
            var financeUrl = FinanceQueryUrl + $"(%22{Tickers}%22)" + Format + DataTableEnv;
            var commoditiesUrl = FinanceQueryUrl + $"(%22{Commodities}%22)" + Format + DataTableEnv;
            var csvUrl = CsvUrl + $"{Tickers}&f={CsvData}";
            var xChangeUrl = XchangeUrl+ $"({Curencies})" + Format + DataTableEnv;
            //For JSON data for Companies
            request.StockExchangeTask(TimeSpan.FromMilliseconds(900), cancellation.Token, financeUrl).Wait(cancellation.Token);
            //For JSON data for Commodities
            //request.RepeatActionEvery(TimeSpan.FromMilliseconds(900), cancellation.Token, commoditiesUrl).Wait(cancellation.Token);
            //For currency x change
            //request.XchangeTask(TimeSpan.FromSeconds(5), cancellation.Token, xChangeUrl).Wait(cancellation.Token);
            //If you want to use CSV Parsing use this method
            //request.StockExchangeParseCsv(csvUrl);
        }
    }
}
