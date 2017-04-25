using System.IO;
using Microsoft.Extensions.Configuration;
using StockExchangeYahooFinance.Data.Models;

namespace StockExchangeYahooFinance.DbContext
{
    using Microsoft.EntityFrameworkCore;

    public class YahooFinanceDbContext : DbContext
    {
        private static IConfigurationRoot Configuration { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public YahooFinanceDbContext()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(Configuration.GetConnectionString("YFConnection"));
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
    }
}
