using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class EpsTrend
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompaniesId { get; set; }
        public Companies Companies { get; set; }
        public string EarningsTrendId { get; set; }
        public EarningsTrend EarningsTrend { get; set; }
        public string Current { get; set; }
        public string SevenDaysAgo { get; set; }
        public string ThirtydaysAgo { get; set; }
        public string SixtydaysAgo { get; set; }
        public string NinetyAgoRevenue { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
