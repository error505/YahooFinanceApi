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

        Task<string> AddCompany(Companies companies);

        Task<string> AddSector(Sector sector);

        Task<string> AddRegion(Region region);

        Task<string> AddCurrency(Currencies currencies);

        Task<string> AddCountry(Country country);

        Task<string> AddExchange(Exchange exchange);

        Task<Industry> GetIndustryByName(string name);

        Task<Region> GetRegionByName(string name);

        Task<Sector> GetSectorByName(string name);

        Task<Companies> GetCompanyByName(string symbol);

        Task<Currencies> GetCurrencyByCode(string code);

        Task<Exchange> GetExchangeByName(string symbol);

        Task<Country> GetCountryByName(string name);

        bool ExchangeIdExists(string symbol);

        bool IdExists(string id);

        bool CompIdExists(string symbol);

        bool IndustryIdExists(string name);
        bool CountryIdExists(string name);

        bool RegionIdExists(string name);

        bool SectorIdExists(string name);

        bool CurrencyExists(string code);
    }
}
