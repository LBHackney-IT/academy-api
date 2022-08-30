using System;

namespace AcademyApi.V1.Domain;

public class PaymentDetails
{
    public int ClaimId { get; set; }
    public DateTime PostingDate { get; set; }
    public decimal PaymentAmount { get; set; }
}
