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

public class GetCouncilTaxCustomerUseCaseTests : LogCallAspectFixture
{
    private Mock<ICouncilTaxSearchGateway> _mockGateway;
    private GetCouncilTaxCustomerUseCase _classUnderTest;
    private Fixture _fixture;

    [SetUp]
    public void Setup()
    {
        _mockGateway = new Mock<ICouncilTaxSearchGateway>();
        _classUnderTest = new GetCouncilTaxCustomerUseCase(_mockGateway.Object);
        _fixture = new Fixture();
    }


    [Test]
    public async Task ReturnsAListOfSearchResponseObjects()
    {
        var dummyCouncilTaxId = _fixture.Create<int>();

        var _ = await _classUnderTest.Execute(dummyCouncilTaxId);

        _mockGateway.Verify(x => x.GetCustomer(dummyCouncilTaxId), Times.Once);
    }

}
