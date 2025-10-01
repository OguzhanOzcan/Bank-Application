import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { AuthStatusService } from 'src/app/core/services/auth-status.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  isLoggedIn = false;

  constructor(
    private router: Router,
    private authStatusService: AuthStatusService
  ) { }

  ngOnInit(): void {
    this.authStatusService.isLoggedIn$.subscribe(status => {
      this.isLoggedIn = status;
    });
  }

  logout(): void {
    localStorage.removeItem('accessToken');
    localStorage.removeItem('refreshToken');
    this.authStatusService.setLoggedIn(false);
    this.router.navigate(['/login']);
  }
}
