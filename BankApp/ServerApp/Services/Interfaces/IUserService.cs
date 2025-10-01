using ServerApp.Models;
using System.Threading.Tasks;
using ServerApp.DTOs.Customer; 

namespace ServerApp.Services.Interfaces
{
    public interface IUserService
    {
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task UpdateCustomerAsync(int customerId, UpdateCustomerDto dto);
        Task UpdatePasswordAsync(int customerId, UpdatePasswordDto dto);
    }
}
