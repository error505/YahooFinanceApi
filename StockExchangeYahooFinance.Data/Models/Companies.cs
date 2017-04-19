using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class Companies
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        public string Symbol { get; set; }

        public string Name { get; set; }

        public string SectorId { get; set; }

        public Sector Sector { get; set; }

        public string IndustryId { get; set; }

        public Industry Industry { get; set; }

        public string RegionId { get; set; }

        public Region Region { get; set; }

        public string IPOyear { get; set; }

        public string ADR_TSO { get; set; }

        public string MarketCap { get; set; }

        public string LastSale { get; set; }

        public string ExchangeId { get; set; }

        public Exchange Exchange { get; set; }

        public string Type { get; set; }

    }
}
