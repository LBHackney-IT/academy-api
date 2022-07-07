using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcademyApi.V1.Boundary.Response;
using AcademyApi.V1.Domain;
using AcademyApi.V1.Gateways.Interfaces;
using AcademyApi.V1.UseCase.Interfaces;
using Hackney.Core.Logging;
using Address = AcademyApi.V1.Boundary.Address;

namespace AcademyApi.V1.UseCase;

public class GetCouncilTaxCustomerUseCase : IGetCouncilTaxCustomerUseCase
{
    private readonly ICouncilTaxSearchGateway _councilTaxSearchGateway;

    public GetCouncilTaxCustomerUseCase(ICouncilTaxSearchGateway councilTaxSearchGateway)
    {
        _councilTaxSearchGateway = councilTaxSearchGateway;
    }

    [LogCall]
    public async Task<CouncilTaxRecord> Execute(int accountReference)
    {
        var record = new CouncilTaxRecord();
        try
        {
            record = await _councilTaxSearchGateway.GetCustomer(accountReference);

        }
        catch (Exception e)
        {
            Console.WriteLine("--- ERROR FETCHING: ");
            Console.WriteLine(e);
        }

        return record;
    }
}
