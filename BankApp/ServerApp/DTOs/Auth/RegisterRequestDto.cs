using System;

namespace ServerApp.DTOs.Auth
{
    public class RegisterRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
    }
}
