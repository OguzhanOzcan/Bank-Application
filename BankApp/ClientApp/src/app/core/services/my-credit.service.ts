import { Observable } from "rxjs";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { MyCredit } from "src/app/models/credit-application.model";

@Injectable({
  providedIn: 'root'
})
export class MyCreditService {
  private readonly baseUrl = 'https://localhost:5000/api/creditapplication';

  constructor(private http: HttpClient) { }

  getMyCredits(): Observable<MyCredit[]> {
    return this.http.get<MyCredit[]>(`${this.baseUrl}/my`);
  }
}
