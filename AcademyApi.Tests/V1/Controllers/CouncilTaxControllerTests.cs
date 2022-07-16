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
        private Mock<IGetCouncilTaxCustomerUseCase> _mockGetCouncilTaxCustomerUseCase;
        private Mock<IGetCouncilTaxNotesUseCase> _mockGetCouncilTaxNotesUseCase;

        [SetUp]
        public void SetUp()
        {
            _fixture = new Fixture();
            _mockCouncilTaxSearchUseCase = new Mock<ICouncilTaxSearchUseCase>();
            _mockGetCouncilTaxCustomerUseCase = new Mock<IGetCouncilTaxCustomerUseCase>();
            _mockGetCouncilTaxNotesUseCase = new Mock<IGetCouncilTaxNotesUseCase>();
            _classUnderTest = new CouncilTaxController(
                _mockCouncilTaxSearchUseCase.Object,
                _mockGetCouncilTaxCustomerUseCase.Object,
                _mockGetCouncilTaxNotesUseCase.Object
            );
        }

        [Test]
        public void SearchUseCaseIsCalled()
        {
            var dummyFirstName = _fixture.Create<string>();
            var dummyLastName = _fixture.Create<string>();
            _classUnderTest.Search(dummyFirstName, dummyLastName);

            _mockCouncilTaxSearchUseCase.Verify(x => x.Execute(dummyFirstName, dummyLastName), Times.Once);
        }

        [Test]
        public void GetCustomerUseCaseIsCalled()
        {
            var dummyCouncilTaxId = _fixture.Create<int>();
            _classUnderTest.ViewRecord(dummyCouncilTaxId);

            _mockGetCouncilTaxCustomerUseCase.Verify(x => x.Execute(dummyCouncilTaxId), Times.Once);
        }

        [Test]
        public void GetNotesUseCaseIsCalled()
        {
            var dummyCouncilTaxId = _fixture.Create<int>();
            _classUnderTest.GetNotes(dummyCouncilTaxId);

            _mockGetCouncilTaxNotesUseCase.Verify(x => x.Execute(dummyCouncilTaxId), Times.Once);
        }
    }
}
