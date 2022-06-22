using AcademyApi.V1.Boundary.Response;

namespace AcademyApi.V1.UseCase.Interfaces
{
    public interface IGetByIdUseCase
    {
        SearchResponseObject Execute(int id);
    }
}
