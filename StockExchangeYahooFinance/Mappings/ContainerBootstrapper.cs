using Microsoft.Practices.Unity;
using StockExchangeYahooFinance.Repository;
using StockExchangeYahooFinance.Services.ApiRequest;

namespace StockExchangeYahooFinance.Mappings
{
    public class ContainerBootstrapper
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IApiRequest, ApiRequest>("WebRequest");

            container.RegisterType<IStockExchangeRepository, StockExchangeRepository>("Repository");
        }
    }
}
