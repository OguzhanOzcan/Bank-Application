import { Observable } from "rxjs";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Bank, LoanType } from "src/app/models/credit-application.model";

@Injectable({
  providedIn: 'root'
})
export class BankLoanService {
  private readonly baseUrl = 'https://localhost:5000/api';

  constructor(private http: HttpClient) {}

  getBanks(): Observable<Bank[]> {
    return this.http.get<Bank[]>(`${this.baseUrl}/credit/banks`);
  }

  getLoanTypes(): Observable<LoanType[]> {
    return this.http.get<LoanType[]>(`${this.baseUrl}/credit/loan-types`);
  }
}
