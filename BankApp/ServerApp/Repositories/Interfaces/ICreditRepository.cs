using ServerApp.DTOs.Credit;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace ServerApp.Repositories.Interfaces
{
    public interface ICreditRepository
    {
        Task<IEnumerable<BankDto>> GetBanksAsync();
        Task<IEnumerable<LoanTypeDto>> GetLoanTypesAsync();
        Task<InterestRateDto> GetInterestRateAsync(int bankId, int loanTypeId);
    }
}
