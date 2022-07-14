using System;

namespace AcademyApi.V1.Domain
{
    public class CouncilTaxRecord
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

    public class Address
    {
        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string Line3 { get; set; }

        public string Line4 { get; set; }

        public string Postcode { get; set; }
    }
}
