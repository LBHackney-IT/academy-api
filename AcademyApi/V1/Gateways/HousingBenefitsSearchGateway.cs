using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using AcademyApi.V1.Boundary;
using AcademyApi.V1.Boundary.Response;
using AcademyApi.V1.Domain;
using AcademyApi.V1.Gateways.Interfaces;
using AcademyApi.V1.Infrastructure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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
    core.dbo.hbclaim.claim_id,
    core.dbo.hbclaim.check_digit,
    core.dbo.hbmember.person_ref,
    core.dbo.hbmember.title,
    core.dbo.hbmember.forename,
    core.dbo.hbmember.surname,
    core.dbo.hbmember.birth_date,
    core.dbo.hbmember.nino,
    core.dbo.hbhousehold.addr1,
    core.dbo.hbhousehold.addr2,
    core.dbo.hbhousehold.addr3,
    core.dbo.hbhousehold.addr4,
    core.dbo.hbhousehold.post_code,
    core.dbo.hbhousehold.to_date
FROM
    core.dbo.hbmember
JOIN core.dbo.hbclaim ON core.dbo.hbclaim.claim_id = core.dbo.hbmember.claim_id
LEFT JOIN core.dbo.hbhousehold ON core.dbo.hbmember.claim_id = core.dbo.hbhousehold.claim_id
    AND core.dbo.hbmember.house_id = core.dbo.hbhousehold.house_id
WHERE
    core.dbo.hbhousehold.to_date = '2099-12-31'
    AND (
        core.dbo.hbmember.forename LIKE @firstName
            OR core.dbo.hbmember.surname LIKE @lastName
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

    private static string SafeGetString(DbDataReader reader, int colIndex)
    {
        if (!reader.IsDBNull(colIndex))
            return reader.GetString(colIndex);
        return string.Empty;
    }

    private static int SafeGetInt(DbDataReader reader, int colIndex)
    {
        if (!reader.IsDBNull(colIndex))
            return reader.GetInt32(colIndex);
        return 0;
    }
}
