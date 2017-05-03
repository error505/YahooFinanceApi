using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Helpers
{
    public class YahooModules
    {
        //Separated with ,
        //TODO: Create model for each modul and create apirequest services
        public string UpgradeDowngradeHistory = "upgradeDowngradeHistory";
        public string RecommendationTrend = "recommendationTrend";
        public string FinancialData = "financialData";
        public string EarningsHistory = "earningsHistory";
        public string EarningsTrend = "earningsTrend";
        public string IndustryTrend = "industryTrend";
        public string AssetProfile = "assetProfile";
        public string SecFilings = "secFilings";
        public string InstitutionOwnership = "institutionOwnership";
        public string FundOwnership = "fundOwnership";
        public string MajorDirectHolders = "majorDirectHolders";
        public string MajorHoldersBreakdown = "majorHoldersBreakdown";
        public string InsiderTransactions = "insiderTransactions";
        public string InsiderHolders = "insiderHolders";
        public string NetSharePurchaseActivity = "netSharePurchaseActivity";
        public string IndexTrend = "indexTrend";
        public string SectorTrend = "sectorTrend";
        public string IncomeStatementHistory = "incomeStatementHistory";
        public string CashflowStatementHistory = "cashflowStatementHistory";
        public string BalanceSheetHistory = "balanceSheetHistory";
        public string IncomeStatementHistoryQuarterly = "incomeStatementHistoryQuarterly";
        public string CashflowStatementHistoryQuarterly = "cashflowStatementHistoryQuarterly";
        public string BalanceSheetHistoryQuarterly = "balanceSheetHistoryQuarterly";
        public string SummaryProfile = "summaryProfile";
        public string Earnings = "earnings";
        public string DefaultKeyStatistics = "defaultKeyStatistics";
        public string CalendarEvents = "calendarEvents";
    }
}
