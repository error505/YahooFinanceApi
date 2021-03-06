﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class MajorDirectHolders
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompaniesId { get; set; }
        public Companies Companies { get; set; }
        public string Name { get; set; }
        public string Relation { get; set; }
        public string Url { get; set; }
        public string TransactionDescription { get; set; }
        public string LatestTransDate { get; set; }
        public double PositionDirect { get; set; }
        public string PositionDirectDate { get; set; }
        public double PositionIndirect { get; set; }
        public string PositionIndirectDate { get; set; }
        public double PositionSummary { get; set; }
        public string PositionSummaryDate { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
