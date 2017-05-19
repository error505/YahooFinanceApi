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
        public double BuyInfoCount { get; set; }
        public double BuyInfoShares { get; set; }
        public double SellInfoCount { get; set; }
        public double SellInfoShares { get; set; }
        public double SellPercentInsiderShares { get; set; }
        public double NetInfoCount { get; set; }
        public double NetInfoShares { get; set; }
        public double NetPercentInsiderShares { get; set; }
        public double NetInstSharesBuying { get; set; }
        public double NetInstBuyingPercent { get; set; }
        public double TotalInsiderShares { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
