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
        private static string YahooQuotes = "YahooQuotes";
        private static string YahooXchange = "YahooXchange";
        private static string YahooLookupAll = "YahooLookupAll";
        private static string YahooFormat = "Format";
        private static string Diagnostic = "Diagnostic;";
        private static string YahooEnviroment = "Enviroment";
        private static string YahooCallBack = "CallBack";
        private static string Tickers = "Tickers";
        private static string Curencies = "Curencies";
        private static string NasdqCompanies = "NasdqCompanies";
        private static string NasdqRegion = "NasdqRegion";
        private static string NasdqRegionNormal = "NasdqRegionNormal";
        private static string NasdqRender = "NasdqRender";
        private static string IsoCurrencyUrl = "IsoCurrencyUrl";
        private const string Select = "select ";
        private const string From = " from";
        private const string SelectAll = "select * from ";
        private const string WhereSimbol = " where symbol ";
        private const string WherePair = " where pair ";
        private const string In = "in ";

        public string YahooBaseUrl => GetConfigKey(YahooBase);

        public string YahooXchangeUrl => GetConfigKey(YahooXchange);

        public string Enviroment => GetConfigKey(YahooEnviroment);
        public string CallBack => GetConfigKey(YahooCallBack);

        //public string CsvUrl => GetConfigKey(Csv);

        public string Format => GetConfigKey(YahooFormat);

        private string GetConfigKey(string name)
        {
            return Configuration.GetSection("Urls")[name];
        }

        public ConfigManager()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }
    }
}