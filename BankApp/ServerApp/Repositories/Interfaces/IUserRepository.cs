using System.Threading.Tasks;
using ServerApp.Models;

namespace ServerApp.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task UpdateCustomerAsync(Customer customer);
    }
}
