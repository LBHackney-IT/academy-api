using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AcademyApi.V1.Boundary;
using AcademyApi.V1.Boundary.Response;
using AcademyApi.V1.Domain;
using AcademyApi.V1.Gateways.Interfaces;
using AcademyApi.V1.UseCase.Interfaces;
using Hackney.Core.Logging;
using Address = AcademyApi.V1.Boundary.Address;

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

    private static List<NoteResponseObject> ProcessNotes(string[] notes)
    {
        var returnNotes = new List<NoteResponseObject>();
        foreach (var note in notes)
        {
            var rawNote = note.Split('\n').ToArray();

            var metaDataStr = rawNote.Where(s => (s.Contains("User Id: "))).ToList().FirstOrDefault();

            var text = rawNote.Where(s => string.IsNullOrEmpty(s) &&  s != metaDataStr ).ToArray();

            if (metaDataStr != null)
            {
                var metaData = metaDataStr.Split("Date: ");

                returnNotes.Add(new NoteResponseObject()
                {
                    Note = string.Join("\n", text),
                    UserId = metaData[0].Replace("User Id: ", "").Trim(),
                    Date = metaData[1]
                });
            }
        }

        return returnNotes;
    }
}
