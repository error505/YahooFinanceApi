using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Services.Menu
{
    public interface IMenu
    {
        string Description { get; }
        Task Execute(ApiRequest.ApiRequest requests);
    }
}
