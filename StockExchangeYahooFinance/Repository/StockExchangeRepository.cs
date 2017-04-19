using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockExchangeYahooFinance.Data;
using StockExchangeYahooFinance.Data.Models;
using StockExchangeYahooFinance.DbContext;

namespace StockExchangeYahooFinance.Repository
{
    public class StockExchangeRepository : IStockExchangeRepository
    {
        private readonly YahooFinanceDbContext _context;

        public StockExchangeRepository(YahooFinanceDbContext context)
        {
            _context = context;
        }
        public IEnumerable<FinanceModel> GetAllFinances()
        {
            return _context.FinanceModel.ToList();
        }

        public async Task<Industry> GetIndustryByName(string name)
        {
            var industry =
                await _context.Industrie
                    .SingleOrDefaultAsync(m => m.Name == name);
            return industry;
        }

        public async Task<Country> GetCountryByName(string name)
        {
            var country =
                await _context.Country
                    .SingleOrDefaultAsync(m => m.Name == name);
            return country;
        }

        public async Task<Region> GetRegionByName(string name)
        {
            var region =
                await _context.Region
                    .SingleAsync(m => m.Name == name);
            return region;
        }

        public async Task<Sector> GetSectorByName(string name)
        {
            var sector =
                await _context.Sector
                    .SingleOrDefaultAsync(m => m.Name == name);
            return sector;
        }

        public async Task<Companies> GetCompanyByName(string symbol)
        {
            var company =
                await _context.Companies
                    .SingleOrDefaultAsync(m => m.Symbol == symbol);
            return company;
        }

        public async Task<Exchange> GetExchangeByName(string symbol)
        {
            var exchange =
                await _context.Exchange
                    .SingleOrDefaultAsync(m => m.StockExchangeId == symbol);
            return exchange;
        }

        public async Task<Currencies> GetCurrencyByCode(string code)
        {
            var currency =
                await _context.Currencies
                    .SingleOrDefaultAsync(m => m.Code == code);
            return currency;
        }
        public async Task<FinanceModel> AddFinanceModel(FinanceModel financeModel)
        {
            if (financeModel == null)
            {
                return null;
            }
            _context.FinanceModel.Add(financeModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (IdExists(financeModel.Id))
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }
            }
            return null;
        }

        public async Task<string> AddIndustry(Industry industry)
        {
            if (industry == null)
            {
                return null;
            }
            if (IndustryIdExists(industry.Name))
            {
                var ind = await GetIndustryByName(industry.Name);
                return ind.Id;
            }
            _context.Industrie.Add(industry);
            try
            {

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (IndustryIdExists(industry.Name))
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }

            }
            return industry.Id;
        }

        public async Task<string> AddCountry(Country country)
        {
            if (country == null)
            {
                return null;
            }
            if (CountryIdExists(country.Name))
            {
                var ind = await GetCountryByName(country.Name);
                return ind.Id;
            }
            _context.Country.Add(country);
            try
            {

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (CountryIdExists(country.Name))
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }

            }
            return country.Id;
        }

        public async Task<string> AddSector(Sector sector)
        {
            if (sector == null)
            {
                return null;
            }
            if (SectorIdExists(sector.Name))
            {
                var sec = await GetSectorByName(sector.Name);
                return sec.Id;
            }
            _context.Sector.Add(sector);
            try
            {

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (SectorIdExists(sector.Name))
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }
            }
            return sector.Id;
        }

        public async Task<string> AddRegion(Region region)
        {
            if (region == null)
            {
                return null;
            }
            if (RegionIdExists(region.Name))
            {
                var reg = await GetRegionByName(region.Name);
                return reg.Id;
            }
            _context.Region.Add(region);
            try
            {

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (RegionIdExists(region.Name))
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }
            }
            return region.Id;
        }

        public async Task<string> AddCompany(Companies companies)
        {
            if (companies == null)
            {
                return null;
            }
            if (CompIdExists(companies.Symbol))
            {
                var comp = await GetCompanyByName(companies.Symbol);
                return comp.Id;
            }
            _context.Companies.Add(companies);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (CompIdExists(companies.Symbol))
                {
                   Console.WriteLine(ex.Message);
                   Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }
            }
            return companies.Id;
        }

        public async Task<string> AddExchange(Exchange exchange)
        {
            if (exchange == null)
            {
                return null;
            }
            if (ExchangeIdExists(exchange.StockExchangeId))
            {
                var comp = await GetExchangeByName(exchange.StockExchangeId);
                return comp.Id;
            }
            _context.Exchange.Add(exchange);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (ExchangeIdExists(exchange.StockExchangeId))
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }
            }
            return exchange.Id;
        }

        public async Task<string> AddCurrency(Currencies currencies)
        {
            if (currencies == null)
            {
                return null;
            }
            if (CurrencyExists(currencies.Code))
            {
                var currency = await GetCurrencyByCode(currencies.Code);
                return currency.Id;
            }
            _context.Currencies.Add(currencies);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (CurrencyExists(currencies.Code))
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }
            }
            return currencies.Id;
        }

        public bool IdExists(string id)
        {
            return _context.FinanceModel.Any(e => e.Id == id);
        }

        public bool CompIdExists(string symbol)
        {
            return _context.Companies.Any(e => e.Symbol == symbol);
        }

        public bool ExchangeIdExists(string symbol)
        {
            return _context.Exchange.Any(e => e.StockExchangeId == symbol);
        }

        public bool IndustryIdExists(string name)
        {
            return _context.Industrie.Any(e => e.Name == name);
        }

        public bool CountryIdExists(string name)
        {
            return _context.Country.Any(e => e.Name == name);
        }

        public bool RegionIdExists(string name)
        {
            return _context.Region.Any(e => e.Name == name);
        }

        public bool SectorIdExists(string name)
        {
            return _context.Sector.Any(e => e.Name == name);
        }

        public bool CurrencyExists(string code)
        {
            return _context.Currencies.Any(e => e.Code == code);
        }
    }
}
