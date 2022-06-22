using System.Collections.Generic;
using AcademyApi.V1.Domain;

namespace AcademyApi.V1.Gateways
{
    public interface IExampleGateway
    {
        SearchResult GetEntityById(int id);

        List<SearchResult> GetAll();
    }
}
