using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class FinancialData
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompaniesId { get; set; }
        public Companies Companies { get; set; }
        public string CurrentPrice { get; set; }
        public string TargetHighPrice { get; set; }
        public string TargetLowPrice { get; set; }
        public string TargetMeanPrice { get; set; }
        public string TargetMedianPrice { get; set; }
        public string RecommendationMean { get; set; }
        public string RecommendationKey { get; set; }
        public string NumberOfAnalystOpinions { get; set; }
        public string TotalCash { get; set; }
        public string TotalCashPerShare { get; set; }
        public string Ebitda { get; set; }
        public string TotalDebt { get; set; }
        public string QuickRatio { get; set; }
        public string CurrentRatio { get; set; }
        public string TotalRevenue { get; set; }
        public string DebtToEquity { get; set; }
        public string RevenuePerShare { get; set; }
        public string ReturnOnAssets { get; set; }
        public string ReturnOnEquity { get; set; }
        public string GrossProfits { get; set; }
        public string FreeCashflow { get; set; }
        public string OperatingCashflow { get; set; }
        public string EarningsGrowth { get; set; }
        public string RevenueGrowth { get; set; }
        public string GrossMargins { get; set; }
        public string EbitdaMargins { get; set; }
        public string OperatingMargins { get; set; }
        public string ProfitMargins { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
