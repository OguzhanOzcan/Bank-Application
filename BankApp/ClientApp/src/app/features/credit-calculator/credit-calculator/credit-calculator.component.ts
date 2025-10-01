import { finalize } from 'rxjs/operators';
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CreditService } from 'src/app/core/services/credit.service';
import {
  Bank,
  LoanType,
  CreditCalculatorRequest,
  CreditCalculatorResponse
} from 'src/app/models/credit-calculator.model';

@Component({
  selector: 'app-credit-calculator',
  templateUrl: './credit-calculator.component.html',
  styleUrls: ['./credit-calculator.component.css']
})

export class CreditCalculatorComponent implements OnInit {
  banks: Bank[] = [];
  selectedBank: Bank | null = null;

  loanTypes: LoanType[] = [];
  selectedLoanType: LoanType | null = null;

  amount: number | null = null;
  term: number | null = null;
  interest: number | null = null;

  isLoading = false;
  showPaymentPlan: boolean = false;
  paymentPlansTable: CreditCalculatorResponse = [];

  constructor(private creditService: CreditService) { }

  ngOnInit(): void {
    this.creditService.getBanks().subscribe({
      next: (data) => this.banks = data,
      error: (err) => console.error('Bankalar yüklenemedi!', err)
    });

    this.creditService.getLoanTypes().subscribe({
      next: (data) => this.loanTypes = data,
      error: (err) => console.error('Kredi türleri yüklenemedi!', err)
    });
  }

  onBankChange() {
    if (this.selectedBank) {
      if (this.selectedLoanType)
      {
        this.creditService.getInterestRate(this.selectedBank.id, this.selectedLoanType.id)
          .subscribe({
            next: (data) => this.interest = data.rate,
            error: (err) => {
              console.error('Faiz oranı yüklenemedi', err);
              this.interest = null;
            }
          });
      }
      else
      {
        this.interest = null;
      }
    }
    else
    {
      this.interest = null;
    }
  }

  calculatePaymentPlan() {
    if (!this.amount || !this.term || !this.selectedBank)
    {
      alert('Lütfen tüm alanları doldurunuz!');
      return;
    }

    const dto: CreditCalculatorRequest = {
      Amount: this.amount,
      Term: this.term,
      InterestRate: this.interest
    };


    this.isLoading = true;

    this.creditService.calculateCredit(dto)
    .pipe(finalize(() => this.isLoading = false))
    .subscribe({
      next: (data) => {
        this.paymentPlansTable = data;
        this.showPaymentPlan = true;
      },
      error: (err) => {
        console.error('Hesaplama hatası:', err);
        alert('Ödeme planı hesaplanamadı!');
      }
    });
  }

  onSelectionChange()
  {
    if (this.selectedBank && this.selectedLoanType)
    {
      this.creditService.getInterestRate(this.selectedBank.id, this.selectedLoanType.id)
        .subscribe({
          next: (data) => this.interest = data.rate,
          error: (err) => {
            console.error('Faiz oranı yüklenemedi', err);
            this.interest = null;
          }
        });
    }
    else
    {
      this.interest = null;
    }
  }

  togglePaymentPlan() {
    this.showPaymentPlan = !this.showPaymentPlan;
  }

  onBankOrLoanTypeChange() {
    if (this.selectedBank && this.selectedLoanType)
    {
      this.creditService.getInterestRate(this.selectedBank.id, this.selectedLoanType.id)
        .subscribe({
          next: (data) => this.interest = data.rate,
          error: (err) => console.error('Faiz oranı yüklenemedi', err)
        });
    }
    else
    {
      this.interest = null;
    }
  }
}
