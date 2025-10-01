using System;
using ServerApp.Data;
using ServerApp.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerApp.Repositories.Interfaces;

namespace ServerApp.Repositories.Implementations
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _db;
        public AuthRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();
            return customer;
        }
        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            return await _db.Customers.FirstOrDefaultAsync(c => c.Email == email);
        }
        public async Task<ResetCode> CreateResetCodeAsync(ResetCode resetCode)
        {
            _db.ResetCodes.Add(resetCode);
            await _db.SaveChangesAsync();
            return resetCode;
        }
        public async Task<ResetCode> GetLatestResetCodeAsync(int customerId)
        {
            return await _db.ResetCodes
                .FirstOrDefaultAsync(r => r.CustomerId == customerId && !r.IsUsed && r.ExpiresAt > DateTime.UtcNow);
        }
        public async Task MarkCodeAsUsedAsync(ResetCode resetCode)
        {
            resetCode.IsUsed = true;
            await _db.SaveChangesAsync();
        }
        public async Task IncrementAttemptAsync(ResetCode resetCode)
        {
            resetCode.Attempts++;
            await _db.SaveChangesAsync();
        }
    }
}
