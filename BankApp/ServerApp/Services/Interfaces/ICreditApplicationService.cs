using System.Threading.Tasks;
using System.Collections.Generic;
using ServerApp.DTOs.CreditApplication;

namespace ServerApp.Services.Interfaces
{
    public interface ICreditApplicationService
    {
        Task<CreditApplicationResponseDto> ApplyCreditAsync(CreditApplicationRequestDto dto, int customerId);
        Task<IEnumerable<CreditApplicationResponseDto>> GetByCustomerIdAsync(int customerId);
    }
}
