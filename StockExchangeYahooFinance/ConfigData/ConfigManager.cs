using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.ConfigData
{
    /// <summary>
    /// Configuration for getting parameters from App.config file
    /// </summary>
    internal class ConfigManager
    {
        private static IConfigurationRoot Configuration { get; set; }
        private static string YahooBase = "YahooBaseUrl";
        private static string YahooQuotesUrl = "YahooQuotes";
        private static string YahooQuoteSummaryUrl = "YahooQuoteSummary";
        private static string YahooHistoricalUrl = "YahooHistoricalData";
        private static string YahooXchangeUrl = "YahooXchange";
        private static string YahooLookup = "AllComp";
        private static string YahooFormat = "Format";
        private static string YahooFormated = "Formated";
        private static string YahooCrumb = "Crumb";
        private static string YahooLang = "Lang";
        private static string YahooDiagnostic = "Diagnostic";
        private static string YahooRegion = "YahooRegion";
        private static string YahooModulesUrl = "Modules";
        private static string YahooCorsDomain = "CorsDomain";
        private static string YahooEnviroment = "Enviroment";
        private static string YahooCallBack = "CallBack";
        private static string TickersList = "Tickers";
        private static string Symbol = "SymbolTicker";
        private static string CurenciesConf = "Curencies";
        private static string NasdqCompaniesConf = "NASDQCompaniesCSV";
        private static string NasdqCompRegionCsv = "NASDQCompaniesCSVRegion";
        private static string NasdqRegionNormal = "NASDQRegion";
        private static string NasdqRenderPart = "NASDQRender";
        private static string IsoCurrency = "IsoCurrencyUrl";
        private static string Csv = "CsvUrl";
        private static string CsvDataConf = "CsvData";
        private static string GetYahooDbConnection = "YFConnection";
        private static string YahooHistoryAllCsv = "YahooHistoryAll";
        private static string User = "UserName";
        private static string YahooRss = "YahooRssFeed";
        public string YahooBaseUrl => GetConfigKey(YahooBase);
        public string YahooXchange => GetConfigKey(YahooXchangeUrl);
        public string YahooQuotes => GetConfigKey(YahooQuotesUrl);
        public string YahooQuoteSummary => GetConfigKey(YahooQuoteSummaryUrl);
        public string YahooLookupAll => GetConfigKey(YahooLookup);
        public string IsoCurrencyUrl => GetConfigKey(IsoCurrency);
        public string NasdqRender => GetConfigKey(NasdqRenderPart);
        public string NasdqRegion => GetConfigKey(NasdqRegionNormal);
        public string NasdqRegionCsv => GetConfigKey(NasdqCompRegionCsv);
        public string NasdqCompanies => GetConfigKey(NasdqCompaniesConf);
        public string Curencies => GetConfigKey(CurenciesConf);
        public string Tickers => GetConfigKey(TickersList);
        public string SymbolTicker => GetConfigKey(Symbol);
        public string Enviroment => GetConfigKey(YahooEnviroment);
        public string YahooHistoricalData => GetConfigKey(YahooHistoricalUrl);
        public string Diagnostic => GetConfigKey(YahooDiagnostic);
        public string CallBack => GetConfigKey(YahooCallBack);
        public string Format => GetConfigKey(YahooFormat);
        public string YFormated => GetConfigKey(YahooFormated);
        public string YCrumb => GetConfigKey(YahooCrumb);
        public string YLang => GetConfigKey(YahooLang);
        public string YRegion => GetConfigKey(YahooRegion);
        public string YModules => GetConfigKey(YahooModulesUrl);
        public string YCorsDomain => GetConfigKey(YahooCorsDomain);
        public string CsvUrl => GetConfigKey(Csv);
        public string CsvData => GetConfigKey(CsvDataConf);
        public string YahooHistoryCsv => GetConfigKey(YahooHistoryAllCsv);
        public string YahooRssUrl => GetConfigKey(YahooRss);
        public string YahooDbConnectioString => DbConf(GetYahooDbConnection);
        public string UserName => Credentials(User);
        public ConfigManager()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }
        //Get URL Parameters from configuration file
        private string GetConfigKey(string name)
        {
            return Configuration.GetSection("Urls")[name];
        }
        //Get ConnectionStrings from configuration file
        private string DbConf(string name)
        {
          return  Configuration.GetSection("ConnectionStrings")[name];
        }
        private string Credentials(string name)
        {
            return Configuration.GetSection("Credentials")[name];
        }
    }
}