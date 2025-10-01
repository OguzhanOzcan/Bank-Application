import { BehaviorSubject } from 'rxjs';
import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class AuthStatusService {
  private loggedIn = new BehaviorSubject<boolean>(!!localStorage.getItem('accessToken'));
  isLoggedIn$ = this.loggedIn.asObservable();

  setLoggedIn(status: boolean) {
    this.loggedIn.next(status);
  }
}
