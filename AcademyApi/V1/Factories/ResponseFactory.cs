using System.Collections.Generic;
using System.Linq;
using AcademyApi.V1.Boundary.Response;
using AcademyApi.V1.Domain;

namespace AcademyApi.V1.Factories
{
    public static class ResponseFactory
    {
        //TODO: Map the fields in the domain object(s) to fields in the response object(s).
        // More information on this can be found here https://github.com/LBHackney-IT/lbh-base-api/wiki/Factory-object-mappings
        public static SearchResponseObject ToResponse(this CouncilTaxSearchResult domain)
        {
            return new SearchResponseObject();
        }

        public static List<SearchResponseObject> ToResponse(this IEnumerable<CouncilTaxSearchResult> domainList)
        {
            return domainList.Select(domain => domain.ToResponse()).ToList();
        }
    }
}
