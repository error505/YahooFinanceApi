using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class IndustrySimbol
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Symbol { get; set; }
        public string IndustryId { get; set; }
        public Industry Industry { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
