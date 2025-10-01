using System.ComponentModel.DataAnnotations;

namespace ServerApp.DTOs.Customer
{
    public class UpdateCustomerDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string City { get; set; }
    }
}