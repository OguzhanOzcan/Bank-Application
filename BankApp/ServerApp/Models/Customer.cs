using System;
using System.ComponentModel.DataAnnotations;

namespace ServerApp.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        
    }
}
