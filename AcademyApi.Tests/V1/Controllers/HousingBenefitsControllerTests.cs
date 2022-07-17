using AcademyApi.V1.Controllers;
using AcademyApi.V1.UseCase.Interfaces;
using AutoFixture;
using Hackney.Core.Testing.Shared;
using Moq;
using NUnit.Framework;

namespace AcademyApi.Tests.V1.Controllers
{
    [TestFixture]
    public class HousingBenefitsControllerTests : LogCallAspectFixture
    {
        private HousingBenefitsController _classUnderTest;
        private Mock<IHousingBenefitsSearchUseCase> _mockSearchUseCase;
        private Fixture _fixture;
        private Mock<IGetHousingBenefitsNotesUseCase> _mockGetHousingBenefitsNotesUseCase;

        [SetUp]
        public void SetUp()
        {
            _fixture = new Fixture();
            _mockSearchUseCase = new Mock<IHousingBenefitsSearchUseCase>();
            _mockGetHousingBenefitsNotesUseCase = new Mock<IGetHousingBenefitsNotesUseCase>();
            _classUnderTest = new HousingBenefitsController(_mockSearchUseCase.Object, _mockGetHousingBenefitsNotesUseCase.Object);
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
        public void GetNotesUseCaseIsCalled()
        {
            var dummyClaimId = _fixture.Create<int>();
            _classUnderTest.GetNotes(dummyClaimId);

            _mockGetHousingBenefitsNotesUseCase.Verify(x => x.Execute(dummyClaimId), Times.Once);
        }
    }
}
