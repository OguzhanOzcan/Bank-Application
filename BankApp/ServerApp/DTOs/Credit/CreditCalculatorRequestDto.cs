namespace ServerApp.DTOs.Credit
{
    public class CreditCalculatorRequestDto
    {
        public decimal Amount { get; set; }
        public int Term { get; set; }
        public decimal InterestRate { get; set; }
    }
}