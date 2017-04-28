using System.Threading.Tasks;
using StockExchangeYahooFinance.Models;

namespace StockExchangeYahooFinance.Services.Menu
{
    public interface IMenu
    {
        string Description { get; }
        Task Execute(ApiRequest.ApiRequest requests, RequestModel model);
    }
}
