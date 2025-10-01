using System;
using System.Collections.Generic;

namespace ServerApp.Models
{
    public class Bank
    {
        public int BankId { get; set; }  
        public string BankName { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<InterestRate> InterestRates { get; set; }
    }
}
