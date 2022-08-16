using AcademyApi.V1.Boundary;
using AcademyApi.V1.Domain;
using AcademyApi.V1.Gateways;
using NUnit.Framework;
using Address = AcademyApi.V1.Domain.Address;

namespace AcademyApi.Tests.V1.Gateways;

public class CouncilTaxSearchGatewayTests : DatabaseTests
{
    private CouncilTaxSearchGateway _classUnderTest;

    [SetUp]
    public void Setup()
    {
        _classUnderTest = new CouncilTaxSearchGateway(AcademyContext);
    }

    [Test]
    public void GetAccountsByFullName()
    {
        var firstName = "Nady";
        var lastName = "Cooke";

        var response = _classUnderTest.GetAccountsByFullName(firstName, lastName).Result;
        Assert.AreEqual("5", response[0].AccountCd);
        Assert.AreEqual(815631207, response[0].AccountReference);
        Assert.AreEqual("5 Northfield Park", response[0].AddressLine1);
        Assert.AreEqual("58 Muir Plaza", response[0].AddressLine2);
        Assert.AreEqual("LONDON", response[0].AddressLine3);
        Assert.AreEqual("", response[0].AddressLine4);
        Assert.AreEqual(firstName, response[0].FirstName);
        Assert.AreEqual("COOKE,MS NADY", response[0].FullName);
        Assert.AreEqual(lastName, response[0].LastName);
        Assert.AreEqual("T9 7KR", response[0].Postcode);
        Assert.AreEqual("Ms", response[0].Title);

    }

    [Test]
    public void GetsCustomer()
    {
        var expected = new CouncilTaxRecord()
        {
            AccountCheckDigit = "5",
            AccountReference = 815631207,
            PropertyAddress = new Address()
            {
                Line1 = "5 Northfield Park",
                Line2 = "58 Muir Plaza",
                Line3 = "LONDON",
                Line4 = "",
                Postcode = "T9 7KR",
            },
            ForwardingAddress = new Address(),
            FirstName = "Nady",
            LastName = "Cooke",
            Title = "Ms",
            AccountBalance = (decimal) 2228.00
        };

        var response = _classUnderTest.GetCustomer(815631207).Result;
        Assert.AreEqual(expected.AccountCheckDigit, response.AccountCheckDigit);
        Assert.AreEqual(expected.AccountReference, response.AccountReference);
        Assert.AreEqual(expected.PropertyAddress.Line1, response.PropertyAddress.Line1);
        Assert.AreEqual(expected.PropertyAddress.Line2, response.PropertyAddress.Line2);
        Assert.AreEqual(expected.PropertyAddress.Line3, response.PropertyAddress.Line3);
        Assert.AreEqual(expected.PropertyAddress.Line4, response.PropertyAddress.Line4);
        Assert.AreEqual(expected.PropertyAddress.Postcode, response.PropertyAddress.Postcode);
        Assert.AreEqual(expected.FirstName, response.FirstName);
        Assert.AreEqual(expected.LastName, response.LastName);
        Assert.AreEqual(expected.Title, response.Title);
        Assert.AreEqual(expected.AccountBalance, response.AccountBalance);


    }

    [Test]
    public void GetsNotes()
    {
        var expected = new Note()
        {
            Username = "VHILL",
            StringId = "218415",
            Text = $@"ms rosenburg set up as per ctb memo...ni
User id : OIBITOYE Date : 12.12.2000
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- TAX PAYER CALLED SHOULD BE GETTING FULL H/B HAVE ADVISED TO SPEAK TO H/BENEFIT....FERNANDA 12/9/2002
User id : FTOUSSAI Date : 12.09.2002

TC FRM TP STATES AWAITING CTB, ADV. WILL CANX SUMMONS ONCE CTB AWARDED
User Id: skerr  Date: 09.09.2003 16:57:03
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
"
        };

        var response = _classUnderTest.GetNotes(30532993).Result;
        Assert.AreEqual(expected.Username, response[0].Username);
        Assert.AreEqual(expected.StringId, response[0].StringId);
        Assert.AreEqual(expected.Text, response[0].Text);
        Assert.AreEqual(2, response.Count);
    }

}
