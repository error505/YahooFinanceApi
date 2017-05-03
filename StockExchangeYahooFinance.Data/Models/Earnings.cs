using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class Earnings
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompaniesId { get; set; }
        ICollection<EarningsChartQuarterly> ChartQuarterlies { get; set; }
        ICollection<FinancialsChartQuarterly> FinancialsChartQuarterly { get; set; }
        ICollection<FinancialsChartYearly> FinancialsChartYearly { get; set; }
        public Companies Companies { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
