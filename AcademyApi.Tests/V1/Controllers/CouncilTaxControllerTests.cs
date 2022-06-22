using AcademyApi.V1.Controllers;
using AcademyApi.V1.UseCase.Interfaces;
using AutoFixture;
using Hackney.Core.Testing.Shared;
using Moq;
using NUnit.Framework;

namespace AcademyApi.Tests.V1.Controllers
{
    [TestFixture]
    public class CouncilTaxControllerTests : LogCallAspectFixture
    {
        private CouncilTaxController _classUnderTest;
        private Mock<ICouncilTaxSearchUseCase> _mockCouncilTaxSearchUseCase;
        private Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _fixture = new Fixture();
            _mockCouncilTaxSearchUseCase = new Mock<ICouncilTaxSearchUseCase>();
            _classUnderTest = new CouncilTaxController(_mockCouncilTaxSearchUseCase.Object);
        }

        [Test]
        public void SearchUsecaseIsCalled()
        {
            var dummyFirstName = _fixture.Create<string>();
            var dummyLastName = _fixture.Create<string>();
            _classUnderTest.Search(dummyFirstName, dummyLastName);

            _mockCouncilTaxSearchUseCase.Verify(x => x.Execute(dummyFirstName, dummyLastName), Times.Once);

        }
    }
}
