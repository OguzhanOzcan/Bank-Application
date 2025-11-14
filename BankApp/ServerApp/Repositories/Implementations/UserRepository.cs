using ServerApp.Data;
using ServerApp.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerApp.Repositories.Interfaces;

namespace ServerApp.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return await _db.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            _db.Customers.Update(customer);
            await _db.SaveChangesAsync();
        }
        
        public async Task<Balance> GetBalanceByCustomerIdAsync(int customerId)
        {
            return await _db.Balances.FirstOrDefaultAsync(b => b.CustomerId == customerId);
        }
    }
}
