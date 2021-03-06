using System.Linq;
using AcademyApi.V1.Boundary.Response;
using AcademyApi.V1.Domain;
using AcademyApi.V1.Gateways;
using AcademyApi.V1.UseCase;
using AutoFixture;
using AcademyApi.V1.Factories;
using FluentAssertions;
using Hackney.Core.Testing.Shared;
using Moq;
using NUnit.Framework;

namespace AcademyApi.Tests.V1.UseCase
{
    public class GetAllUseCaseTests : LogCallAspectFixture
    {
        private Mock<IExampleGateway> _mockGateway;
        private GetAllUseCase _classUnderTest;
        private Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _mockGateway = new Mock<IExampleGateway>();
            _classUnderTest = new GetAllUseCase(_mockGateway.Object);
            _fixture = new Fixture();
        }

        [Test]
        public void GetsAllFromTheGateway()
        {
            var stubbedEntities = _fixture.CreateMany<CouncilTaxSearchResult>().ToList();
            _mockGateway.Setup(x => x.GetAll()).Returns(stubbedEntities);

            var expectedResponse = new SearchResponseObjectList { Customers = stubbedEntities.ToResponse() };

            _classUnderTest.Execute().Should().BeEquivalentTo(expectedResponse);
        }

        //TODO: Add extra tests here for extra functionality added to the use case
    }
}
