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
        // TODO: Create test schema
        var expected = new HousingBenefitsSearchResult
        {
            ClaimId = null,
            CheckDigit = null,
            PersonReference = null,
            Title = null,
            FirstName = "",
            LastName = "",
            DateOfBirth = default,
            AddressLine1 = null,
            AddressLine2 = null,
            AddressLine3 = null,
            AddressLine4 = null,
            Postcode = null
        };

        var response = _classUnderTest.GetAccountsByFullName(expected.FirstName, expected.LastName).Result;
        expected.Should().Equals(response[0]);
    }
}
