﻿using System;

namespace StockExchangeYahooFinance.Data.Models
{
    public class Currencies
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Entity { get; set; }

        public string Currency { get; set; }

        public string Code { get; set; }

        public int NumericCode { get; set; }

        public string MinorUnit { get; set; }

        public DateTime CreationTime { get; set; } = DateTime.Now;
    }
}
