namespace AcademyApi.V1.Domain;

public class HousingBenefitLandlordDetails
{
    public int ClaimId { get; set; }
    public string Name { get; set; }

    #nullable enable
    public string? Addr1 { get; set; }
    public string? Addr2 { get; set; }
    public string? Addr3 { get; set; }
    public string? Addr4 { get; set; }
    public string? Postcode { get; set; }

    #nullable disable
    public int CreditorId { get; set; }
}
