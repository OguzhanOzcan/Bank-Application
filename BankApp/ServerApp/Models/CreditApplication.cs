using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerApp.Models
{
    public class CreditApplication
    {
        [Key]
        public int ApplicationId { get; set; }
        public int CustomerId { get; set; }
        public int BankId { get; set; }
        public int LoanTypeId { get; set; }
        public decimal Amount { get; set; }
        public int LoanTerm { get; set; }
        public decimal InstallmentAmount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Status { get; set; }
        public decimal InterestRate { get; set; }

        public virtual Bank Bank { get; set; }
        public virtual LoanType LoanType { get; set; }
    }
}
