using System;
using System.Linq;
using System.Threading.Tasks;
using AcademyApi.V1.Boundary.Response;
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



        int claimId = Int32.Parse(benefitsId.Remove(benefitsId.Length -1, 1));
        int checkDigit = Int32.Parse(benefitsId.Substring(7,1));

        var customer = await _housingBenefitsGateway.GetCustomer(claimId, checkDigit);
        if (customer == null) return null;
        customer.Benefits = await _housingBenefitsGateway.GetBenefits(claimId);
        customer.WeeklyHousingBenefitAmount = await _housingBenefitsGateway.GetWeeklyHousingBenefitAmount(claimId);

        return customer;
    }
}
