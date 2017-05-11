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
        public double CurrentPrice { get; set; }
        public double TargetHighPrice { get; set; }
        public double TargetLowPrice { get; set; }
        public double TargetMeanPrice { get; set; }
        public double TargetMedianPrice { get; set; }
        public double RecommendationMean { get; set; }
        public string RecommendationKey { get; set; }
        public double NumberOfAnalystOpinions { get; set; }
        public double TotalCash { get; set; }
        public double TotalCashPerShare { get; set; }
        public double Ebitda { get; set; }
        public double TotalDebt { get; set; }
        public double QuickRatio { get; set; }
        public double CurrentRatio { get; set; }
        public double TotalRevenue { get; set; }
        public double DebtToEquity { get; set; }
        public double RevenuePerShare { get; set; }
        public double ReturnOnAssets { get; set; }
        public double ReturnOnEquity { get; set; }
        public double GrossProfits { get; set; }
        public double FreeCashflow { get; set; }
        public double OperatingCashflow { get; set; }
        public double EarningsGrowth { get; set; }
        public double RevenueGrowth { get; set; }
        public double GrossMargins { get; set; }
        public double EbitdaMargins { get; set; }
        public double OperatingMargins { get; set; }
        public double ProfitMargins { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
