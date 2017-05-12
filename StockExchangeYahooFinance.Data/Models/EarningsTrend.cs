using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class EarningsTrend
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompaniesId { get; set; }
        public Companies Companies { get; set; }
        public string Period { get; set; }
        public string EndDate { get; set; }
        public double Growth { get; set; }

        public string EarningsEstimateId { get; set; }
        public EarningsEstimate EarningsEstimate { get; set; }

        public string RevenueEstimateId { get; set; }
        public RevenueEstimate RevenueEstimate { get; set; }

        public string EpsTrendId { get; set; }
        public EpsTrend EpsTrend { get; set; }

        public string EpsRevisionsId { get; set; }
        public EpsRevisions EpsRevisions { get; set; }
        public string NumberOfAnalysts { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
