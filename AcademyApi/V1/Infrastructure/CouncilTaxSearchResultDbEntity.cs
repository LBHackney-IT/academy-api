using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyApi.V1.Infrastructure
{
    [Table("ctaccount")]
    public class CouncilTaxSearchResultDbEntity
    {
        [Column("account_ref"), Key]
        public int AccountRef { get; set; }

        [Column("account_cd")]
        public string AccountCd { get; set; }

        [Column("lead_liab_name")]
        public string LeadLiabName { get; set; }

        [Column("lead_liab_title")]
        public string LeadLiabTitle { get; set; }

        [Column("lead_liab_forename")]
        public string LeadLiabForename { get; set; }

        [Column("lead_liab_surname")]
        public string LeadLiabSurname { get; set; }

        [Column("for_addr1")]
        public string Addr1 { get; set; }

        [Column("for_addr2")]
        public string Addr2 { get; set; }

        [Column("for_addr3")]
        public string Addr3 { get; set; }

        [Column("for_addr4")]
        public string Addr4 { get; set; }

        [Column("for_postcode")]
        public string Postcode { get; set; }
    }
}
