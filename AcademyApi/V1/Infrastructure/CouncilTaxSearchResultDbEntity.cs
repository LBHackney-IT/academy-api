using Amazon.DynamoDBv2.DataModel;
using Hackney.Core.DynamoDb.Converters;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyApi.V1.Infrastructure
{
    //TODO: rename table and add needed fields relating to the table columns.
    // There's an example of this in the wiki https://github.com/LBHackney-IT/lbh-base-api/wiki/DatabaseContext

    //TODO: Pick the attributes for the required data source, delete the others as appropriate
    // Postgres will use the "Table" and "Column" attributes
    // DynamoDB will use the "DynamoDBTable", "DynamoDBHashKey" and "DynamoDBProperty" attributes

    //TODO: For DynamoDB...
    // * The table name must match that specified in the terraform step that provisions the DynamoDb resource
    // * The name of the hash key property must match that specified in the terraform step that provisions the DynamoDb resource

    [Table("council_tax_search")]
    public class CouncilTaxSearchResultDbEntity
    {
        [Column("account_ref")]
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
        
        [Column("addr1")]
        public string Addr1 { get; set; }
        
        [Column("addr2")]
        public string Addr2 { get; set; }
        
        [Column("addr3")]
        public string Addr3 { get; set; }
        
        [Column("addr4")]
        public string Addr4 { get; set; }
        
        [Column("postcode")]
        public string Postcode { get; set; }
    }
}
