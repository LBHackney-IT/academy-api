using System.Threading.Tasks;
using AcademyApi.V1.Boundary.Response;

namespace AcademyApi.V1.UseCase.Interfaces;

public interface ISearchUseCase
{
    Task<SearchResponseObjectList> Execute(string firstName, string lastName);
}
