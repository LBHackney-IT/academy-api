using System;
using AcademyApi.V1.Domain;
using AcademyApi.V1.Gateways;
using FluentAssertions;
using NUnit.Framework;

namespace AcademyApi.Tests.V1.Gateways;

public class HousingBenefitsSearchGatewayTests : DatabaseTests
{
    private HousingBenefitsSearchGateway _classUnderTest;

    [SetUp]
    public void Setup()
    {
        _classUnderTest = new HousingBenefitsSearchGateway(AcademyContext);
    }

    [Test]
    public void GetsEntityMatchingQuery()
    {
        var expected = new HousingBenefitsSearchResult
        {
            ClaimId = 5260765,
            CheckDigit = "6",
            PersonReference = 1,
            Title = "Ms",
            FirstName = "Elwira",
            LastName = "Moncur",
            DateOfBirth = new DateTime(1971, 12, 22),
            NiNumber = "CD877332Z",
            AddressLine1 = "6 Cascade Junction",
            AddressLine2 = "49 Norway Maple Pass",
            AddressLine3 = "LONDON",
            AddressLine4 = null,
            Postcode = "I3 0RP",
            AddressToDate = new DateTime(2099, 12, 31)
        };

        var response = _classUnderTest.GetAccountsByFullName(expected.FirstName, expected.LastName).Result;

        expected.Should().Equals(response[0]);
    }
}
