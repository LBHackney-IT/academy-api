using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using AcademyApi.V1.Boundary;
using AcademyApi.V1.Domain;
using AcademyApi.V1.Gateways.Interfaces;
using AcademyApi.V1.Infrastructure;
using Hackney.Core.Logging;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static AcademyApi.V1.Gateways.SqlHelpers;

namespace AcademyApi.V1.Gateways;

public class HousingBenefitsSearchGateway : IHousingBenefitsSearchGateway
{
    private readonly AcademyContext _academyContext;

    public HousingBenefitsSearchGateway(AcademyContext academyContext)
    {
        _academyContext = academyContext;
    }

    public async Task<List<HousingBenefitsSearchResult>> GetAccountsByFullName(string firstName, string lastName)
    {
        var foundResults = new List<HousingBenefitsSearchResult>();
        var query = @"
SELECT
    dbo.hbclaim.claim_id,
    dbo.hbclaim.check_digit,
    dbo.hbmember.person_ref,
    dbo.hbmember.title,
    dbo.hbmember.forename,
    dbo.hbmember.surname,
    dbo.hbmember.birth_date,
    dbo.hbmember.nino,
    dbo.hbhousehold.addr1,
    dbo.hbhousehold.addr2,
    dbo.hbhousehold.addr3,
    dbo.hbhousehold.addr4,
    dbo.hbhousehold.post_code,
    dbo.hbhousehold.to_date
FROM
    dbo.hbmember
JOIN dbo.hbclaim ON dbo.hbclaim.claim_id = dbo.hbmember.claim_id
LEFT JOIN dbo.hbhousehold ON dbo.hbmember.claim_id = dbo.hbhousehold.claim_id
    AND dbo.hbmember.house_id = dbo.hbhousehold.house_id
WHERE
    dbo.hbhousehold.to_date = '2099-12-31'
    AND (
        dbo.hbmember.forename LIKE @firstName
            OR dbo.hbmember.surname LIKE @lastName
    )
";

        using (var command = _academyContext.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new SqlParameter("@firstName", firstName));
            command.Parameters.Add(new SqlParameter("@lastName", lastName));

            await _academyContext.Database.OpenConnectionAsync();

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    foundResults.Add(new HousingBenefitsSearchResult
                    {
                        ClaimId = SafeGetInt(reader, 0),
                        CheckDigit = SafeGetString(reader, 1),
                        PersonReference = SafeGetInt(reader, 2),
                        Title = SafeGetString(reader, 3),
                        FirstName = SafeGetString(reader, 4),
                        LastName = SafeGetString(reader, 5),
                        DateOfBirth = reader.GetDateTime(6),
                        NiNumber = SafeGetString(reader, 7),
                        AddressLine1 = SafeGetString(reader, 8),
                        AddressLine2 = SafeGetString(reader, 9),
                        AddressLine3 = SafeGetString(reader, 10),
                        AddressLine4 = SafeGetString(reader, 11),
                        Postcode = SafeGetString(reader, 12),
                        AddressToDate = reader.GetDateTime(13)
                    });
                }
            }
        }
        return foundResults;
    }

    [LogCall]
    public async Task<List<Note>> GetNotes(int claimId)
    {
        string notePadQuery = $@"select hbdiary.descrip,
               hbclaimdiary.diary_notes_handle,
               hbclaimdiary.user_id
        from dbo.hbclaimdiary left join dbo.hbdiary on dbo.hbdiary.code = dbo.hbclaimdiary.diary_code
        where hbclaimdiary.claim_id = {claimId};";

        var foundNotes = new List<Note>();

        using (var command = _academyContext.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = notePadQuery;
            command.CommandType = CommandType.Text;

            await _academyContext.Database.OpenConnectionAsync();
            var reader = await command.ExecuteReaderAsync();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    foundNotes.Add(new Note()
                    {
                        NoteType = SafeGetString(reader, 0),
                        StringId = SafeGetString(reader, 1).Split(':')[1],
                        Username = SafeGetString(reader, 2),
                    });
                }
            }
        }

        foreach (var note in foundNotes)
        {
            string noteQuery = $@"select text_value from dbo.hbclaimnotes where string_id = {note.StringId};";

            using (var command = _academyContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = noteQuery;
                command.CommandType = CommandType.Text;

                await _academyContext.Database.OpenConnectionAsync();
                var reader = await command.ExecuteReaderAsync();

                var text = new List<string>();
                using (reader)
                {
                    while (await reader.ReadAsync())
                    {
                        text.Add(SafeGetString(reader, 0));
                    }
                }

                note.Text = string.Join("\n", text);
            }
        }
        return foundNotes;
    }
}