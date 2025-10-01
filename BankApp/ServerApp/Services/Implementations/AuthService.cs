using System;
using System.Net;
using System.Text;
using ServerApp.Data;
using System.Net.Mail;
using ServerApp.Models;
using ServerApp.Helpers;
using ServerApp.DTOs.Auth;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using ServerApp.Services.Interfaces;
using ServerApp.Repositories.Interfaces;

namespace ServerApp.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly JwtHelper _jwtHelper;
        private readonly ApplicationDbContext _db;
        private readonly EmailSettings _emailSettings;

        public AuthService(IAuthRepository authRepository, JwtHelper jwtHelper, ApplicationDbContext db, IOptions<EmailSettings> emailOptions)
        {
            _db = db;
            _jwtHelper = jwtHelper;
            _authRepository = authRepository;
            _emailSettings = emailOptions.Value;
        }
        public async Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto dto)
        {
            var existing = await _authRepository.GetCustomerByEmailAsync(dto.Email);
            if (existing != null)
                throw new Exception("Email zaten kayıtlı.");

            var (hashedPassword, salt) = PasswordHasher.HashPassword(dto.Password);

            var customer = new Customer
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                BirthDate = dto.BirthDate,
                Gender = dto.Gender,
                PasswordHash = hashedPassword,
                PasswordSalt = salt,
                Phone = dto.Phone,
                City = dto.City
            };

            await _authRepository.AddCustomerAsync(customer);
            return new RegisterResponseDto
            {
                AccessToken = _jwtHelper.GenerateToken(customer),
                RefreshToken = _jwtHelper.GenerateRefreshToken()
            };
        }
        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto dto)
        {
            var customer = await _authRepository.GetCustomerByEmailAsync(dto.Email);
            if (customer == null || !PasswordHasher.VerifyPassword(dto.Password, customer.PasswordHash, customer.PasswordSalt))
                throw new Exception("Email veya şifre hatalı.");
            return new LoginResponseDto
            {
                AccessToken = _jwtHelper.GenerateToken(customer),
                RefreshToken = _jwtHelper.GenerateRefreshToken()
            };
        }
        public async Task SendResetCodeAsync(string email)
        {
            var customer = await _authRepository.GetCustomerByEmailAsync(email);
            if (customer == null)
                throw new Exception("Kullanıcı bulunamadı.");

            var code = new Random().Next(100000, 999999).ToString();

            using var hmac = new HMACSHA256();
            var salt = Convert.ToBase64String(hmac.Key);
            var codeHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(code)));

            var resetCode = new ResetCode
            {
                CustomerId = customer.CustomerId,
                CodeHash = codeHash,
                Salt = salt,
                ExpiresAt = DateTime.UtcNow.AddMinutes(5),
                IsUsed = false,
                Attempts = 0,
                CreatedAt = DateTime.UtcNow
            };

            _db.ResetCodes.Add(resetCode);
            await _db.SaveChangesAsync();

            using var client = new SmtpClient(_emailSettings.SmtpHost, _emailSettings.SmtpPort)
            {
                Credentials = new NetworkCredential(_emailSettings.SmtpUser, _emailSettings.SmtpPass),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailSettings.FromEmail, _emailSettings.FromName),
                Subject = "Şifre Sıfırlama Kodu",
                Body = $"Merhaba {customer.FirstName},\n\nŞifre sıfırlama kodunuz: {code}\nKod 5 dakika geçerlidir.",
                IsBodyHtml = false
            };
            mailMessage.To.Add(email);

            await client.SendMailAsync(mailMessage);
        }

        public async Task VerifyResetCodeAsync(string email, string code)
        {
            var customer = await _authRepository.GetCustomerByEmailAsync(email);
            if (customer == null)
                throw new Exception("Kullanıcı bulunamadı.");

            var resetCode = await _db.ResetCodes
                .FirstOrDefaultAsync(r => r.CustomerId == customer.CustomerId && !r.IsUsed && r.ExpiresAt > DateTime.UtcNow);

            if (resetCode == null)
                throw new Exception("Geçerli kod bulunamadı veya süresi dolmuş.");

            using var hmac = new HMACSHA256(Convert.FromBase64String(resetCode.Salt));
            var enteredHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(code)));

            if (enteredHash != resetCode.CodeHash)
            {
                resetCode.Attempts++;
                await _db.SaveChangesAsync();   
                throw new Exception("Kod yanlış.");
            }

            resetCode.IsUsed = true;
            await _db.SaveChangesAsync();
        }

        public async Task ResetPasswordAsync(string email, string newPassword)
        {
            var customer = await _authRepository.GetCustomerByEmailAsync(email);
            if (customer == null)
                throw new Exception("Kullanıcı bulunamadı.");

            var (hash, salt) = PasswordHasher.HashPassword(newPassword);
            customer.PasswordHash = hash;
            customer.PasswordSalt = salt;

            _db.Customers.Update(customer);
            await _db.SaveChangesAsync();
        }
    }
}
