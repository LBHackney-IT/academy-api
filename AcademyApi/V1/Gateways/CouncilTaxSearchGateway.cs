using System.Collections.Generic;
using System.Threading.Tasks;
using AcademyApi.V1.Domain;
using AcademyApi.V1.Factories;
using AcademyApi.V1.Gateways.Interfaces;
using AcademyApi.V1.Infrastructure;

namespace AcademyApi.V1.Gateways;

public class CouncilTaxSearchGateway : ICouncilTaxSearchGateway
{
    private readonly AcademyContext _academyContext;

    public CouncilTaxSearchGateway(AcademyContext academyContext)
    {
        _academyContext = academyContext;
    }

    public List<SearchResult> GetAccountsByFullName(string fullName)
    {

        var results = new List<CouncilTaxSearchResultDbEntity>
        {
            new CouncilTaxSearchResultDbEntity()
            {
                AccountRef = 30548418,
                AccountCd = "2",
                LeadLiabName = "SIMPSON,MR HOMER",
                LeadLiabTitle = "Mr",
                LeadLiabForename = "HOMER",
                LeadLiabSurname = "SIMPSON",
                Addr1 = "FLAT 1ST FLR",
                Addr2 = "2 EVERGREEN TERRACE",
                Addr3 = "LONDON",
                Addr4 = "",
                Postcode = "E8 2LN"
            },
            new CouncilTaxSearchResultDbEntity()
            {
                AccountRef = 30403567,
                AccountCd = "9",
                LeadLiabName = "SIMPSON,MR HOMER",
                LeadLiabTitle = "Mr",
                LeadLiabForename = "HOMER",
                LeadLiabSurname = "SIMPSON",
                Addr1 = "FLAT 1ST FLR",
                Addr2 = "2 EVERGREEN TERRACE",
                Addr3 = "LONDON",
                Addr4 = "",
                Postcode = "E8 2LN"
            },
            new CouncilTaxSearchResultDbEntity()
            {
                AccountRef = 30000003,
                AccountCd = "9",
                LeadLiabName = "SIMPSON,MR HOMER",
                LeadLiabTitle = "Mr",
                LeadLiabForename = "HOMER",
                LeadLiabSurname = "SIMPSON",
                Addr1 = "FLAT 1ST FLR",
                Addr2 = "2 EVERGREEN TERRACE",
                Addr3 = "LONDON",
                Addr4 = "",
                Postcode = "E8 2LN"
            }
        };

        return results.ToDomain();
    }
}
