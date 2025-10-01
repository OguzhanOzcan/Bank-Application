export interface Bank {
  id: number;
  name: string;
}

export interface LoanType {
  id: number;
  name: string;
}

export interface CreditApplicationRequest {
  email: string;
  fullName: string;
  bankId: number;
  loanTypeId: number;
  amount: number;
  term: number;
  interestRate?: number;
}

export interface MyCredit {
  applicationId: number;
  bankName: string;
  loanTypeName: string;
  amount: number;
  term: number;
  installmentAmount: number;
  interestRate: number;
  status: string;
  createdAt: string;
}

