using System.Linq;
using ServerApp.Data;
using ServerApp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ServerApp.Repositories.Interfaces;

namespace ServerApp.Repositories.Implementations
{
    public class CreditApplicationRepository : ICreditApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public CreditApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CreditApplication> AddAsync(CreditApplication application)
        {
            _context.CreditApplications.Add(application);
            await _context.SaveChangesAsync();
            return application;
        }

        public async Task<IEnumerable<CreditApplication>> GetByCustomerIdAsync(int customerId)
        {
            return await _context.CreditApplications
                                 .Include(ca => ca.Bank)
                                 .Include(ca => ca.LoanType)
                                 .Where(ca => ca.CustomerId == customerId)
                                 .ToListAsync();
        }
    }
}
