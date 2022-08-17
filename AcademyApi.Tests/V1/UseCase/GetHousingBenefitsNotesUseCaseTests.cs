using System.Collections.Generic;
using System.Threading.Tasks;
using AcademyApi.V1.Boundary;
using AcademyApi.V1.Gateways.Interfaces;
using AcademyApi.V1.UseCase;
using AutoFixture;
using Hackney.Core.Testing.Shared;
using Moq;
using NUnit.Framework;

namespace AcademyApi.Tests.V1.UseCase;

public class GetHousingBenefitsNotesUseCaseTests : LogCallAspectFixture
{
    private Mock<IHousingBenefitsGateway> _mockGateway;
    private GetHousingBenefitsNotesUseCase _classUnderTest;
    private Fixture _fixture;

    [SetUp]
    public void Setup()
    {
        _mockGateway = new Mock<IHousingBenefitsGateway>();
        _classUnderTest = new GetHousingBenefitsNotesUseCase(_mockGateway.Object);
        _fixture = new Fixture();
    }


    [Test]
    public async Task ReturnsAListOfNoteResponseObjects()
    {
        var dummyBenefitsId = "12345216";
        var stubbedRes = new List<Note>();
        var stubbedNote = new Note()
        {
            Username = "VHILL",
            StringId = "218415",
            Text = $@"User Id: gziregbe  Date: 31.03.2022 15:39:37  1017585577
HB and CTS assessed from 13/12/21
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
User Id: pthomas  Date: 16.02.2022 12:35:23  1013862923
TC from partner to check on coa sent in on ref JTVNNZJV, advised not yet and have also advised to provide his new TA and proof of the change in earnings as stated on form this has changed. Also advised will also need to send in last 2 monthly b/s. Clmt has requested a HSC app and this has been done. Also advised clmt that will have to make a claim for CTS as can
see this has never been paid.
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------"
        };
        stubbedRes.Add(stubbedNote);
        _mockGateway.Setup(x => x.GetNotes(1234521)).ReturnsAsync(stubbedRes);

        var res = await _classUnderTest.Execute(dummyBenefitsId);

        Assert.AreEqual("HB and CTS assessed from 13/12/21", res[0].Note);
        Assert.AreEqual("gziregbe", res[0].UserId);
        Assert.AreEqual("31.03.2022 15:39:37  1017585577", res[0].Date);
        Assert.AreEqual("TC from partner to check on coa sent in on ref JTVNNZJV, advised not yet and have also advised to provide his new TA and proof of the change in earnings as stated on form this has changed. Also advised will also need to send in last 2 monthly b/s. Clmt has requested a HSC app and this has been done. Also advised clmt that will have to make a claim for CTS as can\nsee this has never been paid.", res[1].Note);
        Assert.AreEqual("pthomas", res[1].UserId);
        Assert.AreEqual("16.02.2022 12:35:23  1013862923", res[1].Date);
    }

}
