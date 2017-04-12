using System.Collections.Generic;
using System.Threading.Tasks;
using StockExchangeYahooFinance.Data;
using StockExchangeYahooFinance.Data.Models;

namespace StockExchangeYahooFinance.Repository
{
    public interface IStockExchangeRepository
    {
        IEnumerable<FinanceModel> GetAllFinances();

        Task<FinanceModel> AddFinanceModel(FinanceModel financeModel);

        Task<string> AddIndustry(Industry industry);

        Task<string> AddSector(Sector sector);

        Task<string> AddRegion(Region region);

        Task<Industry> GetIndustryByName(string name);

        Task<Region> GetRegionByName(string name);

        Task<Sector> GetSectorByName(string name);

        Task<Companies> GetCompanyByName(string symbol);
    }
}
