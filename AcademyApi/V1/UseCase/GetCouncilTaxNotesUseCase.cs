using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AcademyApi.V1.Boundary.Response;
using AcademyApi.V1.Gateways.Interfaces;
using AcademyApi.V1.UseCase.Interfaces;
using Hackney.Core.Logging;
using static AcademyApi.V1.UseCase.Helpers;

namespace AcademyApi.V1.UseCase;

public class GetCouncilTaxNotesUseCase : IGetCouncilTaxNotesUseCase
{
    private readonly ICouncilTaxSearchGateway _councilTaxSearchGateway;

    public GetCouncilTaxNotesUseCase(ICouncilTaxSearchGateway councilTaxSearchGateway)
    {
        _councilTaxSearchGateway = councilTaxSearchGateway;
    }

    [LogCall]
    public async Task<List<NoteResponseObject>> Execute(int accountReference)
    {
        var returnNotes = new List<List<NoteResponseObject>>();

        var res = await _councilTaxSearchGateway.GetNotes(accountReference);
        foreach (var n in res)
        {
            string[] notes = Regex.Split(n.Text, @"--+");

            returnNotes.Add(ProcessNotes(notes));
        }

        return returnNotes.SelectMany(x => x).ToList();
    }
}
