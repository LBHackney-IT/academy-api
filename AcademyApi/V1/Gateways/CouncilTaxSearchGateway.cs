using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Threading.Tasks;
using AcademyApi.V1.Boundary;
using AcademyApi.V1.Domain;
using AcademyApi.V1.Gateways.Interfaces;
using AcademyApi.V1.Infrastructure;
using Hackney.Core.Logging;
using Microsoft.EntityFrameworkCore;
using Address = AcademyApi.V1.Domain.Address;

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

    [LogCall]
    public async Task<CouncilTaxRecord> GetCustomer(int accountRef)
    {
        string query = $@"
WITH ctoccupation_cte (
    account_ref,
    property_ref
  ) AS (
    SELECT TOP 1 account_ref, property_ref FROM ctoccupation WHERE
      ctoccupation.account_ref = ${accountRef}
    ORDER BY vacation_date DESC
)
SELECT distinct
  dbo.ctaccount.account_ref,
  dbo.ctaccount.account_cd,
  dbo.ctaccount.lead_liab_title,
  dbo.ctaccount.lead_liab_forename,
  dbo.ctaccount.lead_liab_surname,
  dbo.ctaccount.for_addr1,
  dbo.ctaccount.for_addr2,
  dbo.ctaccount.for_addr3,
  dbo.ctaccount.for_addr4,
  dbo.ctaccount.for_postcode,
  dbo.ctproperty.addr1,
  dbo.ctproperty.addr2,
  dbo.ctproperty.addr3,
  dbo.ctproperty.addr4,
  dbo.ctproperty.postcode,
  SUM(dbo.ctnotice.notice_balance) over (partition by dbo.ctnotice.account_ref ) as account_balance
  FROM
    dbo.ctaccount
    JOIN dbo.ctnotice on dbo.ctnotice.account_ref = ctaccount.account_ref
    JOIN ctoccupation_cte ON dbo.ctaccount.account_ref = ctoccupation_cte.account_ref
    JOIN dbo.ctproperty ON dbo.ctproperty.property_ref = ctoccupation_cte.property_ref
  WHERE
    dbo.ctaccount.account_ref = ${accountRef}
";
        var foundResults = new CouncilTaxRecord();
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

                                foundResults = new CouncilTaxRecord()
                                {
                                    AccountReference = SafeGetInt(reader, 0),
                                    AccountCheckDigit = SafeGetString(reader, 1),
                                    Title = SafeGetString(reader, 2),
                                    FirstName = SafeGetString(reader, 3),
                                    LastName = SafeGetString(reader, 4),
                                    ForwardingAddress = new Address()
                                    {
                                        Line1 = SafeGetString(reader, 5),
                                        Line2 = SafeGetString(reader, 6),
                                        Line3 = SafeGetString(reader, 7),
                                        Line4 = SafeGetString(reader, 8),
                                        Postcode = SafeGetString(reader, 9),
                                    },
                                    PropertyAddress = new Address()
                                    {
                                        Line1 = SafeGetString(reader, 10),
                                        Line2 = SafeGetString(reader, 11),
                                        Line3 = SafeGetString(reader, 12),
                                        Line4 = SafeGetString(reader, 13),
                                        Postcode = SafeGetString(reader, 14),
                                    },
                                    AccountBalance = SafeGetDecimal(reader, 15),
                                };
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

        [LogCall]
    public async Task<List<Note>> GetNotes(int accountRef)
    {
        string notePadQuery = $@"select user_id, notes_db_handle from dbo.ctnotepad where account_ref = {accountRef};";

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
                        Username = SafeGetString(reader, 0),
                        StringId = SafeGetString(reader, 1).Split(':')[1],
                    });
                }
            }
        }


        foreach (var note in foundNotes)
        {
            string noteQuery = $@"select text_value from dbo.ctnotes_so where string_id = {note.StringId};";

            using (var command = _academyContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = noteQuery;
                command.CommandType = CommandType.Text;

                await _academyContext.Database.OpenConnectionAsync();
                var reader = await command.ExecuteReaderAsync();
                using (reader)
                {
                    while (await reader.ReadAsync())
                    {
                        note.Text = SafeGetString(reader, 0);
                    }
                }
            }
        }
        return foundNotes;
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

    private static decimal SafeGetDecimal(DbDataReader reader, int colIndex)
    {
        if (!reader.IsDBNull(colIndex))
            return reader.GetDecimal(colIndex);
        return 0;
    }
}
