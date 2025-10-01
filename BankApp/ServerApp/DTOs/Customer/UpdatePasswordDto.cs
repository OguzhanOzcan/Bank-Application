using System.ComponentModel.DataAnnotations;

namespace ServerApp.DTOs.Customer
{
    public class UpdatePasswordDto
    {
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
