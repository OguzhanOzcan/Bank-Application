import { Injectable } from "@angular/core";
import { Observable, observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { ContactRequest, ContactResponse } from 'src/app/models/contact.model';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  private readonly apiUrl = 'https://localhost:5000/api/contact';
  constructor(private http: HttpClient) { }

  sendMessage(data:ContactRequest): Observable<ContactResponse> {
    return this.http.post<ContactResponse>(this.apiUrl, data);
  }
}





