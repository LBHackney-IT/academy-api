using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using AcademyApi.V1.Domain;
using AcademyApi.V1.Factories;
using AcademyApi.V1.Gateways.Interfaces;
using AcademyApi.V1.Infrastructure;
using Microsoft.Data.SqlClient;
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

        string query = "SELECT lead_liab_name, lead_liab_title, lead_liab_forename, lead_liab_surname FROM dbo.ctaccount";

        var foundResults = new List<CouncilTaxSearchResultDbEntity>();
        using (var command = _academyContext.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = query;
            command.CommandType = CommandType.Text;

            await _academyContext.Database.OpenConnectionAsync();

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    foundResults.Add(new CouncilTaxSearchResultDbEntity() {
                        LeadLiabName = reader.GetFieldValueAsync<string>(0).Result,
                        LeadLiabTitle = reader.GetFieldValueAsync<string>(1).Result,
                        LeadLiabForename = reader.GetFieldValueAsync<string>(2).Result,
                        LeadLiabSurname = reader.GetFieldValueAsync<string>(3).Result
                    });
                }
            }
        }

        return foundResults.ToDomain();

        //
        // var movies = new List<CouncilTaxSearchResultDbEntity>();
        // //to get the connection string
        // //build the sqlconnection and execute the sql command
        // using (SqlConnection conn = new SqlConnection(_connectionstring))
        // {
        //     conn.Open();
        //     string commandtext = "SELECT lead_liab_name, lead_liab_title, lead_liab_forename, lead_liab_surname FROM testdb.dbo.ctaccount";
        //
        //     SqlCommand cmd = new SqlCommand(commandtext, conn);
        //
        //     var reader = cmd.ExecuteReader();
        //
        //     while (reader.Read())
        //     {
        //         var movie = new CouncilTaxSearchResultDbEntity()
        //         {
        //             LeadLiabName = reader["lead_liab_name"].ToString(),
        //             LeadLiabTitle = reader["lead_liab_title"].ToString(),
        //             LeadLiabForename = reader["lead_liab_forename"].ToString(),
        //             LeadLiabSurname = reader["lead_liab_surname"].ToString(),
        //         };
        //
        //         movies.Add(movie);
        //     }
        // }
        // return movies.ToDomain();


        // var results = new List<CouncilTaxSearchResultDbEntity>
        // {
        //     new CouncilTaxSearchResultDbEntity()
        //     {
        //         AccountRef = 30548418,
        //         AccountCd = "2", - check digit
        //         LeadLiabName = "SIMPSON,MR HOMER",
        //         LeadLiabTitle = "Mr",
        //         LeadLiabForename = "HOMER",
        //         LeadLiabSurname = "SIMPSON",
        //         Addr1 = "FLAT 1ST FLR",
        //         Addr2 = "2 EVERGREEN TERRACE",
        //         Addr3 = "LONDON",
        //         Addr4 = "",
        //         Postcode = "E8 2LN"
        //     },
        //     new CouncilTaxSearchResultDbEntity()
        //     {
        //         AccountRef = 30403567,
        //         AccountCd = "9",
        //         LeadLiabName = "SIMPSON,MR HOMER",
        //         LeadLiabTitle = "Mr",
        //         LeadLiabForename = "HOMER",
        //         LeadLiabSurname = "SIMPSON",
        //         Addr1 = "FLAT 1ST FLR",
        //         Addr2 = "2 EVERGREEN TERRACE",
        //         Addr3 = "LONDON",
        //         Addr4 = "",
        //         Postcode = "E8 2LN"
        //     },
        //     new CouncilTaxSearchResultDbEntity()
        //     {
        //         AccountRef = 30000003,
        //         AccountCd = "9",
        //         LeadLiabName = "SIMPSON,MR HOMER",
        //         LeadLiabTitle = "Mr",
        //         LeadLiabForename = "HOMER",
        //         LeadLiabSurname = "SIMPSON",
        //         Addr1 = "FLAT 1ST FLR",
        //         Addr2 = "2 EVERGREEN TERRACE",
        //         Addr3 = "LONDON",
        //         Addr4 = "",
        //         Postcode = "E8 2LN"
        //     }
        // };
        //
        // return results.ToDomain();
    }
}
