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
        string checkDigit = benefitsId.Substring(7,1);

        var customer = await _housingBenefitsGateway.GetCustomer(claimId, checkDigit);
        if (customer == null) return null;
        customer.Benefits = await _housingBenefitsGateway.GetBenefits(claimId);
        customer.HousingBenefitDetails = await _housingBenefitsGateway.GetWeeklyHousingBenefitDetails(claimId);
        customer.PaymentDetails = await _housingBenefitsGateway.GetLatestPaymentDetails(claimId);

        if (customer.HousingBenefitDetails.PayeeInd == 2)
        {
            customer.HousingBenefitLandlordDetails =
                await _housingBenefitsGateway.GetHousingBenefitLandlordDetails(claimId);
        }

        return customer;
    }
}
