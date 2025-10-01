using ServerApp.DTOs.Credit;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ServerApp.Services.Interfaces
{
    public interface ICreditCalculationService
    {
        Task<IEnumerable<CreditCalculationResultDto>> CalculateCreditAsync(CreditCalculatorRequestDto request);
    }
}
