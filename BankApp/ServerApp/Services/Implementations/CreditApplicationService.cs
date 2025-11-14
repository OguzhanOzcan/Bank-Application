using System;
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
        private readonly IUserService _userService;
        private readonly IEventService _eventService;
        private readonly ICreditService _creditService;
        private readonly ICreditApplicationRepository _repository;
        

        public CreditApplicationService(
            IUserService userService,
            IEventService eventService,
            ICreditService creditService,
            ICreditApplicationRepository repository
            )
        {
            _repository = repository;
            _userService = userService;
            _eventService = eventService;
            _creditService = creditService;    
        }

        public async Task<CreditApplicationResponseDto> ApplyCreditAsync(CreditApplicationRequestDto dto, int customerId)
        {
            if (dto.Amount <= 0){
                MetricsRegistry.Exceptions.WithLabels("GecersizMiktar").Inc();
                throw new Exception("Geçersiz miktar");
            }
                
            if (dto.Term <= 0){
                MetricsRegistry.Exceptions.WithLabels("GecersizVade").Inc();
                throw new Exception("Geçersiz vade");
            }
                
            var balance = await _userService.GetBalanceByCustomerIdAsync(customerId);
            if (balance == null)
            {
                MetricsRegistry.Exceptions.WithLabels("KullanıcıBakiyesiYok").Inc();
                throw new Exception("Kullanıcı bakiyesi bulunamadı.");
            }
            
            decimal requestAmount = dto.Amount;
            decimal userBalance = balance.Amount;
            

            string status;
            if (userBalance < requestAmount){
                status = "Reddedildi";
            }
            else if (userBalance <= requestAmount * 1.5m) {
                status = "Beklemede";
            }
            else{
                status = "Onaylandı";
            }


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
                InterestRate = rate,
                CreatedAt = DateTime.UtcNow,
                Status = status
            };

            var result = await _repository.AddAsync(application);

            var creditEvent = new CreditApplicationEvent
            {
                CustomerId = customerId,
                BankId = dto.BankId,
                LoanTypeId = dto.LoanTypeId,
                Amount = dto.Amount,
                LoanTerm = dto.Term,
                Status = result.Status
            };

            await _eventService.LogCreditApplicationEventAsync(creditEvent);
            MetricsRegistry.CreditApplications.WithLabels(status.ToLower()).Inc();
            
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
