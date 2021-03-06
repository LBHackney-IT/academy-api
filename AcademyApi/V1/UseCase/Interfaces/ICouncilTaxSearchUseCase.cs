using System.Threading.Tasks;
using AcademyApi.V1.Boundary.Response;
using AcademyApi.V1.Domain;

namespace AcademyApi.V1.UseCase.Interfaces;

public interface ICouncilTaxSearchUseCase
{
    Task<SearchResponseObjectList> Execute(string firstName, string lastName);
}
