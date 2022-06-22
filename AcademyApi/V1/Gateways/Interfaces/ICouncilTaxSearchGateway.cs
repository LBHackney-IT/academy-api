using System.Collections.Generic;
using System.Threading.Tasks;
using AcademyApi.V1.Domain;

namespace AcademyApi.V1.Gateways.Interfaces;

public interface ICouncilTaxSearchGateway
{
    List<SearchResult> GetAll(string fullName);
}
