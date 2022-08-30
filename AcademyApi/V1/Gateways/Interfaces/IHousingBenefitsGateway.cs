using System.Collections.Generic;
using System.Threading.Tasks;
using AcademyApi.V1.Boundary;
using AcademyApi.V1.Boundary.Response;
using AcademyApi.V1.Domain;

namespace AcademyApi.V1.Gateways.Interfaces;

public interface IHousingBenefitsGateway
{
    Task<List<HousingBenefitsSearchResult>> GetAccountsByFullName(string firstName, string lastName);
    Task<List<Note>> GetNotes(int claimId);
    Task<BenefitsResponseObject> GetCustomer(int claimId, string checkDigit);
    Task<List<Benefits>> GetBenefits(int claimId);
    Task<HbInfo> GetWeeklyHousingBenefitDetails(int claimId);
    Task<HousingBenefitLandlordDetails> GetHousingBenefitLandlordDetails(int claimId);
    Task<PaymentDetails> GetLatestPaymentDetails(int claimId);
}
