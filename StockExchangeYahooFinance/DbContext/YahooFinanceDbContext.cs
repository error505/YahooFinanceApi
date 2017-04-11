using Microsoft.EntityFrameworkCore;
using StockExchangeYahooFinance.Models;

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
            builder.UseSqlServer("Server=LBSDEV02;Database=YahooFinance;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(builder);
        }

        public DbSet<FinanceModel> FinanceModel { get; set; }


    }
}
