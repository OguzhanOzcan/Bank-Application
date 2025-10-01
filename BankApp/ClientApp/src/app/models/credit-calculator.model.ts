export interface LoanType {
  id: number;
  name: string;
}

export interface Bank {
  id: number;
  name: string;
  rate: number;
}

export interface CreditCalculatorRequest {
  Amount: number;
  Term: number;
  InterestRate: number;
}

export interface PaymentPlanRow {
  installmentNo: number;
  installmentAmount: number;
  paidInterest: number;
  paidPrincipal: number;
  remainingPrincipal: number;
}

export type CreditCalculatorResponse = PaymentPlanRow[];


