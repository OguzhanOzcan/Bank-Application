using ServerApp.Models;
using System.Threading.Tasks;

namespace ServerApp.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<Customer> AddCustomerAsync(Customer customer);
        Task<Customer> GetCustomerByEmailAsync(string email);
        
        Task<ResetCode> CreateResetCodeAsync(ResetCode resetCode);
        Task<ResetCode> GetLatestResetCodeAsync(int customerId);
        Task MarkCodeAsUsedAsync(ResetCode resetCode);
        Task IncrementAttemptAsync(ResetCode resetCode);
    }
}
