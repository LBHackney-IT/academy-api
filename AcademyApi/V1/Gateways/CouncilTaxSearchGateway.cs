using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using AcademyApi.V1.Domain;
using AcademyApi.V1.Gateways.Interfaces;
using AcademyApi.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AcademyApi.V1.Gateways;

public class CouncilTaxSearchGateway : ICouncilTaxSearchGateway
{
    private readonly AcademyContext _academyContext;

    public CouncilTaxSearchGateway(AcademyContext academyContext)
    {
        _academyContext = academyContext;
    }

    public async Task<List<SearchResult>> GetAccountsByFullName(string firstName, string lastName)
    {
        string query = $@"
SELECT
  core.dbo.ctaccount.lead_liab_name,
  core.dbo.ctaccount.lead_liab_title,
  core.dbo.ctaccount.lead_liab_forename,
  core.dbo.ctaccount.lead_liab_surname,
  core.dbo.ctproperty.addr1,
  core.dbo.ctproperty.addr2,
  core.dbo.ctproperty.addr3,
  core.dbo.ctproperty.addr4,
  core.dbo.ctproperty.postcode,
  core.dbo.ctaccount.account_ref,
  core.dbo.ctaccount.account_cd
FROM core.dbo.ctaccount LEFT JOIN core.dbo.ctoccupation ON core.dbo.ctaccount.account_ref = core.dbo.ctoccupation.account_ref
                        LEFT JOIN core.dbo.ctproperty ON core.dbo.ctproperty.property_ref = core.dbo.ctoccupation.property_ref
WHERE core.dbo.ctoccupation.vacation_date IN(
  SELECT MAX(vacation_date) FROM core.dbo.ctoccupation WHERE core.dbo.ctoccupation.account_ref = core.dbo.ctaccount.account_ref)
  AND lead_liab_name LIKE '{lastName.ToUpper()}%{firstName.ToUpper()}';
";

        var foundResults = new List<SearchResult>();
        using (var command = _academyContext.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = query;
            command.CommandType = CommandType.Text;

            await _academyContext.Database.OpenConnectionAsync();

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    foundResults.Add(new SearchResult()
                    {
                        FullName = SafeGetString(reader, 0),
                        Title = SafeGetString(reader, 1),
                        FirstName = SafeGetString(reader, 2),
                        LastName = SafeGetString(reader, 3),
                        AddressLine1 = SafeGetString(reader, 4),
                        AddressLine2 = SafeGetString(reader, 5),
                        AddressLine3 = SafeGetString(reader, 6),
                        AddressLine4 = SafeGetString(reader, 7),
                        Postcode = SafeGetString(reader, 8),
                        AccountReference = SafeGetInt(reader, 9),
                        AccountCd = SafeGetString(reader, 10)
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
