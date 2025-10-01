using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Services.Interfaces;
using ServerApp.DTOs.CreditApplication;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditApplicationController : ControllerBase
    {
        private readonly ICreditApplicationService _service;
        public CreditApplicationController(ICreditApplicationService service)
        {
            _service = service;
        }

        [HttpPost("apply")]
        public async Task<IActionResult> ApplyCredit([FromBody] CreditApplicationRequestDto dto)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdString))
                return Unauthorized("Kullanıcı girişi gerekli.");

            int customerId = int.Parse(userIdString);
            var result = await _service.ApplyCreditAsync(dto, customerId);
            return Ok(result);
        }

        [HttpGet("my")]
        public async Task<IActionResult> GetMyCredits()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdString))
                return Unauthorized("Kullanıcı girişi gerekli.");
                
            int customerId = int.Parse(userIdString);
            var result = await _service.GetByCustomerIdAsync(customerId);
            return Ok(result);
        }
    }
}
