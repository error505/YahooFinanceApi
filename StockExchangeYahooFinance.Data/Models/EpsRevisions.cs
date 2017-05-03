using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class EpsRevisions
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompaniesId { get; set; }
        public Companies Companies { get; set; }
        public string EarningsTrendId { get; set; }
        public EarningsTrend EarningsTrend { get; set; }
        public string UpLast7Days { get; set; }
        public string UpLast30Days { get; set; }
        public string DownLast30Days { get; set; }
        public string DownLast90Days { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
