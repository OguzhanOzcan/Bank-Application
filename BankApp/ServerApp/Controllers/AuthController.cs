using System;
using ServerApp.DTOs.Auth;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Services.Interfaces;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
        {
            try
            {
                var result = await _authService.RegisterAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            try
            {
                var result = await _authService.LoginAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
        [HttpPost("send-reset-code")]
        public async Task<IActionResult> SendResetCode([FromBody] SendResetCodeDto dto)
        {
            try
            {
                await _authService.SendResetCodeAsync(dto.Email);
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        
        [HttpPost("verify-reset-code")]
        public async Task<IActionResult> VerifyResetCode([FromBody] VerifyResetCodeDto dto)
        {
            try
            {
                await _authService.VerifyResetCodeAsync(dto.Email, dto.Code);
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            try
            {
                await _authService.ResetPasswordAsync(dto.Email, dto.NewPassword);
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
