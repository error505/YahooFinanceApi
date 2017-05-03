using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class NetSharePurchaseActivity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompaniesId { get; set; }
        public Companies Companies { get; set; }
        public string Period { get; set; }
        public string BuyInfoCount { get; set; }
        public string BuyInfoShares { get; set; }
        public string SellInfoCount { get; set; }
        public string SellInfoShares { get; set; }
        public string SellPercentInsiderShares { get; set; }
        public string NetInfoCount { get; set; }
        public string NetInfoShares { get; set; }
        public string NetPercentInsiderShares { get; set; }
        public string NetInstSharesBuying { get; set; }
        public string NetInstBuyingPercent { get; set; }
        public string TotalInsiderShares { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
