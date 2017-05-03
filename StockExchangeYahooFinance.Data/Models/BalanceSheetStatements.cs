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
        public string Cash { get; set; }
        public string ShortTermInvestments { get; set; }
        public string NetReceivables { get; set; }
        public string Inventory { get; set; }
        public string OtherCurrentAssets { get; set; }
        public string TotalCurrentAssets { get; set; }
        public string LongTermInvestments { get; set; }
        public string PropertyPlantEquipment { get; set; }
        public string GoodWill { get; set; }
        public string IntangibleAssets { get; set; }
        public string OtherAssets { get; set; }
        public string TotalAssets { get; set; }
        public string AccountsPayable { get; set; }
        public string ShortLongTermDebt { get; set; }
        public string OtherCurrentLiab { get; set; }
        public string LongTermDebt { get; set; }
        public string OtherLiab { get; set; }
        public string DeferredLongTermLiab { get; set; }
        public string TotalCurrentLiabilities { get; set; }
        public string TotalLiab { get; set; }
        public string CommonStock { get; set; }
        public string RetainedEarnings { get; set; }
        public string OtherStockholderEquity { get; set; }
        public string TotalStockholderEquity { get; set; }
        public string NetTangibleAssets { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
