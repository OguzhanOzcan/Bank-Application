using System;
using System.Collections.Generic;

namespace ServerApp.Models
{
    public class LoanType
    {
        public int LoanTypeId { get; set; } 
        public string LoanName { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<InterestRate> InterestRates { get; set; }
    }
}
