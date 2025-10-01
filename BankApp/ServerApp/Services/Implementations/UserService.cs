using ServerApp.Models;
using ServerApp.Helpers;
using System.Threading.Tasks;
using ServerApp.DTOs.Customer;
using ServerApp.Services.Interfaces;
using ServerApp.Repositories.Interfaces;

namespace ServerApp.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return await _userRepository.GetCustomerByIdAsync(customerId);
        }
        public async Task UpdateCustomerAsync(int customerId, UpdateCustomerDto dto)
        {
            var user = await _userRepository.GetCustomerByIdAsync(customerId);
            if (user == null)
                throw new System.Exception("Kullanıcı Bulunamadı!");

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.Phone = dto.Phone;
            user.City = dto.City;

            await _userRepository.UpdateCustomerAsync(user);
        }
        public async Task UpdatePasswordAsync(int customerId, UpdatePasswordDto dto)
        {
            var user = await _userRepository.GetCustomerByIdAsync(customerId);
            if (user == null) throw new System.Exception("Kullanıcı bulunamadı");

            var (hashed, salt) = PasswordHasher.HashPassword(dto.Password);
            user.PasswordHash = hashed;
            user.PasswordSalt = salt;

            await _userRepository.UpdateCustomerAsync(user);
        }
    }
}
