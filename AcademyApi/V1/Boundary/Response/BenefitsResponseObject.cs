using System;
using System.Collections.Generic;

namespace AcademyApi.V1.Boundary.Response
{
    //Guidance on XML comments and response objects here (https://github.com/LBHackney-IT/lbh-base-api/wiki/Controllers-and-Response-Objects)

    public class BenefitsResponseObject
    {
        public string ClaimId { get; set; }
        public string CheckDigit { get; set; }
        public string PersonReference { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Address FullAddress { get; set; }
        public string PostCode { get; set; }
        public List<HouseHoldMember> HouseholdMembers { get; set; }
        public List<Benefits> Benefits { get; set; }
        // TODO: consider returning housing benefits claim ID
    }

    public abstract class HouseHoldMember
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
    public abstract class Benefits
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Period { get; set; }
        public string Frequency { get; set; }
    }
}