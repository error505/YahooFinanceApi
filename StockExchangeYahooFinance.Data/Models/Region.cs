using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class Region
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Index(IsUnique = true)]
        public string Name { get; set; }
    }
}
