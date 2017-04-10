using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading;
using Microsoft.Practices.Unity;
using StockExchangeYahooFinance.ConfigData;
using StockExchangeYahooFinance.Mappings;
using StockExchangeYahooFinance.Services;

namespace StockExchangeYahooFinance
{
    internal class Program
    {
        private static readonly XmlObjectSerializer Serializer = new DataContractJsonSerializer(typeof(FinanceData));
        private const string Tickers = "AAPL,GOOG,GOOGL,YHOO,TSLA,INTC,AMZN,BIDU,ORCL,MSFT,ORCL,ATVI,NVDA,LNKD,NFLX,A,AZZ,SHLM,ADES,PIH,SAFT,SANM,SASR,FLWS,FCCY,SRCE,VNET";
        private const string Commodities = "GC=F,ZG=F,SI=F,ZI=F,PL=F,HG=F,PA=F,CL=F,HO=F,NG=F,RB=F,BZ=F,B0=F,C=F,O=F,KW=F,RR=F,SM=F,BO=F,S=F,FC=F,LH=F,LC=F,CC=F,KC=F,CT=F,LB=F,OJ=F,SB=F";

        private static void Main()
        {
            Run();
        }

        private static void Run()
        {
            var container = new UnityContainer();
            ContainerBootstrapper.RegisterTypes(container);
            var request = container.Resolve<ApiRequest>();
            var cancellation = new CancellationTokenSource(Timeout.Infinite);
            request.RepeatActionEvery(TimeSpan.FromMilliseconds(900), cancellation.Token, Tickers).Wait(cancellation.Token);
            //request.ParseCsv(); //If you want to use CSV Parsing use this method
        }
    }
}
