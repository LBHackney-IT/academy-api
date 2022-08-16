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
    private readonly Fixture _fixture = new();

    [SetUp]
    public void Setup()
    {
        _mockGateway = new Mock<IHousingBenefitsGateway>();
        _classUnderTest = new GetHousingBenefitsCustomerUseCase(_mockGateway.Object);
    }

    [Test]
    public async Task ExecuteReturnsHousingBenefitsRecord()
    {
        var claimId = 5189543;
        var checkDigit = 6;
        var stubBenefitsResponseObject = _fixture.Build<BenefitsResponseObject>()
            .With(o => o.ClaimId, claimId)
            .With(o => o.CheckDigit, checkDigit.ToString())
            .Without(o => o.Benefits)
            .Create();
        var stubBenefits = _fixture.CreateMany<Benefits>().ToList();
        _mockGateway.Setup(x =>
            x.GetCustomer(claimId, checkDigit)).ReturnsAsync(stubBenefitsResponseObject);
        _mockGateway.Setup(x =>
            x.GetBenefits(claimId)).ReturnsAsync(stubBenefits);

        var response = await _classUnderTest
            .Execute($"{claimId}{checkDigit}");

        response.Should().BeEquivalentTo(stubBenefitsResponseObject);
    }

    [Test]
    public async Task ExecuteReturnsNullIfNotFound()
    {
        _mockGateway.Setup(x =>
            x.GetCustomer(1, 1)).ReturnsAsync((BenefitsResponseObject) null);

        var response = await _classUnderTest.Execute($"11654342");

        response.Should().BeNull();
    }

    [Test]
    public async Task ExecuteReturnsNullIfInvalidBenefitsId()
    {
        var response = await _classUnderTest.Execute("16553465");

        response.Should().BeNull();
    }
}
