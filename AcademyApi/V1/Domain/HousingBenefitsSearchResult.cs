using System;

namespace AcademyApi.V1.Domain;

public class HousingBenefitsSearchResult
{
    public int ClaimId { get; set; }

    public string CheckDigit { get; set; }

    public int PersonReference { get; set; }

    public string Title { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string NiNumber { get; set; }

    public string AddressLine1 { get; set; }

    public string AddressLine2 { get; set; }

    public string AddressLine3 { get; set; }

    public string AddressLine4 { get; set; }

    public string Postcode { get; set; }

    public DateTime AddressToDate { get; set; }
}
