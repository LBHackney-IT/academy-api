using System;
using System.Collections.Generic;
using AcademyApi.V1.Domain;

namespace AcademyApi.V1.Boundary.Response
{
    //Guidance on XML comments and response objects here (https://github.com/LBHackney-IT/lbh-base-api/wiki/Controllers-and-Response-Objects)

    public class BenefitsResponseObject
    {
        public int ClaimId { get; set; }
        public string CheckDigit { get; set; }
        public int PersonReference { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NiNumber { get; set; }
        public Address FullAddress { get; set; }
        public string PostCode { get; set; }
        public List<HouseHoldMember> HouseholdMembers { get; set; }
        public List<Benefits> Benefits { get; set; }

        public HbInfo HousingBenefitDetails { get; set; }

        #nullable enable
        public HousingBenefitLandlordDetails? HousingBenefitLandlordDetails { get; set; }
        #nullable disable
    }

    public class HouseHoldMember
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class Benefits
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Period { get; set; }
        public int Frequency { get; set; }
    }

    public class HbInfo
    {
        public string HousingBenefitPayee { get; set; }
        public decimal WeeklyHousingBenefit { get; set; }

        public decimal PayeeInd { get; set; }
    }
}
