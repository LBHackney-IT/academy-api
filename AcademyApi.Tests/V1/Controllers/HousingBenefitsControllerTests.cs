using AcademyApi.V1.Boundary.Response;
using AcademyApi.V1.Controllers;
using AcademyApi.V1.UseCase.Interfaces;
using AutoFixture;
using FluentAssertions;
using Hackney.Core.Testing.Shared;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace AcademyApi.Tests.V1.Controllers
{
    [TestFixture]
    public class HousingBenefitsControllerTests : LogCallAspectFixture
    {
        private HousingBenefitsController _classUnderTest;
        private Mock<IHousingBenefitsSearchUseCase> _mockSearchUseCase;
        private Mock<IGetHousingBenefitsCustomerUseCase> _mockGetCustomerUseCase;
        private Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _fixture = new Fixture();
            _mockSearchUseCase = new Mock<IHousingBenefitsSearchUseCase>();
            _mockGetCustomerUseCase = new Mock<IGetHousingBenefitsCustomerUseCase>();
            _classUnderTest = new HousingBenefitsController(_mockSearchUseCase.Object, _mockGetCustomerUseCase.Object);
        }

        [Test]
        public void SearchUseCaseGetsCalledOnce()
        {
            var dummyFirstName = _fixture.Create<string>();
            var dummyLastName = _fixture.Create<string>();

            _classUnderTest.Search(dummyFirstName, dummyLastName);

            _mockSearchUseCase.Verify(x => x.Execute(dummyFirstName, dummyLastName), Times.Once);
        }

        [Test]
        public void ViewRecordGetCustomerUseCaseExecutesOnce()
        {
            string benefitsId = _fixture.Create<string>();

            _classUnderTest.ViewRecord(benefitsId);

            _mockGetCustomerUseCase.Verify(x => x.Execute(benefitsId), Times.Once);
        }

        [Test]
        public void ViewRecordReturnsSuccessResponse()
        {
            var benefitsId = _fixture.Create<string>();
            var stubBenefitsResponseObject = _fixture.Create<BenefitsResponseObject>();
            _mockGetCustomerUseCase.Setup(x =>
                x.Execute(benefitsId)).ReturnsAsync(stubBenefitsResponseObject);

            var response = _classUnderTest.ViewRecord(benefitsId);

            response.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public void ViewRecordReturnsNotFoundResponse()
        {
            var benefitsId = _fixture.Create<string>();
            _mockGetCustomerUseCase.Setup(x =>
                x.Execute(benefitsId)).ReturnsAsync((BenefitsResponseObject) null);

            var response = _classUnderTest.ViewRecord(benefitsId);

            response.Should().BeOfType<NotFoundObjectResult>();
        }
    }
}
