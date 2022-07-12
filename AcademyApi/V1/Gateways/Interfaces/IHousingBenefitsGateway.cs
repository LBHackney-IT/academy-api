using System.Collections.Generic;
using System.Threading.Tasks;
using AcademyApi.V1.Boundary.Response;
using AcademyApi.V1.Domain;

namespace AcademyApi.V1.Gateways.Interfaces;

public interface IHousingBenefitsGateway
{
    Task<List<HousingBenefitsSearchResult>> GetAccountsByFullName(string firstName, string lastName);

    Task<BenefitsResponseObject> GetCustomer(int claimId, int personRef);
}
