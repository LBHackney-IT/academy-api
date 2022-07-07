using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyApi.V1.Domain;
using AcademyApi.V1.Gateways.Interfaces;
using AcademyApi.V1.UseCase;
using AutoFixture;
using FluentAssertions;
using Hackney.Core.Testing.Shared;
using Moq;
using NUnit.Framework;

namespace AcademyApi.Tests.V1.UseCase;

public class HousingBenefitsSearchUseCaseTests : LogCallAspectFixture
{
    private Mock<IHousingBenefitsSearchGateway> _mockHousingBenefitsSearchGateway;
    private HousingBenefitsSearchUseCase _classUnderTest;
    private Fixture _fixture;

    [SetUp]
    public void Setup()
    {
        _mockHousingBenefitsSearchGateway = new Mock<IHousingBenefitsSearchGateway>();
        _classUnderTest = new HousingBenefitsSearchUseCase(_mockHousingBenefitsSearchGateway.Object);
        _fixture = new Fixture();
    }

    [Test]
    public async Task ReturnsAListOfSearchResponseObjects()
    {
        var firstName = _fixture.Create<string>();
        var lastName = _fixture.Create<string>();
        var stubbedResponse = _fixture.CreateMany<HousingBenefitsSearchResult>(3).ToList();

        _mockHousingBenefitsSearchGateway.Setup(x =>
            x.GetAccountsByFullName(firstName, lastName)).ReturnsAsync(stubbedResponse);

        var response = await _classUnderTest.Execute(firstName, lastName);

        response.Customers.Count.Should().Be(3);
    }

    [Test]
    public async Task ReturnsAnErrorWhenNoResultsAreReturnedFromTheGateway()
    {
        var firstName = _fixture.Create<string>();
        var lastName = _fixture.Create<string>();

        _mockHousingBenefitsSearchGateway.Setup(x =>
            x.GetAccountsByFullName(firstName, lastName)).ReturnsAsync(new List<HousingBenefitsSearchResult>());

        var response = await _classUnderTest.Execute(firstName, lastName);

        response.Error.Should().Be("No Results Found");
    }
}
