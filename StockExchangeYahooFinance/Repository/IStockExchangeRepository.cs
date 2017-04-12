using System.Collections.Generic;
using System.Threading.Tasks;
using StockExchangeYahooFinance.Data;

namespace StockExchangeYahooFinance.Repository
{
    public interface IStockExchangeRepository
    {
        IEnumerable<FinanceModel> GetAllFinances();

        Task<FinanceModel> AddFinanceModel(FinanceModel financeModel);
    }
}
