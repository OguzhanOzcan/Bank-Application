using ServerApp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ServerApp.Repositories.Interfaces
{
    public interface ICreditApplicationRepository
    {
        Task<CreditApplication> AddAsync(CreditApplication application);
        Task<IEnumerable<CreditApplication>> GetByCustomerIdAsync(int customerId);
    }
}
