using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class CashflowStatement
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompaniesId { get; set; }
        public Companies Companies { get; set; }
        public string IndustryTrendId { get; set; }
        public string EndDate { get; set; }
        public string NetIncome { get; set; }
        public string Depreciation { get; set; }
        public string ChangeToNetincome { get; set; }
        public string ChangeToAccountReceivables { get; set; }
        public string ChangeToLiabilities { get; set; }
        public string ChangeToInventory { get; set; }
        public string ChangeToOperatingActivities { get; set; }
        public string TotalCashFromOperatingActivities { get; set; }
        public string CapitalExpenditures { get; set; }
        public string Investments { get; set; }
        public string OtherCashflowsFromInvestingActivities { get; set; }
        public string TotalCashflowsFromInvestingActivities { get; set; }
        public string DividendsPaid { get; set; }
        public string SalePurchaseOfStock { get; set; }
        public string NetBorrowings { get; set; }
        public string OtherCashflowsFromFinancingActivities { get; set; }
        public string TotalCashFromFinancingActivities { get; set; }
        public string EffectOfExchangeRate { get; set; }
        public string ChangeInCash { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
