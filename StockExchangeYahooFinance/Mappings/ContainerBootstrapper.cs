using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using StockExchangeYahooFinance.Services;

namespace StockExchangeYahooFinance.Mappings
{
    public class ContainerBootstrapper
    {
        public static void RegisterTypes(IUnityContainer container)
        {           
            container.RegisterType<IApiRequest, ApiRequest>("WebRequest");
        }
    }
}
