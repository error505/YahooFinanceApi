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
            catch (DbUpdateException)
            {
                if (IdExists(financeModel.Id))
                {
                    return null;
                }
                else
                {
                    throw;
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
            catch (DbUpdateException)
            {
                if (IndustryIdExists(industry.Name))
                {
                    return null;
                }
                else
                {
                    throw;
                }

            }
            return industry.Id;
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
            catch (DbUpdateException)
            {
                if (SectorIdExists(sector.Name))
                {
                    return null;
                }
                else
                {
                    throw;
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
            catch (DbUpdateException)
            {
                if (RegionIdExists(region.Name))
                {
                    return null;
                }
                else
                {
                    throw;
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
                var comp = await GetRegionByName(companies.Symbol);
                return comp.Id;
            }
            _context.Companies.Add(companies);
            try
            {

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CompIdExists(companies.Symbol))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return companies.Id;
        }

        private bool IdExists(string id)
        {
            return _context.FinanceModel.Any(e => e.Id == id);
        }

        private bool CompIdExists(string symbol)
        {
            return _context.Companies.Any(e => e.Symbol == symbol);
        }

        private bool IndustryIdExists(string name)
        {
            return _context.Industrie.Any(e => e.Name == name);
        }

        private bool RegionIdExists(string name)
        {
            return _context.Region.Any(e => e.Name == name);
        }

        private bool SectorIdExists(string name)
        {
            return _context.Sector.Any(e => e.Name == name);
        }
    }
}
