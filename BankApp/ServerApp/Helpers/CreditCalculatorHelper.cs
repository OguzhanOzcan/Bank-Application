using System;
using ServerApp.DTOs.Credit;
using System.Collections.Generic;

namespace ServerApp.Helpers
{
    public static class CreditCalculatorHelper
    {
        public static List<CreditCalculationResultDto> Calculate(decimal principal, int term, decimal interestRate)
        {
            var result = new List<CreditCalculationResultDto>();

            decimal monthlyRate = interestRate / 100m / 12m; 
            decimal installmentAmount;

            if (monthlyRate == 0)
            {
                installmentAmount = principal / term;
            }
            else
            {
                installmentAmount = principal * (monthlyRate * (decimal)Math.Pow((double)(1 + monthlyRate), term)) /
                                    ((decimal)Math.Pow((double)(1 + monthlyRate), term) - 1);
            }
            decimal remainingPrincipal = principal;

            for (int i = 1; i <= term; i++)
            {
                decimal paidInterest = remainingPrincipal * monthlyRate;
                decimal paidPrincipal = installmentAmount - paidInterest;
                
                remainingPrincipal -= paidPrincipal;

                result.Add(new CreditCalculationResultDto
                {
                    InstallmentNo = i,
                    InstallmentAmount = Math.Round(installmentAmount, 2),
                    PaidInterest = Math.Round(paidInterest, 2),
                    PaidPrincipal = Math.Round(paidPrincipal, 2),
                    RemainingPrincipal = Math.Round(Math.Max(remainingPrincipal, 0), 2)
                });
            }
            return result;
        }
    }
}


