using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class DefaultKeyStatistics
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompaniesId { get; set; }
        public Companies Companies { get; set; }
        public string EnterpriseValue { get; set; }
        public string ForwardPe { get; set; }
        public string ProfitMargins { get; set; }
        public string FloatShares { get; set; }
        public string SharesOutstanding { get; set; }
        public string SharesShort { get; set; }
        public string SharesShortPriorMonth { get; set; }
        public string HeldPercentInsiders { get; set; }
        public string HeldPercentInstitutions { get; set; }
        public string ShortRatio { get; set; }
        public string ShortPercentOfFloat { get; set; }
        public string Beta { get; set; }
        public string MorningStarOverallRating { get; set; }
        public string MorningStarRiskRating { get; set; }
        public string Category { get; set; }
        public string BookValue { get; set; }
        public string PriceToBook { get; set; }
        public string AnnualReportExpenseRatio { get; set; }
        public string YtdReturn { get; set; }
        public string Beta3Year { get; set; }
        public string TotalAssets { get; set; }
        public string Yield { get; set; }
        public string FundFamily { get; set; }
        public string FundInceptionDate { get; set; }
        public string LegalType { get; set; }
        public string ThreeYearAverageReturn { get; set; }
        public string FiveYearAverageReturn { get; set; }
        public string PriceToSalesTrailing12Months { get; set; }
        public string LastFiscalYearEnd { get; set; }
        public string NextFiscalYearEnd { get; set; }
        public string MostRecentQuarter { get; set; }
        public string EarningsQuarterlyGrowth { get; set; }
        public string RevenueQuarterlyGrowth { get; set; }
        public string NetIncomeToCommon { get; set; }
        public string TrailingEps { get; set; }
        public string ForwardEps { get; set; }
        public string PegRatio { get; set; }
        public string LastSplitFactor { get; set; }
        public string LastSplitDate { get; set; }
        public string EnterpriseToRevenue { get; set; }
        public string EnterpriseToEbitda { get; set; }
        public string FiftyTwoWeekChange { get; set; }
        public string SandP52WeekChange { get; set; }
        public string LastDividendValue { get; set; }
        public string LastCapGain { get; set; }
        public string AnnualHoldingsTurnover { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
