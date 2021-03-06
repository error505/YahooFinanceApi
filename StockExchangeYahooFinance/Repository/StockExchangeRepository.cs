﻿using System;
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

        #region GetFromDatabase

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

        public IEnumerable<IncomeStatementHistory> GetIncomeStatementHistoryByCompanyId(string companiesId)
        {
            return _context.IncomeStatementHistory.Where(c => c.CompaniesId == companiesId).ToList();
        }
        public async Task<IncomeStatementHistory> GetIncomeStatementHistoryByDate(string endDate, string companyId)
        {
            try
            {
                var incomeStatementHistory =
                await _context.IncomeStatementHistory
                    .SingleOrDefaultAsync(m => (m.EndDate == endDate && m.CompaniesId == companyId));
                return incomeStatementHistory;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<CashflowStatement> GetCashflowStatementHistoryByDate(string endDate, string companyId)
        {
            try
            {
                var cashflowStatementHistory =
                await _context.CashflowStatement
                    .SingleOrDefaultAsync(m => (m.EndDate == endDate && m.CompaniesId == companyId));
                return cashflowStatementHistory;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<BalanceSheetStatements> GetBalanceSheetStatementsByDate(string endDate, double cash, string companyId)
        {
            try
            {
                var balanceSheetStatements =
                await _context.BalanceSheetStatements
                    .SingleOrDefaultAsync(m => (m.EndDate == endDate && Math.Abs(m.Cash - cash) < 0.001 && m.CompaniesId == companyId));
                return balanceSheetStatements;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public async Task<MajorHoldersBreakdown> GetMajorHoldersBreakdownByInsidersPercentHeld(double insidersPercentHeld, string companyId)
        {
            try
            {
                var majorHoldersBreakdown =
                await _context.MajorHoldersBreakdown
                    .SingleOrDefaultAsync(m => (Math.Abs(m.InsidersPercentHeld - insidersPercentHeld) < 0.01 && m.CompaniesId == companyId));
                return majorHoldersBreakdown;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<FinancialData> GetFinancialDataByTotalRevenue(double totalRevenue, string companyId)
        {
            try
            {
                var financialData =
                await _context.FinancialData
                    .SingleOrDefaultAsync(m => (Math.Abs(m.TotalRevenue - totalRevenue) < 0.001 && m.CompaniesId == companyId));
                return financialData;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<EarningsEstimate> GetEarningsEstimateByGrowth(double growth, string companyId)
        {
            try
            {
                var earningsEstimate =
                await _context.EarningsEstimate
                    .SingleOrDefaultAsync(m => (Math.Abs(m.Growth - growth) < 0.001 && m.CompaniesId == companyId));
                return earningsEstimate;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<EpsRevisions> GetEpsRevisionsByGrowth(double upLast7Days, string companyId)
        {
            try
            {
                var epsRevisions =
                await _context.EpsRevisions
                    .SingleOrDefaultAsync(m => (Math.Abs(m.UpLast7Days - upLast7Days) < 0.001 && m.CompaniesId == companyId));
                return epsRevisions;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<RevenueEstimate> GetRevenueEstimateByGrowth(double growth, string companyId)
        {
            try
            {
                var revenueEstimate =
                await _context.RevenueEstimate
                    .SingleOrDefaultAsync(m => (Math.Abs(m.Growth - growth) < 0.001 && m.CompaniesId == companyId));
                return revenueEstimate;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<EpsTrend> GetEpsTrendByCurrent(double current, string companyId)
        {
            try
            {
                var epsTrend =
                await _context.EpsTrend
                    .SingleOrDefaultAsync(m => (Math.Abs(m.Current - current) < 0.001 && m.CompaniesId == companyId));
                return epsTrend;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<EarningsTrend> GetEarningsTrendByGrowthAndDate(double growth, string endDate, string companyId)
        {
            try
            {
                var earningsTrend =
                await _context.EarningsTrend
                    .SingleOrDefaultAsync(m => (Math.Abs(m.Growth - growth) < 0.001 && m.CompaniesId == companyId && m.EndDate == endDate));
                return earningsTrend;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<DefaultKeyStatistics> GetDefaultKeyStatistics(double enterpriseValue, string companyId)
        {
            try
            {
                var defaultKeyStatistics =
                await _context.DefaultKeyStatistics
                    .SingleOrDefaultAsync(m => (Math.Abs(m.EnterpriseValue - enterpriseValue) < 0.001 && m.CompaniesId == companyId));
                return defaultKeyStatistics;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<InstitutionOwnership> GetInstitutionOwnershipByDate(string organisation, string companyId)
        {
            try
            {
                var institutionOwnership =
                await _context.InstitutionOwnership
                    .SingleOrDefaultAsync(m => (m.Organization == organisation && m.CompaniesId == companyId));
                return institutionOwnership;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<FundOwnership> GetFundOwnershipByOrganisation(string organisation, string companyId)
        {
            try
            {
                var fundOwnership =
                await _context.FundOwnership
                    .SingleOrDefaultAsync(m => (m.Organization == organisation && m.CompaniesId == companyId));
                return fundOwnership;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<MajorDirectHolders> GetMajorDirectHoldersByName(string name, string companyId)
        {
            try
            {
                var majorDirectHolders =
                await _context.MajorDirectHolders
                    .SingleOrDefaultAsync(m => (m.Name == name && m.CompaniesId == companyId));
                return majorDirectHolders;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<InsiderHolders> GetInsiderHoldersByName(string name, string companyId)
        {
            try
            {
                var insiderHolders =
                await _context.InsiderHolders
                    .SingleOrDefaultAsync(m => (m.Name == name && m.CompaniesId == companyId));
                return insiderHolders;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<InsiderTransactions> GetInsiderTransactionsByName(double shares, string companyId, string startDate, string filerName, string filerUrl)
        {
            try
            {
                var insiderTransactions =
                await _context.InsiderTransactions
                    .SingleOrDefaultAsync(e => (Math.Abs(e.Shares - shares) < 0.001 && e.CompaniesId == companyId && e.StartDate == startDate && e.FilerName == filerName && e.FilerUrl == filerUrl));
                return insiderTransactions;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<RecommendationTrend> GetRecommendationTrendByPeriod(string period, string companyId)
        {
            try
            {
                var recommendationTrend =
                await _context.RecommendationTrend
                    .SingleOrDefaultAsync(m => (m.Period == period && m.CompaniesId == companyId));
                return recommendationTrend;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<UpgradeDowngradeHistory> GetUpgradeDowngradeHistoryByEpochGradeDate(string epochGradeDate, string companyId)
        {
            try
            {
                var upgradeDowngradeHistory =
                await _context.UpgradeDowngradeHistory
                    .SingleOrDefaultAsync(m => (m.EpochGradeDate == epochGradeDate && m.CompaniesId == companyId));
                return upgradeDowngradeHistory;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
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
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<History> GetHistoryByDate(string date, string companyId)
        {
            try
            {
                var company = await GetCompanyById(companyId);
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
            try
            {
                var company =
                await _context.Companies
                    .SingleOrDefaultAsync(m => m.Symbol == symbol);
                return company;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            
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

        #endregion GetFromDatabase

        #region AddToDatabase

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

        public async Task<string> AddIncomeStatementHistory(IncomeStatementHistory incomeStatementHistory)
        {
            if (incomeStatementHistory == null)
            {
                return null;
            }
            if (IncomeStatementHistoryIdExists(incomeStatementHistory.EndDate, incomeStatementHistory.CompaniesId))
            {
                var ind = await GetIncomeStatementHistoryByDate(incomeStatementHistory.EndDate, incomeStatementHistory.CompaniesId);
                return ind.Id;
            }
            _context.IncomeStatementHistory.Add(incomeStatementHistory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbException ex)
            {
                if (IncomeStatementHistoryIdExists(incomeStatementHistory.EndDate, incomeStatementHistory.CompaniesId))
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }

            }
            return incomeStatementHistory.Id;
        }

        public async Task<string> AddCashflowStatementHistory(CashflowStatement cashflowStatement)
        {
            if (cashflowStatement == null)
            {
                return null;
            }
            if (CashflowStatementHistoryIdExists(cashflowStatement.EndDate, cashflowStatement.CompaniesId))
            {
                var ind = await GetCashflowStatementHistoryByDate(cashflowStatement.EndDate, cashflowStatement.CompaniesId);
                return ind.Id;
            }
            _context.CashflowStatement.Add(cashflowStatement);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbException ex)
            {
                if (CashflowStatementHistoryIdExists(cashflowStatement.EndDate, cashflowStatement.CompaniesId))
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }

            }
            return cashflowStatement.Id;
        }

        public async Task<string> AddBalanceSheetStatements(BalanceSheetStatements balanceSheetStatements)
        {
            if (balanceSheetStatements == null)
            {
                return null;
            }
            if (BalanceSheetStatementsIdExists(balanceSheetStatements.EndDate, balanceSheetStatements.Cash, balanceSheetStatements.CompaniesId))
            {
                var ind = await GetBalanceSheetStatementsByDate(balanceSheetStatements.EndDate, balanceSheetStatements.Cash, balanceSheetStatements.CompaniesId);
                return ind.Id;
            }
            _context.BalanceSheetStatements.Add(balanceSheetStatements);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbException ex)
            {
                if (BalanceSheetStatementsIdExists(balanceSheetStatements.EndDate, balanceSheetStatements.Cash, balanceSheetStatements.CompaniesId))
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }

            }
            return balanceSheetStatements.Id;
        }

        

        public async Task<string> AddFinancialData(FinancialData financialData)
        {
            if (financialData == null)
            {
                return null;
            }
            if (FinancialDataIdExists(financialData.TotalRevenue, financialData.CompaniesId))
            {
                var ind = await GetFinancialDataByTotalRevenue(financialData.TotalRevenue, financialData.CompaniesId);
                return ind.Id;
            }
            _context.FinancialData.Add(financialData);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (FinancialDataIdExists(financialData.TotalRevenue, financialData.CompaniesId))
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }

            }
            return financialData.Id;
        }

        public async Task<string> AddEarningsEstimate(EarningsEstimate earningsEstimate)
        {
            if (earningsEstimate == null)
            {
                return null;
            }
            if (EarningsEstimateIdExists(earningsEstimate.Growth, earningsEstimate.CompaniesId))
            {
                var ind = await GetEarningsEstimateByGrowth(earningsEstimate.Growth, earningsEstimate.CompaniesId);
                return ind.Id;
            }
            _context.EarningsEstimate.Add(earningsEstimate);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (EarningsEstimateIdExists(earningsEstimate.Growth, earningsEstimate.CompaniesId))
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }

            }
            return earningsEstimate.Id;
        }

        public async Task<string> AddEpsRevisions(EpsRevisions epsRevisions)
        {
            if (epsRevisions == null)
            {
                return null;
            }
            if (EpsRevisionsIdExists(epsRevisions.UpLast7Days, epsRevisions.CompaniesId))
            {
                var ind = await GetEpsRevisionsByGrowth(epsRevisions.UpLast7Days, epsRevisions.CompaniesId);
                return ind.Id;
            }
            _context.EpsRevisions.Add(epsRevisions);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (EpsRevisionsIdExists(epsRevisions.UpLast7Days, epsRevisions.CompaniesId))
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }
            }
            return epsRevisions.Id;
        }

        public async Task<string> AddRevenueEstimate(RevenueEstimate estimate)
        {
            if (estimate == null)
            {
                return null;
            }
            if (RevenueEstimateIdExists(estimate.Growth, estimate.CompaniesId))
            {
                var ind = await GetRevenueEstimateByGrowth(estimate.Growth, estimate.CompaniesId);
                return ind.Id;
            }
            _context.RevenueEstimate.Add(estimate);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (RevenueEstimateIdExists(estimate.Growth, estimate.CompaniesId))
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }
            }
            return estimate.Id;
        }


        public async Task<string> AddEpsTrend(EpsTrend epsTrend)
        {
            if (epsTrend == null)
            {
                return null;
            }
            if (EpsTrendIdExists(epsTrend.Current, epsTrend.CompaniesId))
            {
                var ind = await GetEpsTrendByCurrent(epsTrend.Current, epsTrend.CompaniesId);
                return ind.Id;
            }
            _context.EpsTrend.Add(epsTrend);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (EpsTrendIdExists(epsTrend.Current, epsTrend.CompaniesId))
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }
            }
            return epsTrend.Id;
        }

        public async Task<string> AddEarningsTrend(EarningsTrend earningsTrend)
        {
            if (earningsTrend == null)
            {
                return null;
            }
            if (EarningsTrendIdExists(earningsTrend.Growth, earningsTrend.EndDate, earningsTrend.CompaniesId))
            {
                var ind = await GetEarningsTrendByGrowthAndDate(earningsTrend.Growth, earningsTrend.EndDate, earningsTrend.CompaniesId);
                return ind.Id;
            }
            _context.EarningsTrend.Add(earningsTrend);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (EarningsTrendIdExists(earningsTrend.Growth, earningsTrend.EndDate, earningsTrend.CompaniesId))
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }
            }
            return earningsTrend.Id;
        }

        public async Task<string> AddDefaultKeyStatistics(DefaultKeyStatistics defaultKeyStatistics)
        {
            if (defaultKeyStatistics == null)
            {
                return null;
            }
            if (DefaultKeyStatisticsIdExists(defaultKeyStatistics.EnterpriseValue, defaultKeyStatistics.CompaniesId))
            {
                var ind = await GetDefaultKeyStatistics(defaultKeyStatistics.EnterpriseValue, defaultKeyStatistics.CompaniesId);
                return ind.Id;
            }
            _context.DefaultKeyStatistics.Add(defaultKeyStatistics);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (DefaultKeyStatisticsIdExists(defaultKeyStatistics.EnterpriseValue, defaultKeyStatistics.CompaniesId))
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }

            }
            return defaultKeyStatistics.Id;
        }

        public async Task<string> AddMajorHoldersBreakdown(MajorHoldersBreakdown majorHoldersBreakdown)
        {
            if (majorHoldersBreakdown == null)
            {
                return null;
            }
            if (MajorHoldersBreakdownIdExists(majorHoldersBreakdown.InsidersPercentHeld, majorHoldersBreakdown.CompaniesId))
            {
                var ind = await GetMajorHoldersBreakdownByInsidersPercentHeld(majorHoldersBreakdown.InsidersPercentHeld, majorHoldersBreakdown.CompaniesId);
                return ind.Id;
            }
            _context.MajorHoldersBreakdown.Add(majorHoldersBreakdown);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbException ex)
            {
                if (MajorHoldersBreakdownIdExists(majorHoldersBreakdown.InsidersPercentHeld, majorHoldersBreakdown.CompaniesId))
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }

            }
            return majorHoldersBreakdown.Id;
        }

        public async Task<string> AddInstitutionOwnership(InstitutionOwnership institutionOwnership)
        {
            if (institutionOwnership == null)
            {
                return null;
            }
            if (InstitutionOwnershipIdExists(institutionOwnership.Organization, institutionOwnership.CompaniesId))
            {
                var ind = await GetInstitutionOwnershipByDate(institutionOwnership.Organization, institutionOwnership.CompaniesId);
                return ind.Id;
            }
            _context.InstitutionOwnership.Add(institutionOwnership);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbException ex)
            {
                if (InstitutionOwnershipIdExists(institutionOwnership.Organization, institutionOwnership.CompaniesId))
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }

            }
            return institutionOwnership.Id;
        }

        public async Task<string> AddFundOwnership(FundOwnership fundOwnership)
        {
            if (fundOwnership == null)
            {
                return null;
            }
            if (FundOwnershipIdExists(fundOwnership.Organization, fundOwnership.CompaniesId))
            {
                var ind = await GetFundOwnershipByOrganisation(fundOwnership.Organization, fundOwnership.CompaniesId);
                return ind.Id;
            }
            _context.FundOwnership.Add(fundOwnership);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (FundOwnershipIdExists(fundOwnership.Organization, fundOwnership.CompaniesId))
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }

            }
            return fundOwnership.Id;
        }

        public async Task<string> AddMajorDirectHolders(MajorDirectHolders majorDirectHolders)
        {
            if (majorDirectHolders == null)
            {
                return null;
            }
            if (MajorDirectHoldersIdExists(majorDirectHolders.Name, majorDirectHolders.CompaniesId))
            {
                var ind = await GetMajorDirectHoldersByName(majorDirectHolders.Name, majorDirectHolders.CompaniesId);
                return ind.Id;
            }
            _context.MajorDirectHolders.Add(majorDirectHolders);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (MajorDirectHoldersIdExists(majorDirectHolders.Name, majorDirectHolders.CompaniesId))
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }
            }
            return majorDirectHolders.Id;
        }

        public async Task<string> AddInsiderHolders(InsiderHolders insiderHolders)
        {
            if (insiderHolders == null)
            {
                return null;
            }
            if (InsiderHoldersIdExists(insiderHolders.Name, insiderHolders.CompaniesId))
            {
                var ind = await GetInsiderHoldersByName(insiderHolders.Name, insiderHolders.CompaniesId);
                return ind.Id;
            }
            _context.InsiderHolders.Add(insiderHolders);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (InsiderHoldersIdExists(insiderHolders.Name, insiderHolders.CompaniesId))
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }
            }
            return insiderHolders.Id;
        }


        public async Task<string> AddInsiderTransactions(InsiderTransactions insiderTransactions)
        {
            if (insiderTransactions == null)
            {
                return null;
            }
            if (InsiderTransactionsIdExists(insiderTransactions.Shares, insiderTransactions.CompaniesId, insiderTransactions.StartDate, insiderTransactions.FilerName, insiderTransactions.FilerUrl))
            {
                var ind = await GetInsiderTransactionsByName(insiderTransactions.Shares, insiderTransactions.CompaniesId, insiderTransactions.StartDate, insiderTransactions.FilerName, insiderTransactions.FilerUrl);
                return ind.Id;
            }
            _context.InsiderTransactions.Add(insiderTransactions);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (InsiderTransactionsIdExists(insiderTransactions.Shares, insiderTransactions.CompaniesId, insiderTransactions.StartDate, insiderTransactions.FilerName, insiderTransactions.FilerUrl))
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }
            }
            return insiderTransactions.Id;
        }

        public async Task<string> AddRecommendationTrend(RecommendationTrend recommendationTrend)
        {
            if (recommendationTrend == null)
            {
                return null;
            }
            if (RecommendationTrendIdExists(recommendationTrend.Period, recommendationTrend.CompaniesId))
            {
                var ind = await GetRecommendationTrendByPeriod(recommendationTrend.Period, recommendationTrend.CompaniesId);
                return ind.Id;
            }
            _context.RecommendationTrend.Add(recommendationTrend);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbException ex)
            {
                if (RecommendationTrendIdExists(recommendationTrend.Period, recommendationTrend.CompaniesId))
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }
            }
            return recommendationTrend.Id;
        }

        public async Task<string> AddUpgradeDowngradeHistory(UpgradeDowngradeHistory upgradeDowngradeHistory)
        {
            if (upgradeDowngradeHistory == null)
            {
                return null;
            }
            if (UpgradeDowngradeHistoryIdExists(upgradeDowngradeHistory.EpochGradeDate, upgradeDowngradeHistory.CompaniesId))
            {
                var ind = await GetUpgradeDowngradeHistoryByEpochGradeDate(upgradeDowngradeHistory.EpochGradeDate, upgradeDowngradeHistory.CompaniesId);
                return ind.Id;
            }
            _context.UpgradeDowngradeHistory.Add(upgradeDowngradeHistory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbException ex)
            {
                if (UpgradeDowngradeHistoryIdExists(upgradeDowngradeHistory.EpochGradeDate, upgradeDowngradeHistory.CompaniesId))
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }
            }
            return upgradeDowngradeHistory.Id;
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

        #endregion AddToDatabase

        #region UpdateRecord

        /// <summary>
        /// Update Financial Data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="financialData"></param>
        /// <returns></returns>
        public async Task<string> UpdateFinancialData(string id, FinancialData financialData)
        {
            if (financialData == null)
            {
                Console.WriteLine("Model Is empty!");
            }

            if (financialData != null && id != financialData.Id)
            {
                Console.WriteLine("Model Id is not the same like provided ID!");
            }

            _context.Entry(financialData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (FinancialDataIdExists(financialData.TotalRevenue, financialData.CompaniesId))
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
                else
                {
                    Console.WriteLine(ex);
                }
            }
            return financialData.Id;
        }

        #endregion UpdateRecord

        #region CheckIfExists

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

        public bool IncomeStatementHistoryIdExists(string endDate, string companyId)
        {
            return _context.IncomeStatementHistory.Count(e => (e.EndDate == endDate && e.CompaniesId == companyId)) > 0;
        }

        public bool CashflowStatementHistoryIdExists(string endDate, string companyId)
        {
            return _context.CashflowStatement.Count(e => (e.EndDate == endDate && e.CompaniesId == companyId)) > 0;
        }

        public bool BalanceSheetStatementsIdExists(string endDate, double cash, string companyId)
        {
            return _context.BalanceSheetStatements.Count(e => (e.EndDate == endDate && Math.Abs(e.Cash - cash) < 0.001 && e.CompaniesId == companyId)) > 0;
        }

        public bool FinancialDataIdExists(double totalRevenue, string companyId)
        {
            return _context.FinancialData.Count(e => (Math.Abs(e.TotalRevenue - totalRevenue) < 0.001 && e.CompaniesId == companyId)) > 0;
        }

        public bool EarningsEstimateIdExists(double growth, string companyId)
        {
            return _context.EarningsEstimate.Count(e => (Math.Abs(e.Growth - growth) < 0.001 && e.CompaniesId == companyId)) > 0;
        }

        public bool EpsRevisionsIdExists(double upLast7Days, string companyId)
        {
            return _context.EpsRevisions.Count(e => (Math.Abs(e.UpLast7Days - upLast7Days) < 0.001 && e.CompaniesId == companyId)) > 0;
        }

        public bool RevenueEstimateIdExists(double growth, string companyId)
        {
            return _context.RevenueEstimate.Count(e => (Math.Abs(e.Growth - growth) < 0.001 && e.CompaniesId == companyId)) > 0;
        }

        public bool EpsTrendIdExists(double current, string companyId)
        {
            return _context.EpsTrend.Count(e => (Math.Abs(e.Current - current) < 0.001 && e.CompaniesId == companyId)) > 0;
        }

        public bool EarningsTrendIdExists(double growth, string endDate, string companyId)
        {
            return _context.EarningsTrend.Any(e => (Math.Abs(e.Growth - growth) < 0.001 && e.CompaniesId == companyId && e.EndDate == endDate));
        }

        public bool DefaultKeyStatisticsIdExists(double enterpriseValue, string companyId)
        {
            return _context.DefaultKeyStatistics.Count(e => (Math.Abs(e.EnterpriseValue - enterpriseValue) < 0.001 && e.CompaniesId == companyId)) > 0;
        }

        public bool MajorHoldersBreakdownIdExists(double insidersPercentHeld, string companyId)
        {
            return _context.MajorHoldersBreakdown.Count(e => (Math.Abs(e.InsidersPercentHeld - insidersPercentHeld) < 0.01 && e.CompaniesId == companyId)) > 0;
        }

        public bool InstitutionOwnershipIdExists(string organisation, string companyId)
        {
            return _context.InstitutionOwnership.Count(e => (e.Organization == organisation && e.CompaniesId == companyId)) > 0;
        }

        public bool FundOwnershipIdExists(string organisation, string companyId)
        {
            return _context.FundOwnership.Count(e => (e.Organization == organisation && e.CompaniesId == companyId)) > 0;
        }

        public bool MajorDirectHoldersIdExists(string name, string companyId)
        {
            return _context.MajorDirectHolders.Count(e => (e.Name == name && e.CompaniesId == companyId)) > 0;
        }

        public bool InsiderHoldersIdExists(string name, string companyId)
        {
            return _context.InsiderHolders.Count(e => (e.Name == name && e.CompaniesId == companyId)) > 0;
        }

        public bool InsiderTransactionsIdExists(double shares, string companyId, string startDate, string filerName, string filerUrl)
        {
            return _context.InsiderTransactions.Count(e => (Math.Abs(e.Shares - shares) < 0.001 && e.CompaniesId == companyId && e.StartDate == startDate && e.FilerName == filerName && e.FilerUrl == filerUrl)) > 0;
        }

        public bool RecommendationTrendIdExists(string period, string companyId)
        {
            return _context.RecommendationTrend.Count(e => (e.Period == period && e.CompaniesId == companyId)) > 0;
        }

        public bool UpgradeDowngradeHistoryIdExists(string epochGradeDate, string companyId)
        {
            return _context.UpgradeDowngradeHistory.Count(e => (e.EpochGradeDate == epochGradeDate && e.CompaniesId == companyId)) > 0;
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

        #endregion CheckIfExists

        #region DeleteFromDatabase

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

        #endregion DeleteFromDatabase

    }
}
