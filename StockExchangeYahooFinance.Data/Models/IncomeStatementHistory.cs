using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class IncomeStatementHistory
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompaniesId { get; set; }
        public Companies Companies { get; set; }
        public string EndDate { get; set; }
        public string TotalRevenue { get; set; }
        public string CostOfRevenue { get; set; }
        public string GrossProfit { get; set; }
        public string ResearchDevelopment { get; set; }
        public string SellingGeneralAdministrative { get; set; }
        public string NonRecurring { get; set; }
        public string OtherOperatingExpenses { get; set; }
        public string TotalOperatingExpenses { get; set; }
        public string OperatingIncome { get; set; }
        public string TotalOtherIncomeExpenseNet { get; set; }
        public string Ebit { get; set; }
        public string InterestExpense { get; set; }
        public string IncomeBeforeTax { get; set; }
        public string IncomeTaxExpense { get; set; }
        public string MinorityInterest { get; set; }
        public string NetIncomeFromContinuingOps { get; set; }
        public string DiscontinuedOperations { get; set; }
        public string ExtraordinaryItems { get; set; }
        public string EffectOfAccountingCharges { get; set; }
        public string OtherItems { get; set; }
        public string NetIncome { get; set; }
        public string NetIncomeApplicableToCommonShares { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
