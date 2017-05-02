using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        /// <summary>
        /// List of all finances
        /// </summary>
        /// <returns>List</returns>
        public IEnumerable<FinanceModel> GetAllFinances()
        {
            return _context.FinanceModel.ToList();
        }
        /// <summary>
        /// Get list of all companies
        /// </summary>
        /// <returns>List</returns>
        public IEnumerable<Companies> GetAllCompanies()
        {
            try
            {
                return _context.Companies.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        /// <summary>
        /// List of all histories
        /// </summary>
        /// <returns>List</returns>
        public IEnumerable<History> GetAllHistories()
        {
            return _context.History.ToList();
        }
        /// <summary>
        /// Check for Industry in DB by its name
        /// </summary> HisotryIdExists
        /// <param name="name"></param>
        /// <returns>Industry</returns>
        public async Task<Industry> GetIndustryByName(string name)
        {
            try
            {
                var industry =
                await _context.Industrie
                    .SingleOrDefaultAsync(m => m.Name == name);
                return industry;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<CompanyProfile> GetCompanyProfileByName(string name)
        {
            try
            {
                var company = await GetCompanyByName(name);
                var companyProfile =
                await _context.CompanyProfile
                    .SingleOrDefaultAsync(m => m.CompaniesId == company.Id);
                return companyProfile;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<CompanyProfile> GetCompanyProfileById(string id)
        {
            try
            {
                var companyProfile =
                await _context.CompanyProfile
                    .SingleOrDefaultAsync(m => m.Id == id);
                return companyProfile;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<CompanyOfficers> GetCompanyOfficersByName(string name)
        {
            try
            {
                var company = await GetCompanyByName(name);
                var companyOfficers =
                await _context.CompanyOfficers
                    .SingleOrDefaultAsync(m => m.CompaniesId == company.Id);
                return companyOfficers;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<CompanyOfficers> GetCompanyOfficersById(string id)
        {
            try
            {
                var companyOfficers =
                await _context.CompanyOfficers
                    .SingleOrDefaultAsync(m => m.Id == id);
                return companyOfficers;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        /// <summary>
        /// Find industry by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Industry</returns>
        public async Task<Industry> GetIndustryById(string id)
        {
            var industry =
                await _context.Industrie
                    .SingleOrDefaultAsync(m => m.Id == id);
            return industry;
        }
        /// <summary>
        /// Get history list for selected company by start-date and end-date
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="symbol"></param>
        /// <returns>List</returns>
        public async Task<List<History>> GetHistoryByStartEndDate(string startDate, string endDate, string symbol)
        {
            try
            {
                var company = await GetCompanyByName(symbol);
                var history =
                 _context.History
                    .Where(m => (m.Date == startDate) && (m.Date == endDate) && (m.CompaniesId == company.Id)).ToList();
                return history;
            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="date"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<History> GetHistoryByDate(string date, string id)
        {
            try
            {
                var company = await GetCompanyById(id);
                var history =
                await _context.History
                    .SingleOrDefaultAsync(m => (m.Date == date) && (m.CompaniesId == company.Id));
                return history;
            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        /// <summary>
        /// Check for Country in DB by its name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Country</returns>
        public async Task<Country> GetCountryByName(string name)
        {
            var country =
                await _context.Country
                    .SingleOrDefaultAsync(m => m.Name == name);
            return country;
        }
        /// <summary>
        /// Check for Region in DB by its name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Region</returns>
        public async Task<Region> GetRegionByName(string name)
        {
            var region =
                await _context.Region
                    .SingleAsync(m => m.Name == name);
            return region;
        }
        /// <summary>
        /// Get Region By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Region</returns>
        public async Task<Region> GetRegionById(string id)
        {
            var region =
                await _context.Region
                    .SingleAsync(m => m.Id == id);
            return region;
        }
        /// <summary>
        /// Check for Sector in DB by its name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Sector model</returns>
        public async Task<Sector> GetSectorByName(string name)
        {
            var sector =
                await _context.Sector
                    .SingleOrDefaultAsync(m => m.Name == name);
            if (sector == null)
            {
                var sec = new Sector { Name = name };
                var sectorAdded = await AddSector(sec);
                return sec;
            }
            return sector;
        }

        /// <summary>
        /// Add sector if does not exists
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Sector> GetSectorByNameAddNonExisting(string name)
        {
            var sector =
                await _context.Sector
                    .SingleOrDefaultAsync(m => m.Name == name);
            if (sector == null)
            {
                var sec = new Sector { Name = name };
                var sectorAdded = await AddSector(sec);
                return sec;
            }
            return sector;
        }
        /// <summary>
        /// Get sector by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Sector</returns>
        public async Task<Sector> GetSectorById(string id)
        {
            var sector =
                await _context.Sector
                    .SingleOrDefaultAsync(m => m.Id == id);
            return sector;
        }
        /// <summary>
        /// Check for Companies in DB by its symbol
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>Companies model</returns>
        public async Task<Companies> GetCompanyByName(string symbol)
        {
            var company =
                await _context.Companies
                    .SingleOrDefaultAsync(m => m.Symbol == symbol);
            return company;
        }

        /// <summary>
        /// Get company by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Companies</returns>
        public async Task<Companies> GetCompanyById(string id)
        {
            var company =
                await _context.Companies
                    .SingleOrDefaultAsync(m => m.Id == id);
            return company;
        }
        /// <summary>
        /// Check for Exchange in DB by its symbol
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>Exchange model</returns>
        public async Task<Exchange> GetExchangeByName(string symbol)
        {
            var exchange =
                await _context.Exchange
                    .SingleOrDefaultAsync(m => m.StockExchangeId == symbol);
            return exchange;
        }
        /// <summary>
        /// Check for Currencies in DB by its code
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Currency model</returns>
        public async Task<Currencies> GetCurrencyByCode(string code)
        {
            var currency =
                await _context.Currencies
                    .SingleOrDefaultAsync(m => m.Code == code);
            return currency;
        }
        /// <summary>
        /// Get currency by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Currencies</returns>
        public async Task<Currencies> GetCurrencyById(string id)
        {
            var currency =
                await _context.Currencies
                    .SingleOrDefaultAsync(m => m.Id == id);
            return currency;
        }
        /// <summary>
        /// Add FinanceModel to DataBase
        /// </summary>
        /// <param name="financeModel"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Add Industry to DataBase
        /// </summary>
        /// <param name="industry"></param>
        /// <returns>Id of added Industry</returns>
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

        public async Task<string> AddCompanyProfile(CompanyProfile companyProfile)
        {
            if (companyProfile == null)
            {
                return null;
            }
            if (CompanyProfileIdExists(companyProfile.CompaniesId))
            {
                var cp = await GetCompanyProfileById(companyProfile.CompaniesId);
                return cp.Id;
            }
            _context.CompanyProfile.Add(companyProfile);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (CompanyProfileIdExists(companyProfile.CompaniesId))
                {
                    Console.WriteLine("Company Profile with name: " + companyProfile.Companies.Name + " exists in curent database!");
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }

            }
            return companyProfile.Id;
        }

        public async Task<string> AddCompanyOfficers(CompanyOfficers companyOfficers)
        {
            if (companyOfficers == null)
            {
                return null;
            }
            if (CompanyOfficersNameExists(companyOfficers.Name))
            {
                var cp = await GetCompanyOfficersByName(companyOfficers.Name);
                return cp.Id;
            }
            _context.CompanyOfficers.Add(companyOfficers);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbException ex)
            {
                if (CompanyOfficersNameExists(companyOfficers.Name))
                {
                    Console.WriteLine("Company Officer with name: " + companyOfficers.Name + " exists in curent database!");
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return companyOfficers.Id;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="history"></param>
        /// <returns></returns>
        public async Task<string> AddHistory(History history)
        {
            if (history == null)
            {
                return null;
            }
            if (HistoryIdExists(history.CompaniesId, history.Date))
            {
                var hist = await GetHistoryByDate(history.Date, history.CompaniesId);
                return hist.Id;
            }
            _context.History.Add(history);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (HistoryIdExists(history.CompaniesId, history.Date))
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }

            }
            return history.Id;
        }
        /// <summary>
        /// Add Country to DataBase
        /// </summary>
        /// <param name="country"></param>
        /// <returns>Id of added Country</returns>
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
        /// <summary>
        /// Add Sector to DataBase
        /// </summary>
        /// <param name="sector"></param>
        /// <returns>Id of added Sector</returns>
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
        /// <summary>
        /// Add Region to DataBase
        /// </summary>
        /// <param name="region"></param>
        /// <returns>Id of added Region</returns>
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
        /// <summary>
        /// Add Companies to DataBase
        /// </summary>
        /// <param name="companies"></param>
        /// <returns>Id of added Companies</returns>
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
        /// <summary>
        /// Add Exchange to DataBase
        /// </summary>
        /// <param name="exchange"></param>
        /// <returns>Id of added Exchange</returns>
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
        /// <summary>
        /// Add Currency to database
        /// </summary>
        /// <param name="currencies"></param>
        /// <returns>Id of added Currency</returns>
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
        /// <summary>
        /// Check if FinanceModel exists by its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True or False</returns>
        public bool IdExists(string id)
        {
            return _context.FinanceModel.Count(e => e.Id == id) > 0;
        }
        /// <summary>
        /// Check if Companies exists by its symbol
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>True or False</returns>
        public bool CompIdExists(string symbol)
        {
            return _context.Companies.Count(e => e.Symbol == symbol) > 0;
        }
        /// <summary>
        /// Check if Exchange exists by its symbol
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>True or False</returns>
        public bool ExchangeIdExists(string symbol)
        {
            return _context.Exchange.Count(e => e.StockExchangeId == symbol) > 0;
        }
        /// <summary>
        /// Check if Industry exists by its name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>True or False</returns>
        public bool IndustryIdExists(string name)
        {
            return _context.Industrie.Count(e => e.Name == name) > 0;
        }

        public bool HistoryIdExists(string compId, string date)
        {
            return _context.History.Count(e => (e.CompaniesId == compId) && (e.Date == date)) > 0;
        }
        /// <summary>
        /// Check if Country exists by its name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>True or False</returns>
        public bool CountryIdExists(string name)
        {
            return _context.Country.Count(e => e.Name == name) > 0;
        }
        /// <summary>
        /// Check if Region exists by its name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>True or False</returns>
        public bool RegionIdExists(string name)
        {
            return _context.Region.Count(e => e.Name == name) > 0;
        }
        /// <summary>
        /// Check if Sector exists by its name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>True or False</returns>
        public bool SectorIdExists(string name)
        {
            return _context.Sector.Count(e => e.Name == name) > 0;
        }
        public bool CompanyProfileIdExists(string id)
        {
            return _context.CompanyProfile.Count(e => e.CompaniesId == id) > 0;
        }
        public async Task<bool> CompanyProfileExists(string symbol)
        {
            var company = await GetCompanyByName(symbol);
            return _context.CompanyProfile.Count(e => e.CompaniesId == company.Id) > 0;
        }

        public bool CompanyOfficersNameExists(string name)
        {
            return _context.CompanyOfficers.Count(e => e.Name == name) > 0;
        }
        public bool CompanyOfficersIdExists(string id)
        {
            return _context.CompanyOfficers.Count(e => e.Id == id) > 0;
        }
        /// <summary>
        /// Check if Currency exists by its code
        /// </summary>
        /// <param name="code"></param>
        /// <returns>True or False</returns>
        public bool CurrencyExists(string code)
        {
            return _context.Currencies.Count(e => e.Code == code) > 0;
        }
        /// <summary>
        /// Task to delete company from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Message</returns>
        public async Task DeleteCompany(string id)
        {
            var company = await GetCompanyById(id);
            if (company == null)
            {
                Console.WriteLine("NotFound");
            }
            if (company != null) _context.Companies.Remove(company);
            try
            {
                await _context.SaveChangesAsync();
                Console.WriteLine("Success: Company deleted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// find and delete industry
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteIndustry(string id)
        {
            var industry = await GetIndustryById(id);
            if (industry == null)
            {
                Console.WriteLine("NotFound");
            }
            if (industry != null) _context.Industrie.Remove(industry);
            try
            {
                await _context.SaveChangesAsync();
                Console.WriteLine("Success: Industry deleted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Find and Delete region by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Message</returns>
        public async Task DeleteRegion(string id)
        {
            var region = await GetRegionById(id);
            if (region == null)
            {
                Console.WriteLine("NotFound");
            }
            if (region != null) _context.Region.Remove(region);
            try
            {
                await _context.SaveChangesAsync();
                Console.WriteLine("Success: Region deleted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Find and Delete Sector
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Message</returns>
        public async Task DeleteSector(string id)
        {
            var sector = await GetSectorById(id);
            if (sector == null)
            {
                Console.WriteLine("NotFound");
            }
            if (sector != null) _context.Sector.Remove(sector);
            try
            {
                await _context.SaveChangesAsync();
                Console.WriteLine("Success: Sector deleted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Find and Delete currency
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Message</returns>
        public async Task DeleteCurrency(string id)
        {
            var currency = await GetCurrencyById(id);
            if (currency == null)
            {
                Console.WriteLine("NotFound");
            }
            if (currency != null) _context.Currencies.Remove(currency);
            try
            {
                await _context.SaveChangesAsync();
                Console.WriteLine("Success: Sector deleted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
