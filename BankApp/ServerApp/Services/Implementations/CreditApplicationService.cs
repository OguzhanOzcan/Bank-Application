using System.Linq;
using ServerApp.Models;
using ServerApp.Helpers;
using System.Threading.Tasks;
using System.Collections.Generic;
using ServerApp.Services.Interfaces;
using ServerApp.DTOs.CreditApplication;
using ServerApp.Repositories.Interfaces;


namespace ServerApp.Services.Implementations
{
    public class CreditApplicationService : ICreditApplicationService
    {
        private readonly ICreditApplicationRepository _repository;
        private readonly ICreditService _creditService;

        public CreditApplicationService(ICreditApplicationRepository repository, ICreditService creditService)
        {
            _repository = repository;
            _creditService = creditService;
        }

        public async Task<CreditApplicationResponseDto> ApplyCreditAsync(CreditApplicationRequestDto dto, int customerId)
        {
            var interestDto = await _creditService.GetInterestRateAsync(dto.BankId, dto.LoanTypeId);
            var rate = interestDto.Rate;

            var installmentList = CreditCalculatorHelper.Calculate(dto.Amount, dto.Term, rate);
            var totalInstallment = installmentList.Sum(x => x.InstallmentAmount);

            var application = new CreditApplication
            {
                CustomerId = customerId,
                BankId = dto.BankId,
                LoanTypeId = dto.LoanTypeId,
                Amount = dto.Amount,
                LoanTerm = dto.Term,
                InstallmentAmount = totalInstallment,
                InterestRate = rate
            };

            var result = await _repository.AddAsync(application);

            return new CreditApplicationResponseDto
            {
                ApplicationId = result.ApplicationId,
                Amount = result.Amount,
                LoanTerm = result.LoanTerm,
                InstallmentAmount = result.InstallmentAmount,
                InterestRate = result.InterestRate,
                BankName = result.Bank?.BankName,
                LoanTypeName = result.LoanType?.LoanName,
                Status = result.Status,
                CreatedAt = result.CreatedAt
            };
        }

        public async Task<IEnumerable<CreditApplicationResponseDto>> GetByCustomerIdAsync(int customerId)
        {
            var applications = await _repository.GetByCustomerIdAsync(customerId);
            return applications.Select(a => new CreditApplicationResponseDto
            {
                ApplicationId = a.ApplicationId,
                Amount = a.Amount,
                LoanTerm = a.LoanTerm,
                InstallmentAmount = a.InstallmentAmount,
                InterestRate = a.InterestRate,
                BankName = a.Bank?.BankName,
                LoanTypeName = a.LoanType?.LoanName,
                Status = a.Status,
                CreatedAt = a.CreatedAt
            });
        }
    }
}
