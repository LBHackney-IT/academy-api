using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using AcademyApi.V1.Boundary.Response;
using AcademyApi.V1.Domain;
using AcademyApi.V1.Gateways.Interfaces;
using AcademyApi.V1.Infrastructure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AcademyApi.V1.Gateways;

public class HousingBenefitsGateway : IHousingBenefitsGateway
{
    private readonly AcademyContext _academyContext;

    public HousingBenefitsGateway(AcademyContext academyContext)
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
                        ClaimId = SafeGetInt32(reader, 0),
                        CheckDigit = SafeGetString(reader, 1),
                        PersonReference = SafeGetInt32(reader, 2),
                        Title = SafeGetString(reader, 3),
                        FirstName = SafeGetString(reader, 4),
                        LastName = SafeGetString(reader, 5),
                        DateOfBirth = SafeGetDateTime(reader, 6),
                        NiNumber = SafeGetString(reader, 7),
                        AddressLine1 = SafeGetString(reader, 8),
                        AddressLine2 = SafeGetString(reader, 9),
                        AddressLine3 = SafeGetString(reader, 10),
                        AddressLine4 = SafeGetString(reader, 11),
                        Postcode = SafeGetString(reader, 12),
                        AddressToDate = SafeGetDateTime(reader, 13),
                    });
                }
            }
        }
        return foundResults;
    }

    public async Task<BenefitsResponseObject> GetCustomer(int claimId, int personRef)
    {
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
  dbo.hbhousehold.post_code
FROM
  dbo.hbmember
  JOIN dbo.hbclaim ON dbo.hbclaim.claim_id = dbo.hbmember.claim_id
  JOIN dbo.hbhousehold ON dbo.hbmember.claim_id = dbo.hbhousehold.claim_id
		AND dbo.hbmember.house_id = dbo.hbhousehold.house_id
WHERE dbo.hbmember.claim_id = @claimId
  AND dbo.hbmember.person_ref = @personRef
  AND dbo.hbhousehold.to_date = '2099-12-31';
";

        using (var command = _academyContext.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new SqlParameter("@claimId", claimId));
            command.Parameters.Add(new SqlParameter("@personRef", personRef));

            await _academyContext.Database.OpenConnectionAsync();
            var reader = await command.ExecuteReaderAsync();
            using (reader)
            {
                var record = await reader.ReadAsync();

                if (!record) return null;

                return new BenefitsResponseObject
                {
                    ClaimId = SafeGetInt32(reader, 0),
                    CheckDigit = SafeGetString(reader, 1),
                    PersonReference = SafeGetInt32(reader, 2),
                    Title = SafeGetString(reader, 3),
                    FirstName = SafeGetString(reader, 4),
                    LastName = SafeGetString(reader, 5),
                    DateOfBirth = SafeGetDateTime(reader, 6),
                    NiNumber = SafeGetString(reader, 7),
                    FullAddress = new()
                    {
                        Line1 = SafeGetString(reader, 8),
                        Line2 = SafeGetString(reader, 9),
                        Line3 = SafeGetString(reader, 10),
                        Line4 = SafeGetString(reader, 11),
                        Postcode = SafeGetString(reader, 12),
                    },
                    PostCode = SafeGetString(reader, 12),
                    HouseholdMembers = new List<HouseHoldMember>()
                    {
                        new()
                        {
                            Title = SafeGetString(reader, 3),
                            FirstName = SafeGetString(reader, 4),
                            LastName = SafeGetString(reader, 5),
                            DateOfBirth = SafeGetDateTime(reader, 6),
                        }
                    },
                };
            }
        }
    }

    public async Task<List<Benefits>> GetBenefits(int claimId)
    {
#nullable enable
        List<Benefits>? benefits = null;
#nullable disable
        var query = @"
SELECT
hbincome.inc_amt,
hbincome.freq_len,
hbincome.freq_period,
hbinccode.descrip1
FROM
    hbincome
JOIN hbhousehold ON hbincome.claim_id = hbhousehold.claim_id AND hbincome.house_id = hbhousehold.house_id
JOIN hbinccode ON hbinccode.code = hbincome.inc_code AND hbinccode.to_date = '2099-12-31'
WHERE
hbhousehold.to_date = '2099-12-31'
AND hbincome.claim_id = @claimId
        ";

        using (var command = _academyContext.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new SqlParameter("@claimId", claimId));

            await _academyContext.Database.OpenConnectionAsync();
            var reader = await command.ExecuteReaderAsync();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    benefits ??= new();
                    benefits.Add(new()
                    {
                        Amount = SafeGetDecimal(reader, 0),
                        Description = SafeGetString(reader, 3),
                        Period = GetBenefitsPeriod(SafeGetDecimal(reader, 1)),
                        Frequency = SafeGetInt16(reader, 2),
                    });
                }
            }
        }
        return benefits;
    }

    private static string GetBenefitsPeriod(decimal freqLen)
    {
        string benefitsPeriod = "N/A";

        if (1 == freqLen)
        {
            benefitsPeriod = "Daily";
        }
        else if (2 == freqLen)
        {
            benefitsPeriod = "Weekly";
        }
        else if (3 == freqLen)
        {
            benefitsPeriod = "Monthly";
        }
        else if (4 == freqLen)
        {
            benefitsPeriod = "Half-Yearly";
        }
        else if (5 == freqLen)
        {
            benefitsPeriod = "Annually";
        }
        else if (14 == freqLen)
        {
            benefitsPeriod = "Quarterly";
        }

        return benefitsPeriod;
    }

    private static decimal SafeGetDecimal(DbDataReader reader, int colIndex)
    {
        return reader.IsDBNull(colIndex) ? 0.0M : reader.GetDecimal(colIndex);
    }

    private static int SafeGetInt16(DbDataReader reader, int colIndex)
    {
        return reader.IsDBNull(colIndex) ? 0 : reader.GetInt16(colIndex);
    }

    private static int SafeGetInt32(DbDataReader reader, int colIndex)
    {
        return reader.IsDBNull(colIndex) ? 0 : reader.GetInt32(colIndex);
    }

    private static DateTime SafeGetDateTime(DbDataReader reader, int colIndex)
    {
        return reader.IsDBNull(colIndex) ? new DateTime() : reader.GetDateTime(colIndex);
    }

    private static string SafeGetString(DbDataReader reader, int colIndex)
    {
        return reader.IsDBNull(colIndex) ? string.Empty : reader.GetString(colIndex);
    }
}
