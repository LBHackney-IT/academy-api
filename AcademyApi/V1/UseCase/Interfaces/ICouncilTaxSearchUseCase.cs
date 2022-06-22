using AcademyApi.V1.Boundary.Response;

namespace AcademyApi.V1.UseCase.Interfaces;

public interface ICouncilTaxSearchUseCase
{
    SearchResponseObjectList Execute(string firstName, string lastName);
}
