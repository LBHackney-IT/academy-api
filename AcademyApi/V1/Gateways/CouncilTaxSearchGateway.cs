using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using AcademyApi.V1.Domain;
using AcademyApi.V1.Gateways.Interfaces;
using AcademyApi.V1.Infrastructure;
using Hackney.Core.Logging;
using Microsoft.EntityFrameworkCore;

namespace AcademyApi.V1.Gateways;

public class CouncilTaxSearchGateway : ICouncilTaxSearchGateway
{
    private readonly AcademyContext _academyContext;

    public CouncilTaxSearchGateway(AcademyContext academyContext)
    {
        _academyContext = academyContext;
    }

    [LogCall]
    public async Task<List<CouncilTaxSearchResult>> GetAccountsByFullName(string firstName, string lastName)
    {
        Console.WriteLine("------------------");
        Console.WriteLine($"gateway searching: ${firstName} ${lastName}");
        Console.WriteLine("------------------");
        string query = $@"
SELECT
  dbo.ctaccount.lead_liab_name,
  dbo.ctaccount.lead_liab_title,
  dbo.ctaccount.lead_liab_forename,
  dbo.ctaccount.lead_liab_surname,
  dbo.ctproperty.addr1,
  dbo.ctproperty.addr2,
  dbo.ctproperty.addr3,
  dbo.ctproperty.addr4,
  dbo.ctproperty.postcode,
  dbo.ctaccount.account_ref,
  dbo.ctaccount.account_cd
FROM dbo.ctaccount LEFT JOIN dbo.ctoccupation ON dbo.ctaccount.account_ref = dbo.ctoccupation.account_ref
                        LEFT JOIN dbo.ctproperty ON dbo.ctproperty.property_ref = dbo.ctoccupation.property_ref
WHERE dbo.ctoccupation.vacation_date IN(
  SELECT MAX(vacation_date) FROM dbo.ctoccupation WHERE dbo.ctoccupation.account_ref = dbo.ctaccount.account_ref)
  AND lead_liab_name LIKE '{lastName.ToUpper()}%{firstName.ToUpper()}';
";
        var foundResults = new List<CouncilTaxSearchResult>();
        try
        {
            using (var command = _academyContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;


                try
                {
                    await _academyContext.Database.OpenConnectionAsync();
                    var reader = await command.ExecuteReaderAsync();
                    using (reader)
                    {
                        try
                        {
                            while (await reader.ReadAsync())
                            {
                                Console.WriteLine("******************");
                                Console.WriteLine("reading result");
                                Console.WriteLine("******************");

                                foundResults.Add(new CouncilTaxSearchResult()
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
                        catch (Exception e)
                        {
                            Console.WriteLine("******************");
                            Console.WriteLine("--- error running command:");
                            Console.WriteLine(e);

                            Console.WriteLine("******************");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("000000000000000");
                    Console.WriteLine("--- error opening connection");

                    Console.WriteLine(e);
                    Console.WriteLine("000000000000000");

                    throw;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("******************");
            Console.WriteLine("--- error creating command:");
            Console.WriteLine(e);

            Console.WriteLine("******************");

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
