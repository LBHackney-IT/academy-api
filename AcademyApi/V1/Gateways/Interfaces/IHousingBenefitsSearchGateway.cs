using System.Collections.Generic;
using System.Threading.Tasks;
using AcademyApi.V1.Domain;

namespace AcademyApi.V1.Gateways.Interfaces;

public interface IHousingBenefitsSearchGateway
{
    Task<List<HousingBenefitsSearchResult>> GetAccountsByFullName(string firstName, string lastName);

    Task<HousingBenefitsRecord> GetAccountByAccountRef(int accountRef);
}
