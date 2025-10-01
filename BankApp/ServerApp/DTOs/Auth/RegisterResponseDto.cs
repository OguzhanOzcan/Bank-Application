namespace ServerApp.DTOs.Auth
{
    public class RegisterResponseDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
