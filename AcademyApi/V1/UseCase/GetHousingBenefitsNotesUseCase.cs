using System;
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

public class GetHousingBenefitsNotesUseCase : IGetHousingBenefitsNotesUseCase
{
    private readonly IHousingBenefitsGateway _housingBenefitsGateway;
    public static readonly string IdSeparator = "-";

    public GetHousingBenefitsNotesUseCase(IHousingBenefitsGateway housingBenefitsGateway)
    {
        _housingBenefitsGateway = housingBenefitsGateway;
    }

    [LogCall]
    public async Task<List<NoteResponseObject>> Execute(string benefitsId)
    {

        int claimId = Int32.Parse(benefitsId.Remove(benefitsId.Length -1, 1));

        var returnNotes = new List<List<NoteResponseObject>>();

        var res = await _housingBenefitsGateway.GetNotes(claimId);
        foreach (var n in res)
        {
            string[] notes = Regex.Split(n.Text, @"--+");

            returnNotes.Add(ProcessNotes(notes));
        }

        return returnNotes.SelectMany(x => x).ToList();
    }

}
