using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockExchangeYahooFinance.Migrations
{
    public partial class newModules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OptionsCalls",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Ask = table.Column<string>(nullable: true),
                    Bid = table.Column<string>(nullable: true),
                    Change = table.Column<string>(nullable: true),
                    CompaniesId = table.Column<string>(nullable: true),
                    ContractSize = table.Column<string>(nullable: true),
                    ContractSymbol = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    Expiration = table.Column<string>(nullable: true),
                    ImpliedVolatility = table.Column<string>(nullable: true),
                    InTheMoney = table.Column<string>(nullable: true),
                    LastPrice = table.Column<string>(nullable: true),
                    OpenInterest = table.Column<string>(nullable: true),
                    PercentChange = table.Column<string>(nullable: true),
                    Strike = table.Column<string>(nullable: true),
                    Volume = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionsCalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OptionsCalls_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OptionsExpirationDates",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Date = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionsExpirationDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OptionsExpirationDates_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OptionsQuote",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Ask = table.Column<string>(nullable: true),
                    AskSize = table.Column<string>(nullable: true),
                    AverageDailyVolume10Day = table.Column<string>(nullable: true),
                    AverageDailyVolume3Month = table.Column<string>(nullable: true),
                    Bid = table.Column<string>(nullable: true),
                    BidSize = table.Column<string>(nullable: true),
                    BookValue = table.Column<string>(nullable: true),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    DividendDate = table.Column<string>(nullable: true),
                    EpsForward = table.Column<string>(nullable: true),
                    EpsTrailingTwelveMonths = table.Column<string>(nullable: true),
                    ExchangeId = table.Column<string>(nullable: true),
                    ExchangeName = table.Column<string>(nullable: true),
                    ExchangeTimezoneName = table.Column<string>(nullable: true),
                    ExchangeTimezoneShortName = table.Column<string>(nullable: true),
                    FiftyDayAverage = table.Column<string>(nullable: true),
                    FiftyDayAverageChange = table.Column<string>(nullable: true),
                    FiftyDayAverageChangePercent = table.Column<string>(nullable: true),
                    FiftyTwoWeekHigh = table.Column<string>(nullable: true),
                    FiftyTwoWeekHighChange = table.Column<string>(nullable: true),
                    FiftyTwoWeekHighChangePercent = table.Column<string>(nullable: true),
                    FiftyTwoWeekLow = table.Column<string>(nullable: true),
                    FiftyTwoWeekLowChange = table.Column<string>(nullable: true),
                    FiftyTwoWeekLowChangePercent = table.Column<string>(nullable: true),
                    ForwardPe = table.Column<string>(nullable: true),
                    FullExchangeName = table.Column<string>(nullable: true),
                    GmtOffSetMilliseconds = table.Column<string>(nullable: true),
                    LongName = table.Column<string>(nullable: true),
                    Market = table.Column<string>(nullable: true),
                    MarketCap = table.Column<string>(nullable: true),
                    MarketState = table.Column<string>(nullable: true),
                    MessageBoardId = table.Column<string>(nullable: true),
                    PostMarketChange = table.Column<string>(nullable: true),
                    PostMarketChangePercent = table.Column<string>(nullable: true),
                    PostMarketPrice = table.Column<string>(nullable: true),
                    PostMarketTime = table.Column<string>(nullable: true),
                    PriceHint = table.Column<string>(nullable: true),
                    PriceToBook = table.Column<string>(nullable: true),
                    QuoteSourceName = table.Column<string>(nullable: true),
                    QuoteType = table.Column<string>(nullable: true),
                    RegularMarketChange = table.Column<string>(nullable: true),
                    RegularMarketChangePercent = table.Column<string>(nullable: true),
                    RegularMarketDayHigh = table.Column<string>(nullable: true),
                    RegularMarketDayLow = table.Column<string>(nullable: true),
                    RegularMarketOpen = table.Column<string>(nullable: true),
                    RegularMarketPreviousClose = table.Column<string>(nullable: true),
                    RegularMarketPrice = table.Column<string>(nullable: true),
                    RegularMarketTime = table.Column<string>(nullable: true),
                    RegularMarketVolume = table.Column<string>(nullable: true),
                    SharesOutstanding = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    SourceInterval = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true),
                    TrailingAnnualDividendRate = table.Column<string>(nullable: true),
                    TrailingPe = table.Column<string>(nullable: true),
                    TwoHundredDayAverage = table.Column<string>(nullable: true),
                    TwoHundredDayAverageChange = table.Column<string>(nullable: true),
                    TwoHundredDayAverageChangePercent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionsQuote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OptionsQuote_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OptionsQuote_Exchange_ExchangeId",
                        column: x => x.ExchangeId,
                        principalTable: "Exchange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OptionsStrikes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Strike = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionsStrikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OptionsStrikes_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OptionsCalls_CompaniesId",
                table: "OptionsCalls",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionsExpirationDates_CompaniesId",
                table: "OptionsExpirationDates",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionsQuote_CompaniesId",
                table: "OptionsQuote",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionsQuote_ExchangeId",
                table: "OptionsQuote",
                column: "ExchangeId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionsStrikes_CompaniesId",
                table: "OptionsStrikes",
                column: "CompaniesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OptionsCalls");

            migrationBuilder.DropTable(
                name: "OptionsExpirationDates");

            migrationBuilder.DropTable(
                name: "OptionsQuote");

            migrationBuilder.DropTable(
                name: "OptionsStrikes");
        }
    }
}
