using System;
using System.Collections.Generic;
using AcademyApi.V1.Boundary;
using AcademyApi.V1.Boundary.Response;

namespace AcademyApi.V1.Domain
{
    public class HousingBenefitsSearchResult : ISearchResult
    {
        public string ClaimId { get; set; }

        public string CheckDigit { get; set; }

        public string PersonReference { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string AddressLine4 { get; set; }

        public string Postcode { get; set; }
    }
}
