using AcademyApi.V1.Boundary.Response;
using AcademyApi.V1.UseCase.Interfaces;

namespace AcademyApi.V1.UseCase;

public class CouncilTaxSearchUseCase: ICouncilTaxSearchUseCase
{
    public SearchResponseObjectList Execute(string firstName, string lastName)
    {
        return new SearchResponseObjectList() {};
    }
}
