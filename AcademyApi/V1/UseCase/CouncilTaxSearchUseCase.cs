using AcademyApi.V1.Boundary.Response;
using AcademyApi.V1.Gateways.Interfaces;
using AcademyApi.V1.UseCase.Interfaces;

namespace AcademyApi.V1.UseCase;

public class CouncilTaxSearchUseCase : ICouncilTaxSearchUseCase
{
    private readonly ICouncilTaxSearchGateway _councilTaxSearchGateway;

    public CouncilTaxSearchUseCase(ICouncilTaxSearchGateway councilTaxSearchGateway)
    {
        _councilTaxSearchGateway = councilTaxSearchGateway;
    }
    public SearchResponseObjectList Execute(string firstName, string lastName)
    {
        return new SearchResponseObjectList() { };
    }
}
