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
    public void GetAccountsByFullName()
    {
        var expected = new CouncilTaxSearchResult()
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

    [Test]
    public void GetsCustomer()
    {
        var expected = new CouncilTaxRecord()
        {
            AccountCheckDigit = "5",
            AccountReference = 815631207,
            PropertyAddress = new Address()
            {
                AddressLine1 = "5 Northfield Park",
                AddressLine2 = "58 Muir Plaza",
                AddressLine3 = "LONDON",
                AddressLine4 = "",
                Postcode = "T9 7KR",
            },
            ForwardingAddress = new Address(),
            FirstName = "Nady",
            LastName = "Cooke",
            Title = "Ms",
            AccountBalance = (decimal)2228.00
        };

        var response = _classUnderTest.GetCustomer(815631207).Result;
        expected.Should().Equals(response);
    }

}
