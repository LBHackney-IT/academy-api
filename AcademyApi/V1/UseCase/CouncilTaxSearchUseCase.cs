using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcademyApi.V1.Boundary;
using AcademyApi.V1.Boundary.Response;
using AcademyApi.V1.Gateways.Interfaces;
using AcademyApi.V1.UseCase.Interfaces;
using Hackney.Core.Logging;

namespace AcademyApi.V1.UseCase;

public class CouncilTaxSearchUseCase : ICouncilTaxSearchUseCase
{
    private readonly ICouncilTaxSearchGateway _councilTaxSearchGateway;

    public CouncilTaxSearchUseCase(ICouncilTaxSearchGateway councilTaxSearchGateway)
    {
        _councilTaxSearchGateway = councilTaxSearchGateway;
    }

    [LogCall]
    public async Task<SearchResponseObjectList> Execute(string firstName, string lastName)
    {
        Console.WriteLine("------------------");
        Console.WriteLine($"usecase searching: ${firstName} ${lastName}");
        Console.WriteLine("------------------");

        var customerResponse = new List<SearchResponseObject>();

        try
        {
            var accounts = await _councilTaxSearchGateway.GetAccountsByFullName(firstName, lastName);

            if (accounts.Count == 0)
            {
                return new SearchResponseObjectList() { Error = "No Results Found" };
            }


            foreach (var account in accounts)
            {
                var searchResponse = new SearchResponseObject()
                {
                    Id = account.AccountCd,
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

        }
        catch (Exception e)
        {
            Console.WriteLine("%%%%%%%%%%%%%%%%%%%%");
            Console.WriteLine(e);
            Console.WriteLine("%%%%%%%%%%%%%%%%%%%%");
        }
        return new SearchResponseObjectList() { Error = null, Customers = customerResponse };

    }
}
