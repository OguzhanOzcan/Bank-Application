import { Component, OnInit } from '@angular/core';
import { MyCredit } from 'src/app/models/credit-application.model';
import { MyCreditService } from 'src/app/core/services/my-credit.service';

@Component({
  selector: 'app-my-credit',
  templateUrl: './my-credit.component.html',
  styleUrls: ['./my-credit.component.css']
})
export class MyCreditComponent implements OnInit {

  credits: MyCredit[] = [];
  isLoading = true;

  constructor(private myCreditService: MyCreditService) { }

  ngOnInit(): void {
    this.myCreditService.getMyCredits().subscribe({
      next: data => {
        this.credits = data;
        this.isLoading = false;
      },
      error: err => {
        console.error('Kredi verileri alınamadı', err);
        this.isLoading = false;
      }
    });
  }
}
