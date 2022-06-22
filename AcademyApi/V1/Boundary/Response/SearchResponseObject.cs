using System;

namespace AcademyApi.V1.Boundary.Response
{
    //Guidance on XML comments and response objects here (https://github.com/LBHackney-IT/lbh-base-api/wiki/Controllers-and-Response-Objects)

    public class SearchResponseObject
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NiNumber { get; set; }
        public Address FullAddress { get; set; }
        public string PostCode { get; set; }
        // TODO: consider returning housing benefits claim ID
    }

    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Line4 { get; set; }
        public string Postcode { get; set; }

    }
}
