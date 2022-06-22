using System.Collections.Generic;
using System.Linq;
using AcademyApi.V1.Domain;
using AcademyApi.V1.Infrastructure;

namespace AcademyApi.V1.Factories
{
    public static class EntityFactory
    {
        public static SearchResult ToDomain(this CouncilTaxSearchResultDbEntity councilTaxSearchResultDbEntity)
        {
            // More information on this can be found here https://github.com/LBHackney-IT/lbh-base-api/wiki/Factory-object-mappings

            return new SearchResult
            {
                AccountReference = councilTaxSearchResultDbEntity.AccountRef,
                AccountCd = councilTaxSearchResultDbEntity.AccountCd,
                FullName = councilTaxSearchResultDbEntity.LeadLiabName,
                Title = councilTaxSearchResultDbEntity.LeadLiabTitle,
                FirstName = councilTaxSearchResultDbEntity.LeadLiabForename,
                LastName = councilTaxSearchResultDbEntity.LeadLiabSurname,
                AddressLine1 = councilTaxSearchResultDbEntity.Addr1,
                AddressLine2 = councilTaxSearchResultDbEntity.Addr2,
                AddressLine3 = councilTaxSearchResultDbEntity.Addr3,
                AddressLine4 = councilTaxSearchResultDbEntity.Addr4,
                Postcode = councilTaxSearchResultDbEntity.Postcode
            };
        }

        public static List<SearchResult> ToDomain(this List<CouncilTaxSearchResultDbEntity> dataSources)
        {
            return dataSources?.Select(hrItem => hrItem.ToDomain()).ToList();
        }


        public static CouncilTaxSearchResultDbEntity ToDatabase(this SearchResult searchResult)
        {
            return new CouncilTaxSearchResultDbEntity
            {
                AccountRef = searchResult.AccountReference,
                AccountCd = searchResult.AccountCd, // TODO: Ask Chris L what this means
                LeadLiabName = searchResult.FullName,
                LeadLiabTitle = searchResult.Title,
                LeadLiabForename = searchResult.FirstName,
                LeadLiabSurname = searchResult.LastName,
                Addr1 = searchResult.AddressLine1,
                Addr2 = searchResult.AddressLine2,
                Addr3 = searchResult.AddressLine3,
                Addr4 = searchResult.AddressLine4,
                Postcode = searchResult.Postcode
            };
        }
    }
}
