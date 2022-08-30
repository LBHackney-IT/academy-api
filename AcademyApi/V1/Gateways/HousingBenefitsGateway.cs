using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using AcademyApi.V1.Boundary;
using AcademyApi.V1.Boundary.Response;
using AcademyApi.V1.Domain;
using AcademyApi.V1.Gateways.Interfaces;
using AcademyApi.V1.Infrastructure;
using Hackney.Core.Logging;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static AcademyApi.V1.Gateways.SqlHelpers;
namespace AcademyApi.V1.Gateways;

public class HousingBenefitsGateway : IHousingBenefitsGateway
{
    private readonly AcademyContext _academyContext;

    public HousingBenefitsGateway(AcademyContext academyContext)
    {
        _academyContext = academyContext;
    }

    [LogCall]
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
    AND dbo.hbmember.forename LIKE @firstName
    AND dbo.hbmember.surname LIKE @lastName
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

    [LogCall]
    public async Task<BenefitsResponseObject> GetCustomer(int claimId, string checkDigit)
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
  AND dbo.hbclaim.check_digit = @checkDigit
  AND dbo.hbhousehold.to_date = '2099-12-31';
";

        using (var command = _academyContext.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new SqlParameter("@claimId", claimId));
            command.Parameters.Add(new SqlParameter("@checkDigit", checkDigit));

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

    [LogCall]
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

    [LogCall]
    public async Task<List<Note>> GetNotes(int claimId)
    {

        Console.WriteLine("---------- $$ Getting Notes For claimId {0}", claimId);

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

        Console.WriteLine("Notes found = {0}", JsonSerializer.Serialize(foundNotes));

        foreach (var note in foundNotes)
        {
            Console.WriteLine("Getting text for note {0}", JsonSerializer.Serialize(note));

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

    [LogCall]
    public async Task<HbInfo> GetWeeklyHousingBenefitDetails(int claimId)
    {
        Console.WriteLine("---------- $$ Getting Weekly HB Details For claimId {0}", claimId);

        var hbInfo = new HbInfo();

        var query = @"select distinct a.claim_id,
                (CASE when payee_ind = 0 then 'Direct to Rent account'
                      when payee_ind = 1 then 'HB direct to resident'
                      when payee_ind = 2 then 'HB direct to landlord'
                    END) as Housing_Benefit_Payee,
    (model_amt + local_amt + thresh_amt) Weekly_Housing_Benefit, a.payee_ind
from hbrentass a , hbclaim b
where a.claim_id = b.claim_id
  and b.status_ind = 1
  and a.from_date < GETDATE()
  and a.to_date > GETDATE()
  and a.type_ind = 1
  and a.dhp_ind = 0
  and a.manual_ind = 0
  and a.claim_id = @claimId";

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
                    hbInfo.HousingBenefitPayee = SafeGetString(reader, 1);
                    hbInfo.WeeklyHousingBenefit = SafeGetDecimal(reader, 2);
                    hbInfo.PayeeInd = SafeGetDecimal(reader, 3);
                }
            }

        }
        return hbInfo;
    }

    public async Task<HousingBenefitLandlordDetails> GetHousingBenefitLandlordDetails(int claimId)
    {
        Console.WriteLine("---------- $$ Getting Landlord Details For claimId {0}", claimId);

        var landlordDetails = new HousingBenefitLandlordDetails();

        var query = @"select distinct a.claim_id, c.name, c.addr1, c.addr2, c.addr3, c.addr4, c.post_code, c.creditor_id
from hbrentass a , hbclaim b, crcreditor c
where a.creditor_id = c.creditor_id
and a.claim_id = b.claim_id
  and b.status_ind = 1
  and a.from_date < GETDATE()
  and a.to_date > GETDATE()
  and a.payee_ind = 2
  and a.type_ind = 1
  and a.dhp_ind = 0
  and a.manual_ind = 0
and a.claim_id = @claimId";

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
                    landlordDetails.ClaimId = SafeGetInt(reader, 0);
                    landlordDetails.Name = SafeGetString(reader, 1);
                    landlordDetails.Addr1 = SafeGetString(reader, 2);
                    landlordDetails.Addr2 = SafeGetString(reader, 3);
                    landlordDetails.Addr3 = SafeGetString(reader, 4);
                    landlordDetails.Addr4 = SafeGetString(reader, 5);
                    landlordDetails.Postcode = SafeGetString(reader, 6);
                    landlordDetails.CreditorId = SafeGetInt(reader, 7);
                }
            }

        }

        return landlordDetails;
    }

    [LogCall]
    public async Task<PaymentDetails> GetLatestPaymentDetails(int claimId)
    {
        Console.WriteLine("---------- $$ Getting Latest Payment Details For claimId {0}", claimId);

        var paymentDetails = new PaymentDetails();

        var query = @"select top 1 claim_id, posting_date, pay_net_amt from hbrenttrans where claim_id = @claimId order by last_upd desc";

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
                    paymentDetails.ClaimId = SafeGetInt(reader, 0);
                    paymentDetails.PostingDate = SafeGetDateTime(reader, 1);
                    paymentDetails.PaymentAmount = SafeGetDecimal(reader, 2);
                }
            }

        }
        return paymentDetails;
    }
}
