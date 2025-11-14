using ServerApp.Models;
using System.Threading.Tasks;

namespace ServerApp.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task UpdateCustomerAsync(Customer customer);
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task<Balance> GetBalanceByCustomerIdAsync(int customerId);
    }
}
