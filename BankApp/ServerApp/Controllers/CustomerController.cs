using System.Security.Claims;
using System.Threading.Tasks;
using ServerApp.DTOs.Customer;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ServerApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUserService _userService;

        public CustomerController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetProfile()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized();

            if (!int.TryParse(userIdClaim.Value, out int userId))
                return Unauthorized();

            var customer = await _userService.GetCustomerByIdAsync(userId);
            if (customer == null)
                return NotFound();

            var result = new
            {
                firstName = customer.FirstName,
                lastName = customer.LastName,
                email = customer.Email,
                birthDate = customer.BirthDate?.ToString("yyyy-MM-dd"),
                phone = customer.Phone,
                city = customer.City
            };
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateCustomerDto dto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            int userId = int.Parse(userIdClaim.Value);
            await _userService.UpdateCustomerAsync(userId, dto);
            return Ok(new { message = "Bilgiler başarıyla güncellendi!" });
        }
        
        [HttpPut("update-password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return Unauthorized();

            int userId = int.Parse(userIdClaim.Value);

            await _userService.UpdatePasswordAsync(userId, dto);

            return Ok(new { message = "Şifre başarıyla güncellendi!" });
        }

        [HttpGet("balance")]
        public async Task<IActionResult> GetBalance()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized();

            if (!int.TryParse(userIdClaim.Value, out int userId))
                return Unauthorized();
                
            var balance = await _userService.GetBalanceByCustomerIdAsync(userId);

            if (balance == null)
                return NotFound(new { message = "Bakiye bilgisi bulunamadı." });

            return Ok(balance);
        }
    }
}
