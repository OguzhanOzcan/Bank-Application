import { finalize } from 'rxjs/operators';
import { Component, OnInit } from '@angular/core';
import { BankLoanService } from 'src/app/core/services/bank-loan.service';
import { CreditApplicationService } from 'src/app/core/services/credit-application.service';
import {
  Bank,
  LoanType,
  CreditApplicationRequest
} from 'src/app/models/credit-application.model';

@Component({
  selector: 'app-credit-application',
  templateUrl: './credit-application.component.html',
  styleUrls: ['./credit-application.component.css']
})
export class CreditApplicationComponent implements OnInit {
  email: string = '';
  fullName: string = '';
  selectedBank: Bank | null = null;
  selectedLoanType: LoanType | null = null;
  amount: number | null = null;
  term: number | null = null;

  banks: Bank[] = [];
  krediTypes: LoanType[] = [];

  isSending = false;

  constructor(
    private creditService: CreditApplicationService,
    private bankLoanService: BankLoanService
  ) {}

  ngOnInit(): void {
    this.bankLoanService.getBanks().subscribe({
      next: (data) => this.banks = data,
      error: (err) => console.error('Bankalar yüklenemedi:', err)
    });

    this.bankLoanService.getLoanTypes().subscribe({
      next: (data) => this.krediTypes = data,
      error: (err) => console.error('Kredi türleri yüklenemedi:', err)
    });
  }

  applyCredit(): void {
    if (!this.email || !this.fullName || !this.selectedBank || !this.selectedLoanType || this.amount===null || this.term===null) {
      alert('Lütfen tüm alanları doldurunuz!');
      return;
    }

    const dto: CreditApplicationRequest = {
      email: this.email,
      fullName: this.fullName,
      bankId: this.selectedBank.id,
      loanTypeId: this.selectedLoanType.id,
      amount: this.amount,
      term: this.term
    };

    this.isSending = true;

    this.creditService.applyCredit(dto)
      .pipe(finalize(() => this.isSending = false))
      .subscribe({
        next: () => {
          alert('Kredi başvurunuz başarıyla gönderildi!');
        },
        error: (err) => {
          console.error('Başvuru hatası:', err);
          const message = err?.error?.message || 'Kredi başvurusu gönderilemedi!';
          alert(message);
        }
      });
  }
}
