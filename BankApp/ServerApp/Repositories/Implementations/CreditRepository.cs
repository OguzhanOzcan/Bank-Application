using System.Linq;
using ServerApp.Data;
using ServerApp.DTOs.Credit;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ServerApp.Repositories.Interfaces;


namespace ServerApp.Repositories.Implementations
{
    public class CreditRepository : ICreditRepository
    {
        private readonly ApplicationDbContext _context;

        public CreditRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BankDto>> GetBanksAsync()
        {
            return await _context.Banks
                .Select(b => new BankDto
                {
                    Id = b.BankId,
                    Name = b.BankName
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<LoanTypeDto>> GetLoanTypesAsync()
        {
            return await _context.LoanTypes
                .Select(l => new LoanTypeDto
                {
                    Id = l.LoanTypeId,
                    Name = l.LoanName
                })
                .ToListAsync();
        }

        public async Task<InterestRateDto> GetInterestRateAsync(int bankId, int loanTypeId)
        {
            var rate = await _context.InterestRates
                .Where(r => r.BankId == bankId && r.LoanTypeId == loanTypeId)
                .OrderByDescending(r => r.EffectiveDate)
                .Select(r => new InterestRateDto
                {
                    Rate = r.Rate
                })
                .FirstOrDefaultAsync();
            return rate;
        }
    }
}
