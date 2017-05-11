using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using StockExchangeYahooFinance.DbContext;

namespace StockExchangeYahooFinance.Migrations
{
    [DbContext(typeof(YahooFinanceDbContext))]
    [Migration("20170511083703_FinancialDataCHange")]
    partial class FinancialDataCHange
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.BalanceSheetStatements", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountsPayable");

                    b.Property<string>("Cash");

                    b.Property<string>("CommonStock");

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("DeferredLongTermLiab");

                    b.Property<string>("EndDate");

                    b.Property<string>("GoodWill");

                    b.Property<string>("IntangibleAssets");

                    b.Property<string>("Inventory");

                    b.Property<string>("LongTermDebt");

                    b.Property<string>("LongTermInvestments");

                    b.Property<string>("NetReceivables");

                    b.Property<string>("NetTangibleAssets");

                    b.Property<string>("OtherAssets");

                    b.Property<string>("OtherCurrentAssets");

                    b.Property<string>("OtherCurrentLiab");

                    b.Property<string>("OtherLiab");

                    b.Property<string>("OtherStockholderEquity");

                    b.Property<string>("PropertyPlantEquipment");

                    b.Property<string>("RetainedEarnings");

                    b.Property<string>("ShortLongTermDebt");

                    b.Property<string>("ShortTermInvestments");

                    b.Property<string>("TotalAssets");

                    b.Property<string>("TotalCurrentAssets");

                    b.Property<string>("TotalCurrentLiabilities");

                    b.Property<string>("TotalLiab");

                    b.Property<string>("TotalStockholderEquity");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.ToTable("BalanceSheetStatements");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.CalendarEarnings", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CalendarEventsId");

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("EarningsAverage");

                    b.Property<string>("EarningsDate");

                    b.Property<string>("EarningsHigh");

                    b.Property<string>("EarningsLow");

                    b.Property<string>("RevenueAverage");

                    b.Property<string>("RevenueHigh");

                    b.Property<string>("RevenueLow");

                    b.HasKey("Id");

                    b.HasIndex("CalendarEventsId");

                    b.HasIndex("CompaniesId");

                    b.ToTable("CalendarEarnings");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.CalendarEvents", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("DividendDate");

                    b.Property<string>("ExDividendDate");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.ToTable("CalendarEvents");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.CashflowStatement", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CapitalExpenditures");

                    b.Property<string>("ChangeInCash");

                    b.Property<string>("ChangeToAccountReceivables");

                    b.Property<string>("ChangeToInventory");

                    b.Property<string>("ChangeToLiabilities");

                    b.Property<string>("ChangeToNetincome");

                    b.Property<string>("ChangeToOperatingActivities");

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Depreciation");

                    b.Property<string>("DividendsPaid");

                    b.Property<string>("EffectOfExchangeRate");

                    b.Property<string>("EndDate");

                    b.Property<string>("IndustryTrendId");

                    b.Property<string>("Investments");

                    b.Property<string>("NetBorrowings");

                    b.Property<string>("NetIncome");

                    b.Property<string>("OtherCashflowsFromFinancingActivities");

                    b.Property<string>("OtherCashflowsFromInvestingActivities");

                    b.Property<string>("SalePurchaseOfStock");

                    b.Property<string>("TotalCashFromFinancingActivities");

                    b.Property<string>("TotalCashFromOperatingActivities");

                    b.Property<string>("TotalCashflowsFromInvestingActivities");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.ToTable("CashflowStatement");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.Companies", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ADR_TSO");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("ExchangeId");

                    b.Property<string>("IPOyear");

                    b.Property<string>("IndustryId");

                    b.Property<string>("LastSale");

                    b.Property<string>("MarketCap");

                    b.Property<string>("Name");

                    b.Property<string>("RegionId");

                    b.Property<string>("SectorId");

                    b.Property<string>("Symbol");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ExchangeId");

                    b.HasIndex("IndustryId");

                    b.HasIndex("RegionId");

                    b.HasIndex("SectorId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.CompanyOfficers", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CompanyProfileId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<int>("ExercisedValue");

                    b.Property<string>("FiscalYear");

                    b.Property<int>("MaxAge");

                    b.Property<string>("Name");

                    b.Property<string>("Title");

                    b.Property<int>("TotalPay");

                    b.Property<int>("UnexercisedValue");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.HasIndex("CompanyProfileId");

                    b.ToTable("CompanyOfficers");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.CompanyProfile", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1");

                    b.Property<int>("AuditRisk");

                    b.Property<int>("BoardRisk");

                    b.Property<string>("City");

                    b.Property<string>("CompaniesId");

                    b.Property<int>("CompensationAsOfEpochDate");

                    b.Property<int>("CompensationRisk");

                    b.Property<string>("Country");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Fax");

                    b.Property<int>("FullTimeEmployees");

                    b.Property<int>("GovernanceEpochDate");

                    b.Property<string>("IndustryId");

                    b.Property<string>("IndustrySymbolId");

                    b.Property<string>("LongBusinessSummary");

                    b.Property<int>("OverallRisk");

                    b.Property<string>("Phone");

                    b.Property<string>("SectorId");

                    b.Property<int>("ShareHolderRightsRisk");

                    b.Property<string>("Website");

                    b.Property<string>("Zip");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.HasIndex("IndustryId");

                    b.HasIndex("IndustrySymbolId");

                    b.HasIndex("SectorId");

                    b.ToTable("CompanyProfile");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.Country", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CountryCode");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.Currencies", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Currency");

                    b.Property<string>("Entity");

                    b.Property<string>("MinorUnit");

                    b.Property<int>("NumericCode");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.DefaultKeyStatistics", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AnnualHoldingsTurnover");

                    b.Property<string>("AnnualReportExpenseRatio");

                    b.Property<string>("Beta");

                    b.Property<string>("Beta3Year");

                    b.Property<string>("BookValue");

                    b.Property<string>("Category");

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("EarningsQuarterlyGrowth");

                    b.Property<string>("EnterpriseToEbitda");

                    b.Property<string>("EnterpriseToRevenue");

                    b.Property<string>("EnterpriseValue");

                    b.Property<string>("FiftyTwoWeekChange");

                    b.Property<string>("FiveYearAverageReturn");

                    b.Property<string>("FloatShares");

                    b.Property<string>("ForwardEps");

                    b.Property<string>("ForwardPe");

                    b.Property<string>("FundFamily");

                    b.Property<string>("FundInceptionDate");

                    b.Property<string>("HeldPercentInsiders");

                    b.Property<string>("HeldPercentInstitutions");

                    b.Property<string>("LastCapGain");

                    b.Property<string>("LastDividendValue");

                    b.Property<string>("LastFiscalYearEnd");

                    b.Property<string>("LastSplitDate");

                    b.Property<string>("LastSplitFactor");

                    b.Property<string>("LegalType");

                    b.Property<string>("MorningStarOverallRating");

                    b.Property<string>("MorningStarRiskRating");

                    b.Property<string>("MostRecentQuarter");

                    b.Property<string>("NetIncomeToCommon");

                    b.Property<string>("NextFiscalYearEnd");

                    b.Property<string>("PegRatio");

                    b.Property<string>("PriceToBook");

                    b.Property<string>("PriceToSalesTrailing12Months");

                    b.Property<string>("ProfitMargins");

                    b.Property<string>("RevenueQuarterlyGrowth");

                    b.Property<string>("SandP52WeekChange");

                    b.Property<string>("SharesOutstanding");

                    b.Property<string>("SharesShort");

                    b.Property<string>("SharesShortPriorMonth");

                    b.Property<string>("ShortPercentOfFloat");

                    b.Property<string>("ShortRatio");

                    b.Property<string>("ThreeYearAverageReturn");

                    b.Property<string>("TotalAssets");

                    b.Property<string>("TrailingEps");

                    b.Property<string>("Yield");

                    b.Property<string>("YtdReturn");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.ToTable("DefaultKeyStatistics");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.Earnings", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.ToTable("Earnings");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.EarningsChartQuarterly", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Actual");

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CurrentQuarterEstimate");

                    b.Property<string>("CurrentQuarterEstimateDate");

                    b.Property<string>("CurrentQuarterEstimateYear");

                    b.Property<string>("Date");

                    b.Property<string>("EarningsId");

                    b.Property<string>("Estimate");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.HasIndex("EarningsId");

                    b.ToTable("EarningsChartQuarterly");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.EarningsEstimate", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Avg");

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("EarningsTrendId");

                    b.Property<string>("Growth");

                    b.Property<string>("High");

                    b.Property<string>("Low");

                    b.Property<string>("YearAgoEps");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.HasIndex("EarningsTrendId");

                    b.ToTable("EarningsEstimate");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.EarningsHistory", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("EpsActual");

                    b.Property<string>("EpsDifference");

                    b.Property<string>("EpsEstimate");

                    b.Property<string>("Period");

                    b.Property<string>("Quarter");

                    b.Property<string>("SurprisePercent");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.ToTable("EarningsHistory");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.EarningsTrend", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("EarningsEstimate");

                    b.Property<string>("EndDate");

                    b.Property<string>("Growth");

                    b.Property<string>("NumberOfAnalysts");

                    b.Property<string>("Period");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.ToTable("EarningsTrend");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.EpsRevisions", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("DownLast30Days");

                    b.Property<string>("DownLast90Days");

                    b.Property<string>("EarningsTrendId");

                    b.Property<string>("UpLast30Days");

                    b.Property<string>("UpLast7Days");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.HasIndex("EarningsTrendId");

                    b.ToTable("EpsRevisions");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.EpsTrend", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Current");

                    b.Property<string>("EarningsTrendId");

                    b.Property<string>("NinetyAgoRevenue");

                    b.Property<string>("SevenDaysAgo");

                    b.Property<string>("SixtydaysAgo");

                    b.Property<string>("ThirtydaysAgo");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.HasIndex("EarningsTrendId");

                    b.ToTable("EpsTrend");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.Estimates", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Growth");

                    b.Property<string>("IndexTrendId");

                    b.Property<string>("IndustryTrendId");

                    b.Property<string>("Period");

                    b.Property<string>("SectorTrendId");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.HasIndex("IndexTrendId");

                    b.HasIndex("IndustryTrendId");

                    b.HasIndex("SectorTrendId");

                    b.ToTable("Estimates");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.Exchange", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClosingTimeLocal");

                    b.Property<string>("CountryId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("DataProvider");

                    b.Property<string>("Delay");

                    b.Property<string>("Name");

                    b.Property<string>("OpeningTimeLocal");

                    b.Property<string>("RegionId");

                    b.Property<string>("StockExchangeId");

                    b.Property<string>("Suffix");

                    b.Property<string>("TradingDays");

                    b.Property<string>("UtcOffsetStandardTime");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("RegionId");

                    b.ToTable("Exchange");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.FinanceModel", b =>
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

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CurencyId");

                    b.Property<string>("CurrenciesId");

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

                    b.HasIndex("CompaniesId");

                    b.HasIndex("CurrenciesId");

                    b.ToTable("FinanceModel");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.FinancialData", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<double>("CurrentPrice");

                    b.Property<double>("CurrentRatio");

                    b.Property<double>("DebtToEquity");

                    b.Property<double>("EarningsGrowth");

                    b.Property<double>("Ebitda");

                    b.Property<double>("EbitdaMargins");

                    b.Property<double>("FreeCashflow");

                    b.Property<double>("GrossMargins");

                    b.Property<double>("GrossProfits");

                    b.Property<double>("NumberOfAnalystOpinions");

                    b.Property<double>("OperatingCashflow");

                    b.Property<double>("OperatingMargins");

                    b.Property<double>("ProfitMargins");

                    b.Property<double>("QuickRatio");

                    b.Property<string>("RecommendationKey");

                    b.Property<double>("RecommendationMean");

                    b.Property<double>("ReturnOnAssets");

                    b.Property<double>("ReturnOnEquity");

                    b.Property<double>("RevenueGrowth");

                    b.Property<double>("RevenuePerShare");

                    b.Property<double>("TargetHighPrice");

                    b.Property<double>("TargetLowPrice");

                    b.Property<double>("TargetMeanPrice");

                    b.Property<double>("TargetMedianPrice");

                    b.Property<double>("TotalCash");

                    b.Property<double>("TotalCashPerShare");

                    b.Property<double>("TotalDebt");

                    b.Property<double>("TotalRevenue");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.ToTable("FinancialData");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.FinancialsChartQuarterly", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Date");

                    b.Property<string>("Earning");

                    b.Property<string>("EarningsId");

                    b.Property<string>("Revenue");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.HasIndex("EarningsId");

                    b.ToTable("FinancialsChartQuarterly");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.FinancialsChartYearly", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Date");

                    b.Property<string>("Earning");

                    b.Property<string>("EarningsId");

                    b.Property<string>("Revenue");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.HasIndex("EarningsId");

                    b.ToTable("FinancialsChartYearly");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.FundOwnership", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Organization");

                    b.Property<string>("PctHeld");

                    b.Property<string>("Position");

                    b.Property<string>("ReportDate");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.ToTable("FundOwnership");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.History", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("AdjClose");

                    b.Property<double>("Close");

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Date");

                    b.Property<double>("High");

                    b.Property<double>("Low");

                    b.Property<double>("Open");

                    b.Property<double>("Volume");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.ToTable("History");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.IncomeStatementHistory", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CostOfRevenue");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("DiscontinuedOperations");

                    b.Property<string>("Ebit");

                    b.Property<string>("EffectOfAccountingCharges");

                    b.Property<string>("EndDate");

                    b.Property<string>("ExtraordinaryItems");

                    b.Property<string>("GrossProfit");

                    b.Property<string>("IncomeBeforeTax");

                    b.Property<string>("IncomeTaxExpense");

                    b.Property<string>("InterestExpense");

                    b.Property<string>("MinorityInterest");

                    b.Property<string>("NetIncome");

                    b.Property<string>("NetIncomeApplicableToCommonShares");

                    b.Property<string>("NetIncomeFromContinuingOps");

                    b.Property<string>("NonRecurring");

                    b.Property<string>("OperatingIncome");

                    b.Property<string>("OtherItems");

                    b.Property<string>("OtherOperatingExpenses");

                    b.Property<string>("ResearchDevelopment");

                    b.Property<string>("SellingGeneralAdministrative");

                    b.Property<string>("TotalOperatingExpenses");

                    b.Property<string>("TotalOtherIncomeExpenseNet");

                    b.Property<string>("TotalRevenue");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.ToTable("IncomeStatementHistory");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.IndexTrend", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("PeRatio");

                    b.Property<string>("PegRatio");

                    b.Property<string>("Symbol");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.ToTable("IndexTrend");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.Industry", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Industrie");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.IndustrySimbol", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("IndustryId");

                    b.Property<string>("Symbol");

                    b.HasKey("Id");

                    b.HasIndex("IndustryId");

                    b.ToTable("IndustrySimbol");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.IndustryTrend", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("PeRatio");

                    b.Property<string>("PegRatio");

                    b.Property<string>("Symbol");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.ToTable("IndustryTrend");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.InsiderHolders", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("LatestTransDate");

                    b.Property<string>("Name");

                    b.Property<string>("PositionDirect");

                    b.Property<string>("PositionDirectDate");

                    b.Property<string>("PositionIndirect");

                    b.Property<string>("PositionIndirectDate");

                    b.Property<string>("PositionSummary");

                    b.Property<string>("PositionSummaryDate");

                    b.Property<string>("Relation");

                    b.Property<string>("TransactionDescription");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.ToTable("InsiderHolders");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.InsiderTransactions", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("FilerName");

                    b.Property<string>("FilerRelation");

                    b.Property<string>("FilerUrl");

                    b.Property<string>("MoneyText");

                    b.Property<string>("Ownership");

                    b.Property<string>("Shares");

                    b.Property<string>("StartDate");

                    b.Property<string>("TransactionText");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.ToTable("InsiderTransactions");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.InstitutionOwnership", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Organization");

                    b.Property<double>("PctHeld");

                    b.Property<double>("Position");

                    b.Property<string>("ReportDate");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.ToTable("InstitutionOwnership");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.MajorDirectHolders", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("LatestTransDate");

                    b.Property<string>("Name");

                    b.Property<string>("PositionDirect");

                    b.Property<string>("PositionDirectDate");

                    b.Property<string>("PositionIndirect");

                    b.Property<string>("PositionIndirectDate");

                    b.Property<string>("PositionSummary");

                    b.Property<string>("PositionSummaryDate");

                    b.Property<string>("Relation");

                    b.Property<string>("TransactionDescription");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.ToTable("MajorDirectHolders");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.MajorHoldersBreakdown", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<double>("InsidersPercentHeld");

                    b.Property<int>("InstitutionsCount");

                    b.Property<double>("InstitutionsFloatPercentHeld");

                    b.Property<double>("InstitutionsPercentHeld");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.ToTable("MajorHoldersBreakdown");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.NetSharePurchaseActivity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BuyInfoCount");

                    b.Property<string>("BuyInfoShares");

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("NetInfoCount");

                    b.Property<string>("NetInfoShares");

                    b.Property<string>("NetInstBuyingPercent");

                    b.Property<string>("NetInstSharesBuying");

                    b.Property<string>("NetPercentInsiderShares");

                    b.Property<string>("Period");

                    b.Property<string>("SellInfoCount");

                    b.Property<string>("SellInfoShares");

                    b.Property<string>("SellPercentInsiderShares");

                    b.Property<string>("TotalInsiderShares");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.ToTable("NetSharePurchaseActivity");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.OptionsCalls", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ask");

                    b.Property<string>("Bid");

                    b.Property<string>("Change");

                    b.Property<string>("CompaniesId");

                    b.Property<string>("ContractSize");

                    b.Property<string>("ContractSymbol");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Currency");

                    b.Property<string>("Expiration");

                    b.Property<string>("ImpliedVolatility");

                    b.Property<string>("InTheMoney");

                    b.Property<string>("LastPrice");

                    b.Property<string>("OpenInterest");

                    b.Property<string>("PercentChange");

                    b.Property<string>("Strike");

                    b.Property<string>("Volume");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.ToTable("OptionsCalls");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.OptionsExpirationDates", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Date");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.ToTable("OptionsExpirationDates");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.OptionsQuote", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ask");

                    b.Property<string>("AskSize");

                    b.Property<string>("AverageDailyVolume10Day");

                    b.Property<string>("AverageDailyVolume3Month");

                    b.Property<string>("Bid");

                    b.Property<string>("BidSize");

                    b.Property<string>("BookValue");

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Currency");

                    b.Property<string>("DividendDate");

                    b.Property<string>("EpsForward");

                    b.Property<string>("EpsTrailingTwelveMonths");

                    b.Property<string>("ExchangeId");

                    b.Property<string>("ExchangeName");

                    b.Property<string>("ExchangeTimezoneName");

                    b.Property<string>("ExchangeTimezoneShortName");

                    b.Property<string>("FiftyDayAverage");

                    b.Property<string>("FiftyDayAverageChange");

                    b.Property<string>("FiftyDayAverageChangePercent");

                    b.Property<string>("FiftyTwoWeekHigh");

                    b.Property<string>("FiftyTwoWeekHighChange");

                    b.Property<string>("FiftyTwoWeekHighChangePercent");

                    b.Property<string>("FiftyTwoWeekLow");

                    b.Property<string>("FiftyTwoWeekLowChange");

                    b.Property<string>("FiftyTwoWeekLowChangePercent");

                    b.Property<string>("ForwardPe");

                    b.Property<string>("FullExchangeName");

                    b.Property<string>("GmtOffSetMilliseconds");

                    b.Property<string>("LongName");

                    b.Property<string>("Market");

                    b.Property<string>("MarketCap");

                    b.Property<string>("MarketState");

                    b.Property<string>("MessageBoardId");

                    b.Property<string>("PostMarketChange");

                    b.Property<string>("PostMarketChangePercent");

                    b.Property<string>("PostMarketPrice");

                    b.Property<string>("PostMarketTime");

                    b.Property<string>("PriceHint");

                    b.Property<string>("PriceToBook");

                    b.Property<string>("QuoteSourceName");

                    b.Property<string>("QuoteType");

                    b.Property<string>("RegularMarketChange");

                    b.Property<string>("RegularMarketChangePercent");

                    b.Property<string>("RegularMarketDayHigh");

                    b.Property<string>("RegularMarketDayLow");

                    b.Property<string>("RegularMarketOpen");

                    b.Property<string>("RegularMarketPreviousClose");

                    b.Property<string>("RegularMarketPrice");

                    b.Property<string>("RegularMarketTime");

                    b.Property<string>("RegularMarketVolume");

                    b.Property<string>("SharesOutstanding");

                    b.Property<string>("ShortName");

                    b.Property<string>("SourceInterval");

                    b.Property<string>("Symbol");

                    b.Property<string>("TrailingAnnualDividendRate");

                    b.Property<string>("TrailingPe");

                    b.Property<string>("TwoHundredDayAverage");

                    b.Property<string>("TwoHundredDayAverageChange");

                    b.Property<string>("TwoHundredDayAverageChangePercent");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.HasIndex("ExchangeId");

                    b.ToTable("OptionsQuote");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.OptionsStrikes", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<double>("Strike");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.ToTable("OptionsStrikes");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.RecommendationTrend", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Buy");

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<double>("Hold");

                    b.Property<string>("Period");

                    b.Property<double>("Sell");

                    b.Property<double>("StrongBuy");

                    b.Property<double>("StrongSell");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.ToTable("RecommendationTrend");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.Region", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.RevenueEstimate", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Avg");

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("EarningsTrendId");

                    b.Property<string>("Growth");

                    b.Property<string>("High");

                    b.Property<string>("Low");

                    b.Property<string>("NumberOfAnalysts");

                    b.Property<string>("YearAgoRevenue");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.HasIndex("EarningsTrendId");

                    b.ToTable("RevenueEstimate");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.Sector", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Sector");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.SectorTrend", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("PeRatio");

                    b.Property<string>("PegRatio");

                    b.Property<string>("Symbol");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.ToTable("SectorTrend");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.UpgradeDowngradeHistory", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<string>("CompaniesId");

                    b.Property<string>("CreatedByUser");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("EpochGradeDate");

                    b.Property<string>("Firm");

                    b.Property<string>("FromGrade");

                    b.Property<string>("ToGrade");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesId");

                    b.ToTable("UpgradeDowngradeHistory");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.BalanceSheetStatements", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.CalendarEarnings", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.CalendarEvents", "CalendarEvents")
                        .WithMany("Earnings")
                        .HasForeignKey("CalendarEventsId");

                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.CalendarEvents", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.CashflowStatement", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.Companies", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Exchange", "Exchange")
                        .WithMany()
                        .HasForeignKey("ExchangeId");

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

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.CompanyOfficers", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");

                    b.HasOne("StockExchangeYahooFinance.Data.Models.CompanyProfile", "CompanyProfile")
                        .WithMany("CompanyOfficers")
                        .HasForeignKey("CompanyProfileId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.CompanyProfile", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");

                    b.HasOne("StockExchangeYahooFinance.Data.Models.Industry", "Industry")
                        .WithMany()
                        .HasForeignKey("IndustryId");

                    b.HasOne("StockExchangeYahooFinance.Data.Models.IndustrySimbol", "IndustrySymbol")
                        .WithMany()
                        .HasForeignKey("IndustrySymbolId");

                    b.HasOne("StockExchangeYahooFinance.Data.Models.Sector", "Sector")
                        .WithMany()
                        .HasForeignKey("SectorId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.DefaultKeyStatistics", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.Earnings", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.EarningsChartQuarterly", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");

                    b.HasOne("StockExchangeYahooFinance.Data.Models.Earnings", "Earnings")
                        .WithMany()
                        .HasForeignKey("EarningsId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.EarningsEstimate", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");

                    b.HasOne("StockExchangeYahooFinance.Data.Models.EarningsTrend", "EarningsTrend")
                        .WithMany()
                        .HasForeignKey("EarningsTrendId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.EarningsHistory", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.EarningsTrend", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.EpsRevisions", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");

                    b.HasOne("StockExchangeYahooFinance.Data.Models.EarningsTrend", "EarningsTrend")
                        .WithMany()
                        .HasForeignKey("EarningsTrendId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.EpsTrend", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");

                    b.HasOne("StockExchangeYahooFinance.Data.Models.EarningsTrend", "EarningsTrend")
                        .WithMany()
                        .HasForeignKey("EarningsTrendId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.Estimates", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");

                    b.HasOne("StockExchangeYahooFinance.Data.Models.IndexTrend", "IndexTrend")
                        .WithMany("Estimateses")
                        .HasForeignKey("IndexTrendId");

                    b.HasOne("StockExchangeYahooFinance.Data.Models.IndustryTrend", "IndustryTrend")
                        .WithMany("Estimateses")
                        .HasForeignKey("IndustryTrendId");

                    b.HasOne("StockExchangeYahooFinance.Data.Models.SectorTrend", "SectorTrend")
                        .WithMany("Estimateses")
                        .HasForeignKey("SectorTrendId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.Exchange", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("StockExchangeYahooFinance.Data.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.FinanceModel", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");

                    b.HasOne("StockExchangeYahooFinance.Data.Models.Currencies", "Currencies")
                        .WithMany()
                        .HasForeignKey("CurrenciesId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.FinancialData", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.FinancialsChartQuarterly", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");

                    b.HasOne("StockExchangeYahooFinance.Data.Models.Earnings", "Earnings")
                        .WithMany()
                        .HasForeignKey("EarningsId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.FinancialsChartYearly", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");

                    b.HasOne("StockExchangeYahooFinance.Data.Models.Earnings", "Earnings")
                        .WithMany()
                        .HasForeignKey("EarningsId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.FundOwnership", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.History", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.IncomeStatementHistory", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.IndexTrend", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.IndustrySimbol", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Industry", "Industry")
                        .WithMany()
                        .HasForeignKey("IndustryId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.IndustryTrend", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.InsiderHolders", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.InsiderTransactions", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.InstitutionOwnership", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.MajorDirectHolders", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.MajorHoldersBreakdown", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.NetSharePurchaseActivity", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.OptionsCalls", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.OptionsExpirationDates", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.OptionsQuote", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");

                    b.HasOne("StockExchangeYahooFinance.Data.Models.Exchange", "Exchange")
                        .WithMany()
                        .HasForeignKey("ExchangeId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.OptionsStrikes", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.RecommendationTrend", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.RevenueEstimate", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");

                    b.HasOne("StockExchangeYahooFinance.Data.Models.EarningsTrend", "EarningsTrend")
                        .WithMany()
                        .HasForeignKey("EarningsTrendId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.SectorTrend", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");
                });

            modelBuilder.Entity("StockExchangeYahooFinance.Data.Models.UpgradeDowngradeHistory", b =>
                {
                    b.HasOne("StockExchangeYahooFinance.Data.Models.Companies", "Companies")
                        .WithMany()
                        .HasForeignKey("CompaniesId");
                });
        }
    }
}
