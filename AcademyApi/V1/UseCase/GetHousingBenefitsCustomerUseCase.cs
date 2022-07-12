using System;
using System.Threading.Tasks;
using AcademyApi.V1.Boundary.Response;
using AcademyApi.V1.Domain;
using AcademyApi.V1.Gateways.Interfaces;
using AcademyApi.V1.UseCase.Interfaces;
using Hackney.Core.Logging;

namespace AcademyApi.V1.UseCase;

public class GetHousingBenefitsCustomerUseCase : IGetHousingBenefitsCustomerUseCase
{
    private readonly IHousingBenefitsGateway _housingBenefitsGateway;

    public GetHousingBenefitsCustomerUseCase(IHousingBenefitsGateway housingBenefitsGateway)
    {
        _housingBenefitsGateway = housingBenefitsGateway;
    }

    [LogCall]
    public async Task<BenefitsResponseObject> Execute(string benefitsId)
    {
        var benefitsIdParts = benefitsId.Split("/");
        if (benefitsIdParts.Length < 2) return null;

        int claimId = Int32.Parse(benefitsIdParts[0]);
        int personRef = Int32.Parse(benefitsIdParts[1]);

        return await _housingBenefitsGateway.GetCustomer(claimId, personRef);
    }
}
