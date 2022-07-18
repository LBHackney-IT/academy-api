using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyApi.V1.Boundary;
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

public class GetCouncilTaxNotesUseCaseTests : LogCallAspectFixture
{
    private Mock<ICouncilTaxSearchGateway> _mockGateway;
    private GetCouncilTaxNotesUseCase _classUnderTest;
    private Fixture _fixture;

    [SetUp]
    public void Setup()
    {
        _mockGateway = new Mock<ICouncilTaxSearchGateway>();
        _classUnderTest = new GetCouncilTaxNotesUseCase(_mockGateway.Object);
        _fixture = new Fixture();
    }


    [Test]
    public async Task ReturnsAListOfSearchResponseObjects()
    {
        var dummyCouncilTaxId = _fixture.Create<int>();
        var stubbedRes = new List<Note>();
        var stubbedNote = new Note()
        {
            Username = "VHILL",
            StringId = "218415",
            Text =$@"spd awarded from 15/7/21 sole occupier as per tel cal received.
User Id: jisrael Date: 30.03.2022 11:57:36
--------------------------------------------------------------------------------
Move In Notes FLAT B, 24 BARNABAS ROAD
Acct created in new tenants name wef 15.7.2021 - See LL COA form received on 22.11.2021
User Id: yyasin Date: 21.12.2021 17:30:41
--------------------------------------------------------------------------------
"
        };
        stubbedRes.Add(stubbedNote);
        _mockGateway.Setup(x => x.GetNotes(dummyCouncilTaxId)).ReturnsAsync(stubbedRes);

        var res = await _classUnderTest.Execute(dummyCouncilTaxId);

        Assert.AreEqual("spd awarded from 15/7/21 sole occupier as per tel cal received.", res[0].Note);
        Assert.AreEqual("jisrael", res[0].UserId);
        Assert.AreEqual("30.03.2022 11:57:36", res[0].Date);
        Assert.AreEqual("Move In Notes FLAT B, 24 BARNABAS ROAD\nAcct created in new tenants name wef 15.7.2021 - See LL COA form received on 22.11.2021", res[1].Note);
        Assert.AreEqual("yyasin", res[1].UserId);
        Assert.AreEqual("21.12.2021 17:30:41", res[1].Date);
    }

}
