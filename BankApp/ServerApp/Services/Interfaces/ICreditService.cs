using ServerApp.DTOs.Credit;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace ServerApp.Services.Interfaces
{
    public interface ICreditService
    {
        Task<IEnumerable<BankDto>> GetBanksAsync();
        Task<IEnumerable<LoanTypeDto>> GetLoanTypesAsync();
        Task<InterestRateDto> GetInterestRateAsync(int bankId, int loanTypeId);
    }
}
