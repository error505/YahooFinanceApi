using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Services
{
    public interface IMenu
    {
        string Description { get; }
        Task Execute(ApiRequest requests);
    }
}
