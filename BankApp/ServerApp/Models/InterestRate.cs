using System;

namespace ServerApp.Models
{
    public class InterestRate
    {
        public int RateId { get; set; }
        public int BankId { get; set; }
        public int LoanTypeId { get; set; }
        public decimal Rate { get; set; } 
        public DateTime EffectiveDate { get; set; }
        public Bank Bank { get; set; }
        public LoanType LoanType { get; set; }
    }
}
