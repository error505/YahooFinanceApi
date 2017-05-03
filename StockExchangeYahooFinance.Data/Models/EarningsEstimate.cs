using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class EarningsEstimate
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompaniesId { get; set; }
        public Companies Companies { get; set; }
        public string EarningsTrendId { get; set; }
        public EarningsTrend EarningsTrend { get; set; }
        public string Avg { get; set; }
        public string Low { get; set; }
        public string High { get; set; }
        public string YearAgoEps { get; set; }
        public string Growth { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
