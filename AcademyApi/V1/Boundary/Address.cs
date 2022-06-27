using System;

namespace AcademyApi.V1.Boundary
{
    public abstract class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Line4 { get; set; }
        public string Postcode { get; set; }

    }
}
