using System;

namespace ServerApp.Models
{
    public class ResetCode
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CodeHash { get; set; }
        public string Salt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsUsed { get; set; }
        public int Attempts { get; set; }
        public DateTime CreatedAt { get; set; }

        public Customer Customer { get; set; }
    }
}
