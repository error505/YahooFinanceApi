using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockExchangeYahooFinance.ConfigData;
using StockExchangeYahooFinance.Helpers;
using StockExchangeYahooFinance.Repository;

namespace StockExchangeYahooFinance.Services.ApiRequest.YahooFinanceApiModules
{
    public class YahooFinanceApiModulesRequest
    {
        private readonly StockExchangeRepository _repository;
        //Initialize ConfigManager
        private static readonly ConfigManager Cfg = new ConfigManager();
        //Initialize YqlQuery
        private static readonly YqlQuery Yq = new YqlQuery();
        //Initialize FinanceData
        private static readonly FinanceData FinanceData = new FinanceData();
        private readonly CallWebRequest _callWebRequest = new CallWebRequest();
        private static readonly YahooCompProfile YahooCompProfile = new YahooCompProfile();
        private static readonly YahooRssFeed YahooRssFeed = new YahooRssFeed();

        public YahooFinanceApiModulesRequest(StockExchangeRepository repository)
        {
            //Get repository
            _repository = repository;
        }
    }
}
