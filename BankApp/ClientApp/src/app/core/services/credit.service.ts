import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {
  Bank,
  LoanType,
  CreditCalculatorRequest,
  CreditCalculatorResponse
} from 'src/app/models/credit-calculator.model'

@Injectable({
  providedIn: 'root'
})
export class CreditService {
  private readonly baseUrl = 'http://localhost:5000/api/credit';
  constructor(private http: HttpClient) { }

  getBanks(): Observable<Bank[]> {
    return this.http.get<Bank[]>(`${this.baseUrl}/banks`);
  }

  calculateCredit(dto: CreditCalculatorRequest): Observable<CreditCalculatorResponse> {
    return this.http.post<CreditCalculatorResponse>(`${this.baseUrl}/calculate`, dto);
  }

  getLoanTypes(): Observable<LoanType[]> {
    return this.http.get<LoanType[]>(`${this.baseUrl}/loan-types`);
  }

  getInterestRate(bankId: number, loanTypeId: number): Observable<{ rate: number }> {
    return this.http.get<{ rate: number }>(`${this.baseUrl}/interest-rate?bankId=${bankId}&loanTypeId=${loanTypeId}`);
  }
}
