using System;
using AcademyApi.V1.Boundary.Response;
using AcademyApi.V1.Domain;
using AcademyApi.V1.Gateways;
using FluentAssertions;
using NUnit.Framework;

namespace AcademyApi.Tests.V1.Gateways;

public class HousingBenefitsSearchGatewayTests : DatabaseTests
{
    private HousingBenefitsGateway _classUnderTest;

    [SetUp]
    public void Setup()
    {
        _classUnderTest = new HousingBenefitsGateway(AcademyContext);
    }

    [Test]
    public void GetAccountsByFullNameReturnsHousingBenefitsSearchResultList()
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

    [Test]
    public void GetCustomerReturnsHousingBenefitsRecord()
    {
        var expected = new BenefitsResponseObject
        {
            ClaimId = 0,
            CheckDigit = null,
            PersonReference = 0,
            Title = null,
            FirstName = null,
            LastName = null,
            DateOfBirth = default,
            FullAddress = null,
            PostCode = null,
            HouseholdMembers = null,
            Benefits = null
        };

        var response = _classUnderTest.GetCustomer(1, 1).Result;

        response.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void GetCustomerReturnsNullIfNotFound()
    {
        var response = _classUnderTest.GetCustomer(1, 1).Result;

        response.Should().BeNull();
    }
}
