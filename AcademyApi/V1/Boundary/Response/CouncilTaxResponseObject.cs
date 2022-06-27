using System;

namespace AcademyApi.V1.Boundary.Response
{
    //Guidance on XML comments and response objects here (https://github.com/LBHackney-IT/lbh-base-api/wiki/Controllers-and-Response-Objects)

    public class CouncilTaxResponseObject
    {
        public string AccountReference { get; set; }
        public string CheckDigit { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal AccountBalance { get; set; }
        public string PaymentMethod { get; set; }
        public Address FullAddress { get; set; }
        public string PostCode { get; set; }
        // TODO: consider returning housing benefits claim ID
    }
}
