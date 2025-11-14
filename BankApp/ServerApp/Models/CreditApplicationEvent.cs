using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace ServerApp.Models
{
    public class CreditApplicationEvent
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public int CustomerId { get; set; }
        public int BankId { get; set; }
        public int LoanTypeId { get; set; }
        public decimal Amount { get; set; }
        public int LoanTerm { get; set; }
        public string Status { get; set; } 
        public DateTime CreatedAt { get; set; }
    }
}
