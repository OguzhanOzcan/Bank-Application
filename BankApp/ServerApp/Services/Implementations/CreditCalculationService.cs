using ServerApp.Helpers;
using ServerApp.DTOs.Credit;
using System.Threading.Tasks;
using System.Collections.Generic;
using ServerApp.Services.Interfaces;

namespace ServerApp.Services.Implementations
{
    public class CreditCalculationService : ICreditCalculationService
    {
        public async Task<IEnumerable<CreditCalculationResultDto>> CalculateCreditAsync(CreditCalculatorRequestDto request)
        {
            var result = CreditCalculatorHelper.Calculate(request.Amount, request.Term, request.InterestRate);
            return await Task.FromResult(result);
        }
    }
}

