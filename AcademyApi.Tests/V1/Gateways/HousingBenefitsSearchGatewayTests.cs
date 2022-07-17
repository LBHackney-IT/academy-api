using System;
using AcademyApi.V1.Boundary;
using AcademyApi.V1.Domain;
using AcademyApi.V1.Gateways;
using FluentAssertions;
using NUnit.Framework;

namespace AcademyApi.Tests.V1.Gateways;

public class HousingBenefitsSearchGatewayTests : DatabaseTests
{
    private HousingBenefitsSearchGateway _classUnderTest;

    [SetUp]
    public void Setup()
    {
        _classUnderTest = new HousingBenefitsSearchGateway(AcademyContext);
    }

    [Test]
    public void GetsEntityMatchingQuery()
    {
        var expected = new HousingBenefitsSearchResult
        {
            ClaimId = 5260765,
            CheckDigit = "6",
            PersonReference = 1,
            Title = "Ms",
            FirstName = "Elwira",
            LastName = "Moncur",
            DateOfBirth = new DateTime(1971, 12, 22),
            NiNumber = "CD877332Z",
            AddressLine1 = "6 Cascade Junction",
            AddressLine2 = "49 Norway Maple Pass",
            AddressLine3 = "LONDON",
            AddressLine4 = null,
            Postcode = "I3 0RP",
            AddressToDate = new DateTime(2099, 12, 31)
        };

        var response = _classUnderTest.GetAccountsByFullName(expected.FirstName, expected.LastName).Result;

        expected.Should().Equals(response[0]);
    }

    [Test]
    public void GetsNotes()
    {
        var expected = new Note()
        {
            Username = "gziregbe",
            StringId = "67788",
            NoteType = "General",
            Text =$@"User Id: gziregbe  Date: 31.03.2022 15:39:37  1017585577
HB and CTS assessed from 13/12/21
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
User Id: pthomas  Date: 16.02.2022 12:35:23  1013862923
TC from partner to check on coa sent in on ref JTVNNZJV, advised not yet and have also advised to provide his new TA and proof of the change in earnings as stated on form this has changed. Also advised will also need to send in last 2 monthly b/s. Clmt has requested a HSC app and this has been done. Also advised clmt that will have to make a claim for CTS as can
see this has never been paid.
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------"
        };

        var response = _classUnderTest.GetNotes(5448076).Result;
        Assert.AreEqual(expected.Username, response[0].Username);
        Assert.AreEqual(expected.StringId, response[0].StringId);
        Assert.AreEqual(expected.NoteType, response[0].NoteType);
        Assert.AreEqual(expected.Text, response[0].Text);
        Assert.AreEqual(2, response.Count);
    }
}
