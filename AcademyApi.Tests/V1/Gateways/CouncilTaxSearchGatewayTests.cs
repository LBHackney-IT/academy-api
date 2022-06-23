using AcademyApi.Tests.V1.Helper;
using AcademyApi.V1.Domain;
using AcademyApi.V1.Gateways;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;

namespace AcademyApi.Tests.V1.Gateways;

public class CouncilTaxSearchGatewayTests : DatabaseTests
{
    private readonly Fixture _fixture = new();
    private CouncilTaxSearchGateway _classUnderTest;

    [SetUp]
    public void Setup()
    {
        _classUnderTest = new CouncilTaxSearchGateway(AcademyContext, "Server=localhost,1433;Database=testdb;User Id=sa;Password=MyP@w0rd;");
    }

    [Test]
    public void GetsEntityMatchingQuery()
    {

        var firstName = _fixture.Create<string>();
        var lastName = _fixture.Create<string>();
        var entity = _fixture.Build<SearchResult>().With(x => x.FirstName, firstName).With(x => x.LastName, lastName)
            .Create();
        var fullName = $"{lastName}%{firstName}";
        var databaseEntity = DatabaseEntityHelper.CreateDatabaseEntityFrom(entity);

        // AcademyContext.CouncilTaxSearchResultDbEntities.Add(databaseEntity);
        // AcademyContext.SaveChanges();

        var response = _classUnderTest.GetAccountsByFullName(fullName);

        databaseEntity.AccountRef.Should().Be(response[0].AccountReference);
    }

}
