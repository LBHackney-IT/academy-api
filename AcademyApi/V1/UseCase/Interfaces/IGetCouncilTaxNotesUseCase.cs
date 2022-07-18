using System.Collections.Generic;
using System.Threading.Tasks;
using AcademyApi.V1.Boundary;
using AcademyApi.V1.Boundary.Response;
using AcademyApi.V1.Domain;

namespace AcademyApi.V1.UseCase.Interfaces;

public interface IGetCouncilTaxNotesUseCase
{
    Task<List<NoteResponseObject>> Execute(int accountReference);
}
