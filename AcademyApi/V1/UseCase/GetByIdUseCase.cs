using AcademyApi.V1.Boundary.Response;
using AcademyApi.V1.Gateways;
using AcademyApi.V1.UseCase.Interfaces;
using AcademyApi.V1.Factories;
using Hackney.Core.Logging;

namespace AcademyApi.V1.UseCase
{
    //TODO: Rename class name and interface name to reflect the entity they are representing eg. GetClaimantByIdUseCase
    public class GetByIdUseCase : IGetByIdUseCase
    {
        private IExampleGateway _gateway;
        public GetByIdUseCase(IExampleGateway gateway)
        {
            _gateway = gateway;
        }
        [LogCall]
        //TODO: rename id to the name of the identifier that will be used for this API, the type may also need to change
        public SearchResponseObject Execute(int id)
        {
            return _gateway.GetEntityById(id).ToResponse();
        }
    }
}
