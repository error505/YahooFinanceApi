﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class UpgradeDowngradeHistory
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompaniesId { get; set; }
        public Companies Companies { get; set; }
        public string EpochGradeDate { get; set; }
        public string Firm { get; set; }
        public string ToGrade { get; set; }
        public string FromGrade { get; set; }
        public string Action { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
