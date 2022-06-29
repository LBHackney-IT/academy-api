using System.Collections.Generic;
using System.Threading.Tasks;
using AcademyApi.V1.Domain;

namespace AcademyApi.V1.Gateways.Interfaces;

public interface ISearchGateway
{
    Task<List<ISearchResult>> GetAccountsByFullName(string firstName, string lastName);
}
