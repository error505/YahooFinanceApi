using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Data.Models
{
    public class CompanyProfile
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CompaniesId { get; set; }
        public Companies Companies { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string IndustryId { get; set; }
        public Industry Industry { get; set; }
        public string IndustrySymbolId { get; set; }
        public IndustrySimbol IndustrySymbol { get; set; }
        public string SectorId { get; set; }
        public Sector Sector { get; set; }
        public string LongBusinessSummary { get; set; }
        public int FullTimeEmployees { get; set; }
        public int AuditRisk { get; set; }
        public int BoardRisk { get; set; }
        public int CompensationRisk { get; set; }
        public int ShareHolderRightsRisk { get; set; }
        public int OverallRisk { get; set; }
        public long GovernanceEpochDate { get; set; }
        public long CompensationAsOfEpochDate { get; set; }
        public ICollection<CompanyOfficers> CompanyOfficers { get; set; }

    }
}
