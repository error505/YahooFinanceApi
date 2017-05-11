using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class InsiderTransactions
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompaniesId { get; set; }
        public Companies Companies { get; set; }
        public double Shares { get; set; }
        public double Value { get; set; }
        public string FilerUrl { get; set; }
        public string TransactionText { get; set; }
        public string FilerName { get; set; }
        public string FilerRelation { get; set; }
        public string MoneyText { get; set; }
        public string StartDate { get; set; }
        public string Ownership { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
