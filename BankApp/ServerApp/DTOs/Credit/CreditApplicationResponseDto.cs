using System;

namespace ServerApp.DTOs.CreditApplication
{
    public class CreditApplicationResponseDto
    {
        public int ApplicationId { get; set; }
        public decimal Amount { get; set; }
        public int LoanTerm { get; set; }
        public decimal InstallmentAmount { get; set; }
        public decimal InterestRate { get; set; }
        public string BankName { get; set; }
        public string LoanTypeName { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
