using ServerApp.Helpers;
using ServerApp.DTOs.Credit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Services.Interfaces;


namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditController : ControllerBase
    {
        private readonly ICreditService _creditService;

        public CreditController(ICreditService creditService)
        {
            _creditService = creditService;
        }

        [HttpGet("banks")]
        public async Task<IActionResult> GetBanks()
        {
            var banks = await _creditService.GetBanksAsync();
            return Ok(banks);
        }

        [HttpGet("loan-types")]
        public async Task<IActionResult> GetLoanTypes()
        {
            var loanTypes = await _creditService.GetLoanTypesAsync();
            return Ok(loanTypes);
        }

        [HttpGet("interest-rate")]
        public async Task<IActionResult> GetInterestRate(int bankId, int loanTypeId)
        {
            var rate = await _creditService.GetInterestRateAsync(bankId, loanTypeId);
            return Ok(rate);
        }

        [HttpPost("calculate")]
        public IActionResult CalculateCredit([FromBody] CreditCalculatorRequestDto request)
        {
            var paymentPlan = CreditCalculatorHelper.Calculate(request.Amount, request.Term, request.InterestRate);
            return Ok(paymentPlan);
        }
    }
}
