using AcademyApi.V1.Domain;
using AcademyApi.V1.Gateways;
using FluentAssertions;
using NUnit.Framework;

namespace AcademyApi.Tests.V1.Gateways;

public class CouncilTaxSearchGatewayTests : DatabaseTests
{
    private CouncilTaxSearchGateway _classUnderTest;

    [SetUp]
    public void Setup()
    {
        _classUnderTest = new CouncilTaxSearchGateway(AcademyContext);
    }

    [Test]
    public void GetsEntityMatchingQuery()
    {
        var expected = new SearchResult()
        {
            AccountCd = "5",
            AccountReference = 815631207,
            AddressLine1 = "5 Northfield Park",
            AddressLine2 = "58 Muir Plaza",
            AddressLine3 = "LONDON",
            AddressLine4 = "",
            FirstName = "Nady",
            FullName = "COOKE,MS NADY",
            LastName = "Cooke",
            Postcode = "T9 7KR",
            Title = "Ms"
        };

        var response = _classUnderTest.GetAccountsByFullName(expected.FirstName, expected.LastName).Result;
        expected.Should().Equals(response[0]);
    }
}
