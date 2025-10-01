using ServerApp.DTOs.Credit;
using System.Threading.Tasks;
using System.Collections.Generic;
using ServerApp.Services.Interfaces;
using ServerApp.Repositories.Interfaces;

namespace ServerApp.Services.Implementations
{
    public class CreditService : ICreditService
    {
        private readonly ICreditRepository _repository;

        public CreditService(ICreditRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BankDto>> GetBanksAsync()
        {
            return await _repository.GetBanksAsync();
        }

        public async Task<IEnumerable<LoanTypeDto>> GetLoanTypesAsync()
        {
            return await _repository.GetLoanTypesAsync();
        }

        public async Task<InterestRateDto> GetInterestRateAsync(int bankId, int loanTypeId)
        {
            return await _repository.GetInterestRateAsync(bankId, loanTypeId);
        }
    }
}
