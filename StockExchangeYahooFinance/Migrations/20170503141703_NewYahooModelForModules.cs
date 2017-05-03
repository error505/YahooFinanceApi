using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockExchangeYahooFinance.Migrations
{
    public partial class NewYahooModelForModules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BalanceSheetStatements",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccountsPayable = table.Column<string>(nullable: true),
                    Cash = table.Column<string>(nullable: true),
                    CommonStock = table.Column<string>(nullable: true),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    DeferredLongTermLiab = table.Column<string>(nullable: true),
                    EndDate = table.Column<string>(nullable: true),
                    GoodWill = table.Column<string>(nullable: true),
                    IntangibleAssets = table.Column<string>(nullable: true),
                    Inventory = table.Column<string>(nullable: true),
                    LongTermDebt = table.Column<string>(nullable: true),
                    LongTermInvestments = table.Column<string>(nullable: true),
                    NetReceivables = table.Column<string>(nullable: true),
                    NetTangibleAssets = table.Column<string>(nullable: true),
                    OtherAssets = table.Column<string>(nullable: true),
                    OtherCurrentAssets = table.Column<string>(nullable: true),
                    OtherCurrentLiab = table.Column<string>(nullable: true),
                    OtherLiab = table.Column<string>(nullable: true),
                    OtherStockholderEquity = table.Column<string>(nullable: true),
                    PropertyPlantEquipment = table.Column<string>(nullable: true),
                    RetainedEarnings = table.Column<string>(nullable: true),
                    ShortLongTermDebt = table.Column<string>(nullable: true),
                    ShortTermInvestments = table.Column<string>(nullable: true),
                    TotalAssets = table.Column<string>(nullable: true),
                    TotalCurrentAssets = table.Column<string>(nullable: true),
                    TotalCurrentLiabilities = table.Column<string>(nullable: true),
                    TotalLiab = table.Column<string>(nullable: true),
                    TotalStockholderEquity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalanceSheetStatements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BalanceSheetStatements_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CalendarEvents",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    DividendDate = table.Column<string>(nullable: true),
                    ExDividendDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarEvents_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CashflowStatement",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CapitalExpenditures = table.Column<string>(nullable: true),
                    ChangeInCash = table.Column<string>(nullable: true),
                    ChangeToAccountReceivables = table.Column<string>(nullable: true),
                    ChangeToInventory = table.Column<string>(nullable: true),
                    ChangeToLiabilities = table.Column<string>(nullable: true),
                    ChangeToNetincome = table.Column<string>(nullable: true),
                    ChangeToOperatingActivities = table.Column<string>(nullable: true),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Depreciation = table.Column<string>(nullable: true),
                    DividendsPaid = table.Column<string>(nullable: true),
                    EffectOfExchangeRate = table.Column<string>(nullable: true),
                    EndDate = table.Column<string>(nullable: true),
                    IndustryTrendId = table.Column<string>(nullable: true),
                    Investments = table.Column<string>(nullable: true),
                    NetBorrowings = table.Column<string>(nullable: true),
                    NetIncome = table.Column<string>(nullable: true),
                    OtherCashflowsFromFinancingActivities = table.Column<string>(nullable: true),
                    OtherCashflowsFromInvestingActivities = table.Column<string>(nullable: true),
                    SalePurchaseOfStock = table.Column<string>(nullable: true),
                    TotalCashFromFinancingActivities = table.Column<string>(nullable: true),
                    TotalCashFromOperatingActivities = table.Column<string>(nullable: true),
                    TotalCashflowsFromInvestingActivities = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashflowStatement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashflowStatement_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DefaultKeyStatistics",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AnnualHoldingsTurnover = table.Column<string>(nullable: true),
                    AnnualReportExpenseRatio = table.Column<string>(nullable: true),
                    Beta = table.Column<string>(nullable: true),
                    Beta3Year = table.Column<string>(nullable: true),
                    BookValue = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    EarningsQuarterlyGrowth = table.Column<string>(nullable: true),
                    EnterpriseToEbitda = table.Column<string>(nullable: true),
                    EnterpriseToRevenue = table.Column<string>(nullable: true),
                    EnterpriseValue = table.Column<string>(nullable: true),
                    FiftyTwoWeekChange = table.Column<string>(nullable: true),
                    FiveYearAverageReturn = table.Column<string>(nullable: true),
                    FloatShares = table.Column<string>(nullable: true),
                    ForwardEps = table.Column<string>(nullable: true),
                    ForwardPe = table.Column<string>(nullable: true),
                    FundFamily = table.Column<string>(nullable: true),
                    FundInceptionDate = table.Column<string>(nullable: true),
                    HeldPercentInsiders = table.Column<string>(nullable: true),
                    HeldPercentInstitutions = table.Column<string>(nullable: true),
                    LastCapGain = table.Column<string>(nullable: true),
                    LastDividendValue = table.Column<string>(nullable: true),
                    LastFiscalYearEnd = table.Column<string>(nullable: true),
                    LastSplitDate = table.Column<string>(nullable: true),
                    LastSplitFactor = table.Column<string>(nullable: true),
                    LegalType = table.Column<string>(nullable: true),
                    MorningStarOverallRating = table.Column<string>(nullable: true),
                    MorningStarRiskRating = table.Column<string>(nullable: true),
                    MostRecentQuarter = table.Column<string>(nullable: true),
                    NetIncomeToCommon = table.Column<string>(nullable: true),
                    NextFiscalYearEnd = table.Column<string>(nullable: true),
                    PegRatio = table.Column<string>(nullable: true),
                    PriceToBook = table.Column<string>(nullable: true),
                    PriceToSalesTrailing12Months = table.Column<string>(nullable: true),
                    ProfitMargins = table.Column<string>(nullable: true),
                    RevenueQuarterlyGrowth = table.Column<string>(nullable: true),
                    SandP52WeekChange = table.Column<string>(nullable: true),
                    SharesOutstanding = table.Column<string>(nullable: true),
                    SharesShort = table.Column<string>(nullable: true),
                    SharesShortPriorMonth = table.Column<string>(nullable: true),
                    ShortPercentOfFloat = table.Column<string>(nullable: true),
                    ShortRatio = table.Column<string>(nullable: true),
                    ThreeYearAverageReturn = table.Column<string>(nullable: true),
                    TotalAssets = table.Column<string>(nullable: true),
                    TrailingEps = table.Column<string>(nullable: true),
                    Yield = table.Column<string>(nullable: true),
                    YtdReturn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultKeyStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefaultKeyStatistics_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Earnings",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Earnings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Earnings_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EarningsHistory",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    EpsActual = table.Column<string>(nullable: true),
                    EpsDifference = table.Column<string>(nullable: true),
                    EpsEstimate = table.Column<string>(nullable: true),
                    Period = table.Column<string>(nullable: true),
                    Quarter = table.Column<string>(nullable: true),
                    SurprisePercent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EarningsHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EarningsHistory_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EarningsTrend",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    EarningsEstimate = table.Column<string>(nullable: true),
                    EndDate = table.Column<string>(nullable: true),
                    Growth = table.Column<string>(nullable: true),
                    NumberOfAnalysts = table.Column<string>(nullable: true),
                    Period = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EarningsTrend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EarningsTrend_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FinancialData",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CurrentPrice = table.Column<string>(nullable: true),
                    CurrentRatio = table.Column<string>(nullable: true),
                    DebtToEquity = table.Column<string>(nullable: true),
                    EarningsGrowth = table.Column<string>(nullable: true),
                    Ebitda = table.Column<string>(nullable: true),
                    EbitdaMargins = table.Column<string>(nullable: true),
                    FreeCashflow = table.Column<string>(nullable: true),
                    GrossMargins = table.Column<string>(nullable: true),
                    GrossProfits = table.Column<string>(nullable: true),
                    NumberOfAnalystOpinions = table.Column<string>(nullable: true),
                    OperatingCashflow = table.Column<string>(nullable: true),
                    OperatingMargins = table.Column<string>(nullable: true),
                    ProfitMargins = table.Column<string>(nullable: true),
                    QuickRatio = table.Column<string>(nullable: true),
                    RecommendationKey = table.Column<string>(nullable: true),
                    RecommendationMean = table.Column<string>(nullable: true),
                    ReturnOnAssets = table.Column<string>(nullable: true),
                    ReturnOnEquity = table.Column<string>(nullable: true),
                    RevenueGrowth = table.Column<string>(nullable: true),
                    RevenuePerShare = table.Column<string>(nullable: true),
                    TargetHighPrice = table.Column<string>(nullable: true),
                    TargetLowPrice = table.Column<string>(nullable: true),
                    TargetMeanPrice = table.Column<string>(nullable: true),
                    TargetMedianPrice = table.Column<string>(nullable: true),
                    TotalCash = table.Column<string>(nullable: true),
                    TotalCashPerShare = table.Column<string>(nullable: true),
                    TotalDebt = table.Column<string>(nullable: true),
                    TotalRevenue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialData_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FundOwnership",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Organization = table.Column<string>(nullable: true),
                    PctHeld = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    ReportDate = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundOwnership", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundOwnership_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IncomeStatementHistory",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompaniesId = table.Column<string>(nullable: true),
                    CostOfRevenue = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    DiscontinuedOperations = table.Column<string>(nullable: true),
                    Ebit = table.Column<string>(nullable: true),
                    EffectOfAccountingCharges = table.Column<string>(nullable: true),
                    EndDate = table.Column<string>(nullable: true),
                    ExtraordinaryItems = table.Column<string>(nullable: true),
                    GrossProfit = table.Column<string>(nullable: true),
                    IncomeBeforeTax = table.Column<string>(nullable: true),
                    IncomeTaxExpense = table.Column<string>(nullable: true),
                    InterestExpense = table.Column<string>(nullable: true),
                    MinorityInterest = table.Column<string>(nullable: true),
                    NetIncome = table.Column<string>(nullable: true),
                    NetIncomeApplicableToCommonShares = table.Column<string>(nullable: true),
                    NetIncomeFromContinuingOps = table.Column<string>(nullable: true),
                    NonRecurring = table.Column<string>(nullable: true),
                    OperatingIncome = table.Column<string>(nullable: true),
                    OtherItems = table.Column<string>(nullable: true),
                    OtherOperatingExpenses = table.Column<string>(nullable: true),
                    ResearchDevelopment = table.Column<string>(nullable: true),
                    SellingGeneralAdministrative = table.Column<string>(nullable: true),
                    TotalOperatingExpenses = table.Column<string>(nullable: true),
                    TotalOtherIncomeExpenseNet = table.Column<string>(nullable: true),
                    TotalRevenue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeStatementHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeStatementHistory_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndexTrend",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    PeRatio = table.Column<string>(nullable: true),
                    PegRatio = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndexTrend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndexTrend_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndustryTrend",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    PeRatio = table.Column<string>(nullable: true),
                    PegRatio = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustryTrend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndustryTrend_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InsiderHolders",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LatestTransDate = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PositionDirect = table.Column<string>(nullable: true),
                    PositionDirectDate = table.Column<string>(nullable: true),
                    PositionIndirect = table.Column<string>(nullable: true),
                    PositionIndirectDate = table.Column<string>(nullable: true),
                    PositionSummary = table.Column<string>(nullable: true),
                    PositionSummaryDate = table.Column<string>(nullable: true),
                    Relation = table.Column<string>(nullable: true),
                    TransactionDescription = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsiderHolders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsiderHolders_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InsiderTransactions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    FilerName = table.Column<string>(nullable: true),
                    FilerRelation = table.Column<string>(nullable: true),
                    FilerUrl = table.Column<string>(nullable: true),
                    MoneyText = table.Column<string>(nullable: true),
                    Ownership = table.Column<string>(nullable: true),
                    Shares = table.Column<string>(nullable: true),
                    StartDate = table.Column<string>(nullable: true),
                    TransactionText = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsiderTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsiderTransactions_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstitutionOwnership",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Organization = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    ReportDate = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitutionOwnership", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstitutionOwnership_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MajorDirectHolders",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LatestTransDate = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PositionDirect = table.Column<string>(nullable: true),
                    PositionDirectDate = table.Column<string>(nullable: true),
                    PositionIndirect = table.Column<string>(nullable: true),
                    PositionIndirectDate = table.Column<string>(nullable: true),
                    PositionSummary = table.Column<string>(nullable: true),
                    PositionSummaryDate = table.Column<string>(nullable: true),
                    Relation = table.Column<string>(nullable: true),
                    TransactionDescription = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MajorDirectHolders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MajorDirectHolders_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MajorHoldersBreakdown",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    InsidersPercentHeld = table.Column<string>(nullable: true),
                    InstitutionsCount = table.Column<string>(nullable: true),
                    InstitutionsFloatPercentHeld = table.Column<string>(nullable: true),
                    InstitutionsPercentHeld = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MajorHoldersBreakdown", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MajorHoldersBreakdown_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NetSharePurchaseActivity",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BuyInfoCount = table.Column<string>(nullable: true),
                    BuyInfoShares = table.Column<string>(nullable: true),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    NetInfoCount = table.Column<string>(nullable: true),
                    NetInfoShares = table.Column<string>(nullable: true),
                    NetInstBuyingPercent = table.Column<string>(nullable: true),
                    NetInstSharesBuying = table.Column<string>(nullable: true),
                    NetPercentInsiderShares = table.Column<string>(nullable: true),
                    Period = table.Column<string>(nullable: true),
                    SellInfoCount = table.Column<string>(nullable: true),
                    SellInfoShares = table.Column<string>(nullable: true),
                    SellPercentInsiderShares = table.Column<string>(nullable: true),
                    TotalInsiderShares = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetSharePurchaseActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NetSharePurchaseActivity_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecommendationTrend",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Buy = table.Column<string>(nullable: true),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Hold = table.Column<string>(nullable: true),
                    Period = table.Column<string>(nullable: true),
                    Sell = table.Column<string>(nullable: true),
                    StrongBuy = table.Column<string>(nullable: true),
                    StrongSell = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommendationTrend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecommendationTrend_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SectorTrend",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    PeRatio = table.Column<string>(nullable: true),
                    PegRatio = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectorTrend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectorTrend_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UpgradeDowngradeHistory",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Action = table.Column<string>(nullable: true),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    EpochGradeDate = table.Column<string>(nullable: true),
                    Firm = table.Column<string>(nullable: true),
                    FromGrade = table.Column<string>(nullable: true),
                    ToGrade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpgradeDowngradeHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UpgradeDowngradeHistory_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CalendarEarnings",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CalendarEventsId = table.Column<string>(nullable: true),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    EarningsAverage = table.Column<string>(nullable: true),
                    EarningsDate = table.Column<string>(nullable: true),
                    EarningsHigh = table.Column<string>(nullable: true),
                    EarningsLow = table.Column<string>(nullable: true),
                    RevenueAverage = table.Column<string>(nullable: true),
                    RevenueHigh = table.Column<string>(nullable: true),
                    RevenueLow = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarEarnings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarEarnings_CalendarEvents_CalendarEventsId",
                        column: x => x.CalendarEventsId,
                        principalTable: "CalendarEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CalendarEarnings_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EarningsChartQuarterly",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Actual = table.Column<string>(nullable: true),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CurrentQuarterEstimate = table.Column<string>(nullable: true),
                    CurrentQuarterEstimateDate = table.Column<string>(nullable: true),
                    CurrentQuarterEstimateYear = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    EarningsId = table.Column<string>(nullable: true),
                    Estimate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EarningsChartQuarterly", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EarningsChartQuarterly_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EarningsChartQuarterly_Earnings_EarningsId",
                        column: x => x.EarningsId,
                        principalTable: "Earnings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FinancialsChartQuarterly",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Earning = table.Column<string>(nullable: true),
                    EarningsId = table.Column<string>(nullable: true),
                    Revenue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialsChartQuarterly", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialsChartQuarterly_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FinancialsChartQuarterly_Earnings_EarningsId",
                        column: x => x.EarningsId,
                        principalTable: "Earnings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FinancialsChartYearly",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Earning = table.Column<string>(nullable: true),
                    EarningsId = table.Column<string>(nullable: true),
                    Revenue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialsChartYearly", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialsChartYearly_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FinancialsChartYearly_Earnings_EarningsId",
                        column: x => x.EarningsId,
                        principalTable: "Earnings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EarningsEstimate",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Avg = table.Column<string>(nullable: true),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    EarningsTrendId = table.Column<string>(nullable: true),
                    Growth = table.Column<string>(nullable: true),
                    High = table.Column<string>(nullable: true),
                    Low = table.Column<string>(nullable: true),
                    YearAgoEps = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EarningsEstimate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EarningsEstimate_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EarningsEstimate_EarningsTrend_EarningsTrendId",
                        column: x => x.EarningsTrendId,
                        principalTable: "EarningsTrend",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EpsRevisions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    DownLast30Days = table.Column<string>(nullable: true),
                    DownLast90Days = table.Column<string>(nullable: true),
                    EarningsTrendId = table.Column<string>(nullable: true),
                    UpLast30Days = table.Column<string>(nullable: true),
                    UpLast7Days = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpsRevisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EpsRevisions_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EpsRevisions_EarningsTrend_EarningsTrendId",
                        column: x => x.EarningsTrendId,
                        principalTable: "EarningsTrend",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EpsTrend",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Current = table.Column<string>(nullable: true),
                    EarningsTrendId = table.Column<string>(nullable: true),
                    NinetyAgoRevenue = table.Column<string>(nullable: true),
                    SevenDaysAgo = table.Column<string>(nullable: true),
                    SixtydaysAgo = table.Column<string>(nullable: true),
                    ThirtydaysAgo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpsTrend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EpsTrend_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EpsTrend_EarningsTrend_EarningsTrendId",
                        column: x => x.EarningsTrendId,
                        principalTable: "EarningsTrend",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RevenueEstimate",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Avg = table.Column<string>(nullable: true),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    EarningsTrendId = table.Column<string>(nullable: true),
                    Growth = table.Column<string>(nullable: true),
                    High = table.Column<string>(nullable: true),
                    Low = table.Column<string>(nullable: true),
                    NumberOfAnalysts = table.Column<string>(nullable: true),
                    YearAgoRevenue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueEstimate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RevenueEstimate_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RevenueEstimate_EarningsTrend_EarningsTrendId",
                        column: x => x.EarningsTrendId,
                        principalTable: "EarningsTrend",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estimates",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompaniesId = table.Column<string>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Growth = table.Column<string>(nullable: true),
                    IndexTrendId = table.Column<string>(nullable: true),
                    IndustryTrendId = table.Column<string>(nullable: true),
                    Period = table.Column<string>(nullable: true),
                    SectorTrendId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estimates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estimates_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estimates_IndexTrend_IndexTrendId",
                        column: x => x.IndexTrendId,
                        principalTable: "IndexTrend",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estimates_IndustryTrend_IndustryTrendId",
                        column: x => x.IndustryTrendId,
                        principalTable: "IndustryTrend",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estimates_SectorTrend_SectorTrendId",
                        column: x => x.SectorTrendId,
                        principalTable: "SectorTrend",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BalanceSheetStatements_CompaniesId",
                table: "BalanceSheetStatements",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEarnings_CalendarEventsId",
                table: "CalendarEarnings",
                column: "CalendarEventsId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEarnings_CompaniesId",
                table: "CalendarEarnings",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEvents_CompaniesId",
                table: "CalendarEvents",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_CashflowStatement_CompaniesId",
                table: "CashflowStatement",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultKeyStatistics_CompaniesId",
                table: "DefaultKeyStatistics",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_Earnings_CompaniesId",
                table: "Earnings",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_EarningsChartQuarterly_CompaniesId",
                table: "EarningsChartQuarterly",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_EarningsChartQuarterly_EarningsId",
                table: "EarningsChartQuarterly",
                column: "EarningsId");

            migrationBuilder.CreateIndex(
                name: "IX_EarningsEstimate_CompaniesId",
                table: "EarningsEstimate",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_EarningsEstimate_EarningsTrendId",
                table: "EarningsEstimate",
                column: "EarningsTrendId");

            migrationBuilder.CreateIndex(
                name: "IX_EarningsHistory_CompaniesId",
                table: "EarningsHistory",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_EarningsTrend_CompaniesId",
                table: "EarningsTrend",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_EpsRevisions_CompaniesId",
                table: "EpsRevisions",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_EpsRevisions_EarningsTrendId",
                table: "EpsRevisions",
                column: "EarningsTrendId");

            migrationBuilder.CreateIndex(
                name: "IX_EpsTrend_CompaniesId",
                table: "EpsTrend",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_EpsTrend_EarningsTrendId",
                table: "EpsTrend",
                column: "EarningsTrendId");

            migrationBuilder.CreateIndex(
                name: "IX_Estimates_CompaniesId",
                table: "Estimates",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_Estimates_IndexTrendId",
                table: "Estimates",
                column: "IndexTrendId");

            migrationBuilder.CreateIndex(
                name: "IX_Estimates_IndustryTrendId",
                table: "Estimates",
                column: "IndustryTrendId");

            migrationBuilder.CreateIndex(
                name: "IX_Estimates_SectorTrendId",
                table: "Estimates",
                column: "SectorTrendId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialData_CompaniesId",
                table: "FinancialData",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialsChartQuarterly_CompaniesId",
                table: "FinancialsChartQuarterly",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialsChartQuarterly_EarningsId",
                table: "FinancialsChartQuarterly",
                column: "EarningsId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialsChartYearly_CompaniesId",
                table: "FinancialsChartYearly",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialsChartYearly_EarningsId",
                table: "FinancialsChartYearly",
                column: "EarningsId");

            migrationBuilder.CreateIndex(
                name: "IX_FundOwnership_CompaniesId",
                table: "FundOwnership",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeStatementHistory_CompaniesId",
                table: "IncomeStatementHistory",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_IndexTrend_CompaniesId",
                table: "IndexTrend",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_IndustryTrend_CompaniesId",
                table: "IndustryTrend",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_InsiderHolders_CompaniesId",
                table: "InsiderHolders",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_InsiderTransactions_CompaniesId",
                table: "InsiderTransactions",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_InstitutionOwnership_CompaniesId",
                table: "InstitutionOwnership",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_MajorDirectHolders_CompaniesId",
                table: "MajorDirectHolders",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_MajorHoldersBreakdown_CompaniesId",
                table: "MajorHoldersBreakdown",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_NetSharePurchaseActivity_CompaniesId",
                table: "NetSharePurchaseActivity",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendationTrend_CompaniesId",
                table: "RecommendationTrend",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_RevenueEstimate_CompaniesId",
                table: "RevenueEstimate",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_RevenueEstimate_EarningsTrendId",
                table: "RevenueEstimate",
                column: "EarningsTrendId");

            migrationBuilder.CreateIndex(
                name: "IX_SectorTrend_CompaniesId",
                table: "SectorTrend",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_UpgradeDowngradeHistory_CompaniesId",
                table: "UpgradeDowngradeHistory",
                column: "CompaniesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BalanceSheetStatements");

            migrationBuilder.DropTable(
                name: "CalendarEarnings");

            migrationBuilder.DropTable(
                name: "CashflowStatement");

            migrationBuilder.DropTable(
                name: "DefaultKeyStatistics");

            migrationBuilder.DropTable(
                name: "EarningsChartQuarterly");

            migrationBuilder.DropTable(
                name: "EarningsEstimate");

            migrationBuilder.DropTable(
                name: "EarningsHistory");

            migrationBuilder.DropTable(
                name: "EpsRevisions");

            migrationBuilder.DropTable(
                name: "EpsTrend");

            migrationBuilder.DropTable(
                name: "Estimates");

            migrationBuilder.DropTable(
                name: "FinancialData");

            migrationBuilder.DropTable(
                name: "FinancialsChartQuarterly");

            migrationBuilder.DropTable(
                name: "FinancialsChartYearly");

            migrationBuilder.DropTable(
                name: "FundOwnership");

            migrationBuilder.DropTable(
                name: "IncomeStatementHistory");

            migrationBuilder.DropTable(
                name: "InsiderHolders");

            migrationBuilder.DropTable(
                name: "InsiderTransactions");

            migrationBuilder.DropTable(
                name: "InstitutionOwnership");

            migrationBuilder.DropTable(
                name: "MajorDirectHolders");

            migrationBuilder.DropTable(
                name: "MajorHoldersBreakdown");

            migrationBuilder.DropTable(
                name: "NetSharePurchaseActivity");

            migrationBuilder.DropTable(
                name: "RecommendationTrend");

            migrationBuilder.DropTable(
                name: "RevenueEstimate");

            migrationBuilder.DropTable(
                name: "UpgradeDowngradeHistory");

            migrationBuilder.DropTable(
                name: "CalendarEvents");

            migrationBuilder.DropTable(
                name: "IndexTrend");

            migrationBuilder.DropTable(
                name: "IndustryTrend");

            migrationBuilder.DropTable(
                name: "SectorTrend");

            migrationBuilder.DropTable(
                name: "Earnings");

            migrationBuilder.DropTable(
                name: "EarningsTrend");
        }
    }
}
