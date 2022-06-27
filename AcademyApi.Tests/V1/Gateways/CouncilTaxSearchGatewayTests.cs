using System;
using AcademyApi.V1.Gateways;
using NUnit.Framework;

namespace AcademyApi.Tests.V1.Gateways;

public class CouncilTaxSearchGatewayTests : DatabaseTests
{
    private readonly string _connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
    private CouncilTaxSearchGateway _classUnderTest;

    [SetUp]
    public void Setup()
    {
        _classUnderTest = new CouncilTaxSearchGateway(AcademyContext, _connectionString);
    }

    [Test]
    public void GetsEntityMatchingQuery()
    {
        var accountReference = 3472806;
        var firstName = "worthy";
        var lastName = "goulbourn";
        var response = _classUnderTest.GetAccountsByFullName($"{lastName}%{firstName}").Result;

        Assert.AreEqual(response[0].AccountReference, accountReference);
        Assert.AreEqual(response[0].FirstName.ToLower(), firstName);
        Assert.AreEqual(response[0].LastName.ToLower(), lastName);
    }
}
