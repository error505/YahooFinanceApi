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
        public double EnterpriseValue { get; set; }
        public double ForwardPe { get; set; }
        public double ProfitMargins { get; set; }
        public double FloatShares { get; set; }
        public double SharesOutstanding { get; set; }
        public double SharesShort { get; set; }
        public double SharesShortPriorMonth { get; set; }
        public double HeldPercentInsiders { get; set; }
        public double HeldPercentInstitutions { get; set; }
        public double ShortRatio { get; set; }
        public double ShortPercentOfFloat { get; set; }
        public double Beta { get; set; }
        public double MorningStarOverallRating { get; set; }
        public double MorningStarRiskRating { get; set; }
        public string Category { get; set; }
        public double BookValue { get; set; }
        public double PriceToBook { get; set; }
        public double AnnualReportExpenseRatio { get; set; }
        public double YtdReturn { get; set; }
        public double Beta3Year { get; set; }
        public double TotalAssets { get; set; }
        public double Yield { get; set; }
        public string FundFamily { get; set; }
        public string FundInceptionDate { get; set; }
        public string LegalType { get; set; }
        public double ThreeYearAverageReturn { get; set; }
        public double FiveYearAverageReturn { get; set; }
        public double PriceToSalesTrailing12Months { get; set; }
        public string LastFiscalYearEnd { get; set; }
        public string NextFiscalYearEnd { get; set; }
        public string MostRecentQuarter { get; set; }
        public double EarningsQuarterlyGrowth { get; set; }
        public double RevenueQuarterlyGrowth { get; set; }
        public double NetIncomeToCommon { get; set; }
        public double TrailingEps { get; set; }
        public double ForwardEps { get; set; }
        public double PegRatio { get; set; }
        public string LastSplitFactor { get; set; }
        public string LastSplitDate { get; set; }
        public double EnterpriseToRevenue { get; set; }
        public double EnterpriseToEbitda { get; set; }
        public double FiftyTwoWeekChange { get; set; }
        public double SandP52WeekChange { get; set; }
        public double LastDividendValue { get; set; }
        public double LastCapGain { get; set; }
        public double AnnualHoldingsTurnover { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
