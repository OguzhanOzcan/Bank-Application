namespace ServerApp.DTOs.CreditApplication
{
    public class CreditApplicationRequestDto
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public int BankId { get; set; }
        public int LoanTypeId { get; set; }
        public decimal Amount { get; set; }
        public int Term { get; set; }
        public decimal InterestRate { get; set; } 
    }
}
