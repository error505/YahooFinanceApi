using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockExchangeYahooFinance.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinanceModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AfterHoursChangeRealtime = table.Column<string>(nullable: true),
                    AnnualizedGain = table.Column<string>(nullable: true),
                    Ask = table.Column<string>(nullable: true),
                    AskRealtime = table.Column<string>(nullable: true),
                    AverageDailyVolume = table.Column<string>(nullable: true),
                    Bid = table.Column<string>(nullable: true),
                    BidRealtime = table.Column<string>(nullable: true),
                    BookValue = table.Column<string>(nullable: true),
                    Change = table.Column<string>(nullable: true),
                    ChangeFromFiftydayMovingAverage = table.Column<string>(nullable: true),
                    ChangeFromTwoHundreddayMovingAverage = table.Column<string>(nullable: true),
                    ChangeFromYearHigh = table.Column<string>(nullable: true),
                    ChangeFromYearLow = table.Column<string>(nullable: true),
                    ChangePercentRealtime = table.Column<string>(nullable: true),
                    ChangeRealtime = table.Column<string>(nullable: true),
                    Change_PercentChange = table.Column<string>(nullable: true),
                    ChangeinPercent = table.Column<string>(nullable: true),
                    Commission = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    DaysHigh = table.Column<string>(nullable: true),
                    DaysLow = table.Column<string>(nullable: true),
                    DaysRange = table.Column<string>(nullable: true),
                    DaysRangeRealtime = table.Column<string>(nullable: true),
                    DaysValueChange = table.Column<string>(nullable: true),
                    DaysValueChangeRealtime = table.Column<string>(nullable: true),
                    DividendPayDate = table.Column<string>(nullable: true),
                    DividendShare = table.Column<string>(nullable: true),
                    DividendYield = table.Column<string>(nullable: true),
                    EBITDA = table.Column<string>(nullable: true),
                    EPSEstimateCurrentYear = table.Column<string>(nullable: true),
                    EPSEstimateNextQuarter = table.Column<string>(nullable: true),
                    EPSEstimateNextYear = table.Column<string>(nullable: true),
                    EarningsShare = table.Column<string>(nullable: true),
                    ErrorIndicationreturnedforsymbolchangedinvalid = table.Column<string>(nullable: true),
                    ExDividendDate = table.Column<string>(nullable: true),
                    FiftydayMovingAverage = table.Column<string>(nullable: true),
                    HighLimit = table.Column<string>(nullable: true),
                    HoldingsGain = table.Column<string>(nullable: true),
                    HoldingsGainPercent = table.Column<string>(nullable: true),
                    HoldingsGainPercentRealtime = table.Column<string>(nullable: true),
                    HoldingsGainRealtime = table.Column<string>(nullable: true),
                    HoldingsValue = table.Column<string>(nullable: true),
                    HoldingsValueRealtime = table.Column<string>(nullable: true),
                    LastTradeDate = table.Column<string>(nullable: true),
                    LastTradePriceOnly = table.Column<string>(nullable: true),
                    LastTradeRealtimeWithTime = table.Column<string>(nullable: true),
                    LastTradeTime = table.Column<string>(nullable: true),
                    LastTradeWithTime = table.Column<string>(nullable: true),
                    LowLimit = table.Column<string>(nullable: true),
                    MarketCapRealtime = table.Column<string>(nullable: true),
                    MarketCapitalization = table.Column<string>(nullable: true),
                    MoreInfo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    OneyrTargetPrice = table.Column<string>(nullable: true),
                    Open = table.Column<string>(nullable: true),
                    OrderBookRealtime = table.Column<string>(nullable: true),
                    PEGRatio = table.Column<string>(nullable: true),
                    PERatio = table.Column<string>(nullable: true),
                    PERatioRealtime = table.Column<string>(nullable: true),
                    PercebtChangeFromYearHigh = table.Column<string>(nullable: true),
                    PercentChange = table.Column<string>(nullable: true),
                    PercentChangeFromFiftydayMovingAverage = table.Column<string>(nullable: true),
                    PercentChangeFromTwoHundreddayMovingAverage = table.Column<string>(nullable: true),
                    PercentChangeFromYearLow = table.Column<string>(nullable: true),
                    PreviousClose = table.Column<string>(nullable: true),
                    PriceBook = table.Column<string>(nullable: true),
                    PriceEPSEstimateCurrentYear = table.Column<string>(nullable: true),
                    PriceEPSEstimateNextYear = table.Column<string>(nullable: true),
                    PricePaid = table.Column<string>(nullable: true),
                    PriceSales = table.Column<string>(nullable: true),
                    SharesOwned = table.Column<string>(nullable: true),
                    ShortRatio = table.Column<string>(nullable: true),
                    StockExchange = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true),
                    TickerTrend = table.Column<string>(nullable: true),
                    TradeDate = table.Column<string>(nullable: true),
                    TwoHundreddayMovingAverage = table.Column<string>(nullable: true),
                    Volume = table.Column<string>(nullable: true),
                    YearHigh = table.Column<string>(nullable: true),
                    YearLow = table.Column<string>(nullable: true),
                    YearRange = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinanceModel");
        }
    }
}
