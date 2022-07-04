using System.Threading.Tasks;
using AcademyApi.V1.Boundary.Response;
using AcademyApi.V1.Domain;

namespace AcademyApi.V1.UseCase.Interfaces;

public interface IGetCouncilTaxCustomerUseCase
{
    Task<CouncilTaxRecord> Execute(int accountReference);
}
