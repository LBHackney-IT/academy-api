using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyApi.V1.Domain;

namespace AcademyApi.V1.Gateways
{
    public interface IExampleDynamoGateway
    {
        List<CouncilTaxSearchResult> GetAll();
        Task<CouncilTaxSearchResult> GetEntityById(int id);

    }
}
