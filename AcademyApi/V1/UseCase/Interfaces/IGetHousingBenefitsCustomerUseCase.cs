using System.Threading.Tasks;
using AcademyApi.V1.Boundary.Response;

namespace AcademyApi.V1.UseCase.Interfaces;

public interface IGetHousingBenefitsCustomerUseCase
{
    Task<BenefitsResponseObject> Execute(string benefitsId);
}
