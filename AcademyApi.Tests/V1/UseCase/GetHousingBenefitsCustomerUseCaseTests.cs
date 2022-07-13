using System.Linq;
using System.Threading.Tasks;
using AcademyApi.V1.Boundary.Response;
using AcademyApi.V1.Gateways.Interfaces;
using AcademyApi.V1.UseCase;
using AutoFixture;
using FluentAssertions;
using Hackney.Core.Testing.Shared;
using Moq;
using NUnit.Framework;

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
        var claimId = _fixture.Create<int>();
        var personReference = _fixture.Create<int>();
        var stubBenefitsResponseObject = _fixture.Build<BenefitsResponseObject>()
            .With(o => o.ClaimId, claimId)
            .With(o => o.PersonReference, personReference)
            .Without(o => o.Benefits)
            .Create();
        var stubBenefits = _fixture.CreateMany<Benefits>().ToList();
        _mockGateway.Setup(x =>
            x.GetCustomer(claimId, personReference)).ReturnsAsync(stubBenefitsResponseObject);
        _mockGateway.Setup(x =>
            x.GetBenefits(claimId)).ReturnsAsync(stubBenefits);

        var response = await _classUnderTest
            .Execute($"{claimId}{GetHousingBenefitsCustomerUseCase.IdSeparator}{personReference}");

        response.Should().BeEquivalentTo(stubBenefitsResponseObject);
    }

    [Test]
    public async Task ExecuteReturnsNullIfNotFound()
    {
        _mockGateway.Setup(x =>
            x.GetCustomer(1, 1)).ReturnsAsync((BenefitsResponseObject) null);

        var response = await _classUnderTest.Execute($"1{GetHousingBenefitsCustomerUseCase.IdSeparator}1");

        response.Should().BeNull();
    }

    [Test]
    public async Task ExecuteReturnsNullIfInvalidBenefitsId()
    {
        var response = await _classUnderTest.Execute("1");

        response.Should().BeNull();
    }
}
