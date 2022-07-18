using System.Collections.Generic;
using System.Threading.Tasks;
using AcademyApi.V1.Boundary;
using AcademyApi.V1.Domain;

namespace AcademyApi.V1.Gateways.Interfaces;

public interface ICouncilTaxSearchGateway
{
    Task<List<CouncilTaxSearchResult>> GetAccountsByFullName(string firstName, string lastName);
    Task<CouncilTaxRecord> GetCustomer(int accountRef);
    Task<List<Note>> GetNotes(int accountRef);
}
