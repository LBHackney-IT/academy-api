using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using AcademyApi.V1.Domain;
using AcademyApi.V1.Factories;
using AcademyApi.V1.Gateways.Interfaces;
using AcademyApi.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AcademyApi.V1.Gateways;

public class CouncilTaxSearchGateway : ICouncilTaxSearchGateway
{
    private readonly AcademyContext _academyContext;
    private readonly string _connectionstring;

    public CouncilTaxSearchGateway(AcademyContext academyContext, string connectionstring)
    {
        _academyContext = academyContext;
        _connectionstring = connectionstring;
    }

    public async Task<List<SearchResult>> GetAccountsByFullName(string fullName)
    {
        var foundResults = new List<CouncilTaxSearchResultDbEntity>();
        using (var command = _academyContext.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = $"SELECT account_ref, account_cd, lead_liab_title, lead_liab_name, lead_liab_forename, lead_liab_surname, for_addr1, for_addr2, for_addr3, for_addr4, for_postcode, paymeth_code FROM master.dbo.ctaccount where lead_liab_name like '{fullName}'";
            command.CommandType = CommandType.Text;

            await _academyContext.Database.OpenConnectionAsync();

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    foundResults.Add(new CouncilTaxSearchResultDbEntity()
                    {
                        AccountRef = reader.GetFieldValueAsync<int>("account_ref").Result,
                        AccountCd = reader.GetFieldValueAsync<string>("account_cd").Result,
                        LeadLiabTitle = reader.GetFieldValueAsync<string>("lead_liab_title").Result,
                        LeadLiabName = reader.GetFieldValueAsync<string>("lead_liab_name").Result,
                        LeadLiabForename = reader.GetFieldValueAsync<string>("lead_liab_forename").Result,
                        LeadLiabSurname = reader.GetFieldValueAsync<string>("lead_liab_surname").Result,
                        Addr1 = reader.GetFieldValueAsync<string>("for_addr1").Result,
                        Addr2 = reader.GetFieldValueAsync<string>("for_addr2").Result,
                        Addr3 = reader.GetFieldValueAsync<string>("for_addr3").Result,
                        Addr4 = reader.GetFieldValueAsync<string>("for_addr4").Result,
                        Postcode = reader.GetFieldValueAsync<string>("for_postcode").Result
                    });
                }
            }
        }
        return foundResults.ToDomain();
    }
}
