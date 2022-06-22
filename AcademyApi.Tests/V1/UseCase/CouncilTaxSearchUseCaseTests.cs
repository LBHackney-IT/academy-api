using AcademyApi.V1.Boundary.Response;
using AcademyApi.V1.Gateways.Interfaces;
using AcademyApi.V1.UseCase;
using AutoFixture;
using FluentAssertions;
using Hackney.Core.Testing.Shared;
using Moq;
using NUnit.Framework;

namespace AcademyApi.Tests.V1.UseCase;

public class CouncilTaxSearchUseCaseTests : LogCallAspectFixture
{
    private Mock<ICouncilTaxSearchGateway> _mockGateway;
    private CouncilTaxSearchUseCase _classUnderTest;
    private Fixture _fixture;

    [SetUp]
    public void Setup()
    {
        _mockGateway = new Mock<ICouncilTaxSearchGateway>();
        _classUnderTest = new CouncilTaxSearchUseCase(_mockGateway.Object);
        _fixture = new Fixture();
    }


    [Test]
    public void ReturnsAListOfSearchResponseObjects()
    {
        var firstName = _fixture.Create<string>();
        var lastName = _fixture.Create<string>();
        var stubbedResponse = _fixture.Create<SearchResponseObjectList>();
        _mockGateway.Setup(x => x.GetAll()).Returns(stubbedResponse);

        var expectedResponse = new SearchResponseObjectList();

        _classUnderTest.Execute(firstName, lastName).Should().BeEquivalentTo(expectedResponse);
    }

    [Test]
    public void ReturnsAnErrorWhenAnErrorIsReturnedFromTheGateway()
    {
        var firstName = _fixture.Create<string>();
        var lastName = _fixture.Create<string>();
        _mockGateway.Setup(x => x.GetAll()).Returns("Error");

        var expectedResponse = new SearchResponseObjectList() { Error = "Error returned from Search" };

        _classUnderTest.Execute(firstName, lastName).Should().BeEquivalentTo(expectedResponse);
    }



}
