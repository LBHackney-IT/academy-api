using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyApi.V1.Boundary.Response;
using AcademyApi.V1.Domain;
using AcademyApi.V1.Gateways.Interfaces;
using AcademyApi.V1.UseCase;
using Amazon.DynamoDBv2.DocumentModel;
using AutoFixture;
using FluentAssertions;
using Hackney.Core.Testing.Shared;
using Moq;
using NUnit.Framework;

namespace AcademyApi.Tests.V1.UseCase;

public class HousingBenefitsSearchUseCaseTests : LogCallAspectFixture
{
    private Mock<ISearchGateway> _mockGateway;
    private HousingBenefitsSearchUseCase _classUnderTest;
    private Fixture _fixture;

    [SetUp]
    public void Setup()
    {
        _mockGateway = new Mock<ISearchGateway>();
        _classUnderTest = new HousingBenefitsSearchUseCase(_mockGateway.Object);
        _fixture = new Fixture();
    }


    [Test]
    public async Task ReturnsAListOfSearchResponseObjects()
    {
        var firstName = _fixture.Create<string>();
        var lastName = _fixture.Create<string>();
        var stubbedResponse = _fixture.CreateMany<HousingBenefitsSearchResult>().ToList();

        // var stubbedResponse = new Mock<List<ISearchResult>>();

        _mockGateway.Setup(x => x.GetAccountsByFullName(firstName, lastName))
            .ReturnsAsync(stubbedResponse);

        var expectedResponse = new SearchResponseObjectList()
        {
            Error = null,
            Customers = new List<SearchResponseObject>()
        };

        var response = await _classUnderTest.Execute(firstName, lastName);

        response.Error.Should().BeEquivalentTo(expectedResponse.Error);
        response.Customers[0].Id.Should().BeEquivalentTo(stubbedResponse[0].ClaimId);
        response.Customers[0].FirstName.Should().BeEquivalentTo(stubbedResponse[0].FirstName);
        response.Customers[0].LastName.Should().BeEquivalentTo(stubbedResponse[0].LastName);
        response.Customers[0].FullAddress.Line1.Should().BeEquivalentTo(stubbedResponse[0].AddressLine1);
    }

    [Test]
    public async Task ReturnsAnErrorWhenNoResultsAreReturnedFromTheGateway()
    {
        var firstName = _fixture.Create<string>();
        var lastName = _fixture.Create<string>();
        _mockGateway.Setup(x => x.GetAccountsByFullName(firstName, lastName)).ReturnsAsync(new List<ISearchResult>());

        var expectedResponse = new SearchResponseObjectList() { Error = "No Results Found" };

        var response = await _classUnderTest.Execute(firstName, lastName);

        response.Should().BeEquivalentTo(expectedResponse);
    }



}
