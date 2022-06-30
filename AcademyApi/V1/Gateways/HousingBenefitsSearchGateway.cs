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
    hbclaim.claim_id,
    hbclaim.check_digit,
    hbmember.person_ref,
    hbmember.forename,
    hbmember.surname,
    hbmember.birth_date,
    hbmember.nino,
    hbhousehold.addr1,
    hbhousehold.addr2,
    hbhousehold.addr3,
    hbhousehold.addr4,
    hbhousehold.post_code,
    hbmember.title
FROM
    hbmember
JOIN hbclaim ON hbclaim.claim_id = hbmember.claim_id
LEFT JOIN hbhousehold ON hbmember.claim_id = hbhousehold.claim_id
    AND hbmember.house_id = hbhousehold.house_id
WHERE
    hbhousehold.to_date = '2099-12-31'
    AND hbmember.forename LIKE @firstName
    AND hbmember.surname LIKE @lastName;
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
                        ClaimId = SafeGetString(reader, 0),
                        CheckDigit = SafeGetString(reader, 1),
                        PersonReference = SafeGetString(reader, 2),
                        Title = SafeGetString(reader, 12),
                        FirstName = SafeGetString(reader, 3),
                        LastName = SafeGetString(reader, 4),
                        DateOfBirth = reader.GetDateTime(5), // TODO: Make safe get
                        AddressLine1 = SafeGetString(reader, 7),
                        AddressLine2 = SafeGetString(reader, 8),
                        AddressLine3 = SafeGetString(reader, 9),
                        AddressLine4 = SafeGetString(reader, 10),
                        Postcode = SafeGetString(reader, 11)
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
