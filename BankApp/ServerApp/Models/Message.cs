using System;
using System.Text.Json.Serialization;

namespace ServerApp.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public int MessageSender { get; set; }
        
        [JsonPropertyName("message")]
        public string MessageText { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public Customer Customer { get; set; }
    }
}