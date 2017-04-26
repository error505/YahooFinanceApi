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
        private static string YahooHistoricalUrl = "YahooHistoricalData";
        private static string YahooXchangeUrl = "YahooXchange";
        private static string YahooLookup = "AllComp";
        private static string YahooFormat = "Format";
        private static string YahooDiagnostic = "Diagnostic;";
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
        public string YahooBaseUrl => GetConfigKey(YahooBase);
        public string YahooXchange => GetConfigKey(YahooXchangeUrl);
        public string YahooQuotes => GetConfigKey(YahooQuotesUrl);
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
        public string CsvUrl => GetConfigKey(Csv);
        public string CsvData => GetConfigKey(CsvDataConf);
        public string YahooDbConnectioString => DbConf(GetYahooDbConnection);
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
    }
}