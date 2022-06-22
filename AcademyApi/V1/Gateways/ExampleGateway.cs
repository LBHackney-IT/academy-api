using System.Collections.Generic;
using AcademyApi.V1.Domain;
using AcademyApi.V1.Infrastructure;
using AcademyApi.V1.Factories;

namespace AcademyApi.V1.Gateways
{
    //TODO: Rename to match the data source that is being accessed in the gateway eg. MosaicGateway
    public class ExampleGateway : IExampleGateway
    {
        private readonly AcademyContext _academyContext;

        public ExampleGateway(AcademyContext academyContext)
        {
            _academyContext = academyContext;
        }

        public SearchResult GetEntityById(int id)
        {
            var result = _academyContext.CouncilTaxSearchResultDbEntities.Find(id);

            return result?.ToDomain();
        }

        public List<SearchResult> GetAll()
        {
            return new List<SearchResult>();
        }
    }
}
