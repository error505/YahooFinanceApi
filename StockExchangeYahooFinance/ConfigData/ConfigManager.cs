//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace StockExchangeYahooFinance.ConfigData
//{

//    /// <summary>
//    /// Configuration for getting parameters from App.config file
//    /// </summary>
//    internal class ConfigManager
//    {
//        private static IConfigurationRoot Configuration { get; set; }
//        private const string FinanceUrl = "financeQueryUrl";
//        private const string CurrencyUrl = "xchangeUrl";
//        private const string DataTableEnv = "dataTableEnv";
//        private const string Csv = "csvUrl";
//        private const string FormatJ = "formatJson";

//        public string FinanceQueryUrl => GetConfigKey(FinanceUrl);

//        public string XchangeUrl => GetConfigKey(CurrencyUrl);

//        public string Enviroment => GetConfigKey(DataTableEnv);

//        public string CsvUrl => GetConfigKey(Csv);

//        public string FormatJson => GetConfigKey(FormatJ);

//        private string GetConfigKey(string name)
//        {
//            var builder = new ConfigurationBuilder()
//              .SetBasePath(Directory.GetCurrentDirectory())
//             .AddJsonFile("appsettings.json");
//            Configuration = builder.Build();
//            return Configuration.GetSection("ConfigData")[name];
//        }
//    }
//}