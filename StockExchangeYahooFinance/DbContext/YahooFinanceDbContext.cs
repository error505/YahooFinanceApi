using Microsoft.EntityFrameworkCore;
using StockExchangeYahooFinance.Data;
using StockExchangeYahooFinance.Data.Models;

namespace StockExchangeYahooFinance.DbContext
{
    using Microsoft.EntityFrameworkCore;

    public class YahooFinanceDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=DESKTOP-0QCFIRJ;Database=YahooFinance;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(builder);
        }

        public DbSet<FinanceModel> FinanceModel { get; set; }

        public DbSet<Industry> Industrie { get; set; }

        public DbSet<Sector> Sector { get; set; }

        public DbSet<Companies> Companies { get; set; }

        public DbSet<Region> Region { get; set; }
    }
}
