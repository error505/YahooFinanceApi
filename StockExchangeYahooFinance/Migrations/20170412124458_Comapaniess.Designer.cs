using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using StockExchangeYahooFinance.DbContext;

namespace StockExchangeYahooFinance.Migrations
{
    [DbContext(typeof(YahooFinanceDbContext))]
    [Migration("20170412124458_Comapaniess")]
    partial class Comapaniess
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StockExchangeYahooFinance.Data.FinanceModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AfterHoursChangeRealtime");

                    b.Property<string>("AnnualizedGain");

                    b.Property<string>("Ask");

                    b.Property<string>("AskRealtime");

                    b.Property<string>("AverageDailyVolume");

                    b.Property<string>("Bid");

                    b.Property<string>("BidRealtime");

                    b.Property<string>("BookValue");

                    b.Property<string>("Change");

                    b.Property<string>("ChangeFromFiftydayMovingAverage");

                    b.Property<string>("ChangeFromTwoHundreddayMovingAverage");

                    b.Property<string>("ChangeFromYearHigh");

                    b.Property<string>("ChangeFromYearLow");

                    b.Property<string>("ChangePercentRealtime");

                    b.Property<string>("ChangeRealtime");

                    b.Property<string>("Change_PercentChange");

                    b.Property<string>("ChangeinPercent");

                    b.Property<string>("Commission");

                    b.Property<string>("CurencyId");

                    b.Property<string>("Currency");

                    b.Property<string>("Date");

                    b.Property<string>("DaysHigh");

                    b.Property<string>("DaysLow");

                    b.Property<string>("DaysRange");

                    b.Property<string>("DaysRangeRealtime");

                    b.Property<string>("DaysValueChange");

                    b.Property<string>("DaysValueChangeRealtime");

                    b.Property<string>("DividendPayDate");

                    b.Property<string>("DividendShare");

                    b.Property<string>("DividendYield");

                    b.Property<string>("EBITDA");

                    b.Property<string>("EPSEstimateCurrentYear");

                    b.Property<string>("EPSEstimateNextQuarter");

                    b.Property<string>("EPSEstimateNextYear");

                    b.Property<string>("EarningsShare");

                    b.Property<string>("ErrorIndicationreturnedforsymbolchangedinvalid");

                    b.Property<string>("ExDividendDate");

                    b.Property<string>("FiftydayMovingAverage");

                    b.Property<string>("HighLimit");

                    b.Property<string>("HoldingsGain");

                    b.Property<string>("HoldingsGainPercent");

                    b.Property<string>("HoldingsGainPercentRealtime");

                    b.Property<string>("HoldingsGainRealtime");

                    b.Property<string>("HoldingsValue");

                    b.Property<string>("HoldingsValueRealtime");

                    b.Property<string>("LastTradeDate");

                    b.Property<string>("LastTradePriceOnly");

                    b.Property<string>("LastTradeRealtimeWithTime");

                    b.Property<string>("LastTradeTime");

                    b.Property<string>("LastTradeWithTime");

                    b.Property<string>("LowLimit");

                    b.Property<string>("MarketCapRealtime");

                    b.Property<string>("MarketCapitalization");

                    b.Property<string>("MoreInfo");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<string>("OneyrTargetPrice");

                    b.Property<string>("Open");

                    b.Property<string>("OrderBookRealtime");

                    b.Property<string>("PEGRatio");

                    b.Property<string>("PERatio");

                    b.Property<string>("PERatioRealtime");

                    b.Property<string>("PercebtChangeFromYearHigh");

                    b.Property<string>("PercentChange");

                    b.Property<string>("PercentChangeFromFiftydayMovingAverage");

                    b.Property<string>("PercentChangeFromTwoHundreddayMovingAverage");

                    b.Property<string>("PercentChangeFromYearLow");

                    b.Property<string>("PreviousClose");

                    b.Property<string>("PriceBook");

                    b.Property<string>("PriceEPSEstimateCurrentYear");

                    b.Property<string>("PriceEPSEstimateNextYear");

                    b.Property<string>("PricePaid");

                    b.Property<string>("PriceSales");

                    b.Property<string>("Rate");

                    b.Property<string>("SharesOwned");

                    b.Property<string>("ShortRatio");

                    b.Property<string>("StockExchange");

                    b.Property<string>("Symbol");

                    b.Property<string>("TickerTrend");

                    b.Property<string>("Time");

                    b.Property<string>("TradeDate");

                    b.Property<string>("TwoHundreddayMovingAverage");

                    b.Property<string>("Volume");

                    b.Property<string>("YearHigh");

                    b.Property<string>("YearLow");

                    b.Property<string>("YearRange");

                    b.HasKey("Id");

                    b.ToTable("FinanceModel");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.Companies", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ADR_TSO");

                    b.Property<string>("IPOyear");

                    b.Property<string>("IndustryId");

                    b.Property<string>("LastSale");

                    b.Property<string>("MarketCap");

                    b.Property<string>("Name");

                    b.Property<string>("RegionId");

                    b.Property<string>("SectorId");

                    b.Property<string>("Symbol");

                    b.HasKey("Id");

                    b.HasIndex("IndustryId");

                    b.HasIndex("RegionId");

                    b.HasIndex("SectorId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.Industry", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Industrie");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.Region", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.Sector", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Sector");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.Companies", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Industry", "Industry")
                        .WithMany()
                        .HasForeignKey("IndustryId");

                    b.HasOne("StockExchangeYahooFinance.Data.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId");

                    b.HasOne("StockExchangeYahooFinance.Data.Models.Sector", "Sector")
                        .WithMany()
                        .HasForeignKey("SectorId");
                });
        }
    }
}
