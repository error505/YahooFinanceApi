using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class Estimates
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompaniesId { get; set; }
        public Companies Companies { get; set; }
        public string IndustryTrendId { get; set; }
        public IndustryTrend IndustryTrend { get; set; }
        public string IndexTrendId { get; set; }
        public IndexTrend IndexTrend { get; set; }
        public string SectorTrendId { get; set; }
        public SectorTrend SectorTrend { get; set; }
        public string Period { get; set; }
        public string Growth { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
