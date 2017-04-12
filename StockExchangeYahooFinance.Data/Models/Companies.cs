using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class Companies
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Key]
        public string Symbol { get; set; }

        public string Name { get; set; }

        public string SectorId { get; set; }

        public Sector Sector { get; set; }

        public string IndustryId { get; set; }

        public Industry Industry { get; set; }
    }
}
