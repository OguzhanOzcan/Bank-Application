namespace ServerApp.DTOs.Credit
{
    public class CreditCalculationResultDto
    {
        public int InstallmentNo { get; set; }
        public decimal InstallmentAmount { get; set; }
        public decimal PaidInterest { get; set; }
        public decimal PaidPrincipal { get; set; }
        public decimal RemainingPrincipal { get; set; }
    }
}

