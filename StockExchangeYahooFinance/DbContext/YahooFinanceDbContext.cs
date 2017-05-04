using StockExchangeYahooFinance.ConfigData;
using StockExchangeYahooFinance.Data.Models;

namespace StockExchangeYahooFinance.DbContext
{
    using Microsoft.EntityFrameworkCore;

    public class YahooFinanceDbContext : DbContext
    {
        private static readonly ConfigManager CfgManager = new ConfigManager();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(CfgManager.YahooDbConnectioString);
            base.OnConfiguring(builder);
        }

        public DbSet<FinanceModel> FinanceModel { get; set; }

        public DbSet<Industry> Industrie { get; set; }

        public DbSet<Sector> Sector { get; set; }

        public DbSet<Companies> Companies { get; set; }

        public DbSet<Region> Region { get; set; }

        public DbSet<Currencies> Currencies { get; set; }

        public DbSet<Exchange> Exchange { get; set; }

        public DbSet<Country> Country { get; set; }

        public DbSet<History> History { get; set; }
        public DbSet<CompanyProfile> CompanyProfile { get; set; }
        public DbSet<CompanyOfficers> CompanyOfficers { get; set; }
        public DbSet<IndustrySimbol> IndustrySimbol { get; set; }
        public DbSet<FinancialData> FinancialData { get; set; }
        public DbSet<CalendarEvents> CalendarEvents { get; set; }
        public DbSet<BalanceSheetStatements> BalanceSheetStatements { get; set; }
        public DbSet<CalendarEarnings> CalendarEarnings { get; set; }
        public DbSet<CashflowStatement> CashflowStatement { get; set; }
        public DbSet<DefaultKeyStatistics> DefaultKeyStatistics { get; set; }
        public DbSet<Earnings> Earnings { get; set; }
        public DbSet<EarningsChartQuarterly> EarningsChartQuarterly { get; set; }
        public DbSet<EarningsEstimate> EarningsEstimate { get; set; }
        public DbSet<EarningsHistory> EarningsHistory { get; set; }
        public DbSet<EarningsTrend> EarningsTrend { get; set; }
        public DbSet<EpsRevisions> EpsRevisions { get; set; }
        public DbSet<EpsTrend> EpsTrend { get; set; }
        public DbSet<Estimates> Estimates { get; set; }
        public DbSet<FinancialsChartQuarterly> FinancialsChartQuarterly { get; set; }
        public DbSet<FinancialsChartYearly> FinancialsChartYearly { get; set; }
        public DbSet<FundOwnership> FundOwnership { get; set; }
        public DbSet<IncomeStatementHistory> IncomeStatementHistory { get; set; }
        public DbSet<IndexTrend> IndexTrend { get; set; }
        public DbSet<IndustryTrend> IndustryTrend { get; set; }
        public DbSet<InsiderHolders> InsiderHolders { get; set; }
        public DbSet<InsiderTransactions> InsiderTransactions { get; set; }
        public DbSet<InstitutionOwnership> InstitutionOwnership { get; set; }
        public DbSet<MajorDirectHolders> MajorDirectHolders { get; set; }
        public DbSet<MajorHoldersBreakdown> MajorHoldersBreakdown { get; set; }
        public DbSet<NetSharePurchaseActivity> NetSharePurchaseActivity { get; set; }
        public DbSet<RecommendationTrend> RecommendationTrend { get; set; }
        public DbSet<RevenueEstimate> RevenueEstimate { get; set; }
        public DbSet<SectorTrend> SectorTrend { get; set; }
        public DbSet<UpgradeDowngradeHistory> UpgradeDowngradeHistory { get; set; }
        public DbSet<OptionsStrikes> OptionsStrikes { get; set; }
        public DbSet<OptionsExpirationDates> OptionsExpirationDates { get; set; }
        public DbSet<OptionsCalls> OptionsCalls { get; set; }
        public DbSet<OptionsQuote> OptionsQuote { get; set; }
    }
}
