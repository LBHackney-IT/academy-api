using System;

namespace AcademyApi.V1.Domain
{
    // TODO: Find more fields from Academy
    public class HousingBenefitsRecord
    {
        public int AccountReference { get; set; }

        public string AccountCheckDigit { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal AccountBalance { get; set; }

        public Address PropertyAddress { get; set; }

        public Address ForwardingAddress { get; set; }
    }
}
