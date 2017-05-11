using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class BalanceSheetStatements
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompaniesId { get; set; }
        public Companies Companies { get; set; }
        public string EndDate { get; set; }
        public double Cash { get; set; }
        public double ShortTermInvestments { get; set; }
        public double NetReceivables { get; set; }
        public double Inventory { get; set; }
        public double OtherCurrentAssets { get; set; }
        public double TotalCurrentAssets { get; set; }
        public double LongTermInvestments { get; set; }
        public double PropertyPlantEquipment { get; set; }
        public double GoodWill { get; set; }
        public double IntangibleAssets { get; set; }
        public double OtherAssets { get; set; }
        public double TotalAssets { get; set; }
        public double AccountsPayable { get; set; }
        public double ShortLongTermDebt { get; set; }
        public double OtherCurrentLiab { get; set; }
        public double LongTermDebt { get; set; }
        public double OtherLiab { get; set; }
        public double DeferredLongTermLiab { get; set; }
        public double TotalCurrentLiabilities { get; set; }
        public double TotalLiab { get; set; }
        public double CommonStock { get; set; }
        public double RetainedEarnings { get; set; }
        public double OtherStockholderEquity { get; set; }
        public double TotalStockholderEquity { get; set; }
        public double NetTangibleAssets { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
