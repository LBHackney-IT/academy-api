using AcademyApi.V1.Boundary.Response;
using AcademyApi.V1.Gateways;
using AcademyApi.V1.UseCase.Interfaces;
using AcademyApi.V1.Factories;
using Hackney.Core.Logging;

namespace AcademyApi.V1.UseCase
{
    //TODO: Rename class name and interface name to reflect the entity they are representing eg. GetAllClaimantsUseCase
    public class GetAllUseCase : IGetAllUseCase
    {
        private readonly IExampleGateway _gateway;
        public GetAllUseCase(IExampleGateway gateway)
        {
            _gateway = gateway;
        }
        [LogCall]
        public SearchResponseObjectList Execute()
        {
            return new SearchResponseObjectList { Customers = _gateway.GetAll().ToResponse() };
        }
    }
}
