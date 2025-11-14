import { Injectable } from "@angular/core";
import { Observable, observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import {
  Bank,
  LoanType,
  CreditApplicationRequest
} from 'src/app/models/credit-application.model'

@Injectable({
  providedIn: 'root'
})

export class CreditApplicationService {
  private readonly baseUrl = 'http://localhost:5000/api';

  constructor(private http: HttpClient) {}

  applyCredit(dto: CreditApplicationRequest): Observable<any> {
    return this.http.post(`${this.baseUrl}/creditapplication/apply`, dto);
  }
}
