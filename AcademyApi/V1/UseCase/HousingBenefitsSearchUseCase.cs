using System.Collections.Generic;
using System.Threading.Tasks;
using AcademyApi.V1.Boundary;
using AcademyApi.V1.Boundary.Response;
using AcademyApi.V1.Gateways.Interfaces;
using AcademyApi.V1.UseCase.Interfaces;
using Hackney.Core.Logging;

namespace AcademyApi.V1.UseCase;

public class HousingBenefitsSearchUseCase : ISearchUseCase
{
    private readonly ISearchGateway _searchGateway;

    public HousingBenefitsSearchUseCase(ISearchGateway searchGateway)
    {
        _searchGateway = searchGateway;
    }

    [LogCall]
    public async Task<SearchResponseObjectList> Execute(string firstName, string lastName)
    {
        var accounts = await _searchGateway.GetAccountsByFullName(firstName, lastName);

        if (accounts.Count == 0)
        {
            return new SearchResponseObjectList() { Error = "No Results Found" };
        }

        var customerResponse = new List<SearchResponseObject>();

        foreach (var account in accounts)
        {
            var searchResponse = new SearchResponseObject()
            {
                Id = account.ClaimId,
                FirstName = account.FirstName,
                LastName = account.LastName,
                FullAddress = new Address()
                {
                    Line1 = account.AddressLine1,
                    Line2 = account.AddressLine2,
                    Line3 = account.AddressLine3,
                    Line4 = account.AddressLine4,
                    Postcode = account.Postcode
                },
            };
            customerResponse.Add(searchResponse);
        }
        return new SearchResponseObjectList() { Error = null, Customers = customerResponse };
    }
}
