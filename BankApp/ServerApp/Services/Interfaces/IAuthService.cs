using ServerApp.DTOs.Auth;
using System.Threading.Tasks;

namespace ServerApp.Services.Interfaces
{
    public interface IAuthService
    {
        Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto dto);
        Task<LoginResponseDto> LoginAsync(LoginRequestDto dto);
        Task SendResetCodeAsync(string email);
        Task VerifyResetCodeAsync(string email, string code);
        Task ResetPasswordAsync(string email, string newPassword);
    }
}
