using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class OptionsQuote
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompaniesId { get; set; }
        public Companies Companies { get; set; }
        public string QuoteType { get; set; }
        public string QuoteSourceName { get; set; }
        public string Currency { get; set; }
        public string SharesOutstanding { get; set; }
        public string BookValue { get; set; }
        public string FiftyDayAverage { get; set; }
        public string FiftyDayAverageChange { get; set; }
        public string ShortName { get; set; }
        public string Market { get; set; }
        public string RegularMarketPrice { get; set; }
        public string PriceHint { get; set; }
        public string PostMarketChangePercent { get; set; }
        public string PostMarketTime { get; set; }
        public string PostMarketPrice { get; set; }
        public string PostMarketChange { get; set; }
        public string RegularMarketChangePercent { get; set; }
        public string RegularMarketPreviousClose { get; set; }
        public string Bid { get; set; }
        public string Ask { get; set; }
        public string BidSize { get; set; }
        public string AskSize { get; set; }
        public string MarketState { get; set; }
        public string RegularMarketTime { get; set; }
        public string RegularMarketChange { get; set; }
        public string RegularMarketOpen { get; set; }
        public string RegularMarketDayHigh { get; set; }
        public string RegularMarketDayLow { get; set; }
        public string RegularMarketVolume { get; set; }
        public string LongName { get; set; }
        public string MessageBoardId { get; set; }
        public string FullExchangeName { get; set; }
        public string AverageDailyVolume3Month { get; set; }
        public string AverageDailyVolume10Day { get; set; }
        public string FiftyTwoWeekLowChange { get; set; }
        public string FiftyTwoWeekLowChangePercent { get; set; }
        public string FiftyTwoWeekHighChange { get; set; }
        public string FiftyTwoWeekHighChangePercent { get; set; }
        public string FiftyTwoWeekLow { get; set; }
        public string FiftyTwoWeekHigh { get; set; }
        public string DividendDate { get; set; }
        public string TrailingAnnualDividendRate { get; set; }
        public string TrailingPe { get; set; }
        public string EpsTrailingTwelveMonths { get; set; }
        public string EpsForward { get; set; }
        public string FiftyDayAverageChangePercent { get; set; }
        public string TwoHundredDayAverage { get; set; }
        public string TwoHundredDayAverageChange { get; set; }
        public string TwoHundredDayAverageChangePercent { get; set; }
        public string MarketCap { get; set; }
        public string ForwardPe { get; set; }
        public string PriceToBook { get; set; }
        public string SourceInterval { get; set; }
        public string ExchangeTimezoneName { get; set; }
        public string ExchangeTimezoneShortName { get; set; }
        public string GmtOffSetMilliseconds { get; set; }
        public string ExchangeId { get; set; }
        public Exchange Exchange { get; set; }
        public string ExchangeName { get; set; }
        public string Symbol { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string CreatedByUser { get; set; }
    }
}
