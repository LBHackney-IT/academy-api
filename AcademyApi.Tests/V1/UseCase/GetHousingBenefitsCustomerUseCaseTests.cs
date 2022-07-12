using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcademyApi.V1.Boundary.Response;
using AcademyApi.V1.Domain;
using AcademyApi.V1.Gateways.Interfaces;
using AcademyApi.V1.UseCase;
using AutoFixture;
using FluentAssertions;
using Hackney.Core.Testing.Shared;
using Moq;
using NUnit.Framework;
using Address = AcademyApi.V1.Boundary.Address;

namespace AcademyApi.Tests.V1.UseCase;

public class GetHousingBenefitsCustomerUseCaseTests : LogCallAspectFixture
{
    private Mock<IHousingBenefitsGateway> _mockGateway;
    private GetHousingBenefitsCustomerUseCase _classUnderTest;
    private Fixture _fixture = new();

    [SetUp]
    public void Setup()
    {
        _mockGateway = new Mock<IHousingBenefitsGateway>();
        _classUnderTest = new GetHousingBenefitsCustomerUseCase(_mockGateway.Object);
    }

    [Test]
    public async Task ExecuteReturnsHousingBenefitsRecord()
    {
        var stubBenefitsResponseObject = new BenefitsResponseObject
        {
            ClaimId = 5260765,
            CheckDigit = "6",
            PersonReference = 1,
            Title = "Ms",
            FirstName = "Elwira",
            LastName = "Moncur",
            DateOfBirth = new DateTime(1971, 12, 22),
            FullAddress = new Address()
            {
                Line1 = "6 Cascade Junction",
                Line2 = "49 Norway Maple Pass",
                Line3 = "LONDON",
                Line4 = null,
                Postcode = "I3 0RP",
            },
            PostCode = "I3 0RP",
            HouseholdMembers = new List<HouseHoldMember>()
            {
                new()
                {
                    Title = "Ms",
                    FirstName = "Elwira",
                    LastName = "Moncur",
                    DateOfBirth = new DateTime(1971, 12, 22),
                }
            },
            Benefits = null
        };
        var claimId = stubBenefitsResponseObject.ClaimId;
        var personRef = stubBenefitsResponseObject.PersonReference;
        _mockGateway.Setup(x =>
            x.GetCustomer(claimId, personRef)).ReturnsAsync(stubBenefitsResponseObject);

        var response = await _classUnderTest.Execute($"{claimId}/{personRef}");

        response.Should().BeEquivalentTo(stubBenefitsResponseObject);
    }

    [Test]
    public async Task ExecuteReturnsNullIfNotFound()
    {
        _mockGateway.Setup(x =>
            x.GetCustomer(1, 1)).ReturnsAsync((BenefitsResponseObject) null);

        var response = await _classUnderTest.Execute("1/1");

        response.Should().BeNull();
    }

    [Test]
    public async Task ExecuteReturnsNullIfInvalidBenefitsId()
    {
        var response = await _classUnderTest.Execute("1");

        response.Should().BeNull();
    }
}
