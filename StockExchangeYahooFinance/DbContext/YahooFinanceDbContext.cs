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
    }
}
