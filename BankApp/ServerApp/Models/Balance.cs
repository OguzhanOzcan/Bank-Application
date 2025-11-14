using System;

namespace ServerApp.Models
{
    public class Balance
    {
        public int BalanceId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime LastUpdated { get; set; }
        public Customer Customer { get; set; }
    }
}
