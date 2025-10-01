import { finalize } from 'rxjs/operators';
import { Component, OnInit } from '@angular/core';
import { ContactRequest } from 'src/app/models/contact.model';
import { ContactService } from 'src/app/core/services/contact.service';
import { AuthStatusService } from 'src/app/core/services/auth-status.service';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {

  contact: ContactRequest = {
    name: '',
    email: '',
    message: '',
  };

  isSending = false;
  serverMessage: string | null = null;
  isLoggedIn = false;

  constructor(
    private contactService: ContactService,
    private authStatusService: AuthStatusService
  ) { }

  ngOnInit(): void {
    this.authStatusService.isLoggedIn$.subscribe(status => {
      this.isLoggedIn = status;
    });
  }

  onSubmit(form: any) {
    this.serverMessage = null;
    if (!this.isLoggedIn) {
      this.serverMessage = 'Lütfen önce giriş yapın.';
      return;
    }

    if (form.invalid) {
      form.control.markAllAsTouched();
      return;
    }

    this.isSending = true;

    this.contactService.sendMessage(this.contact)
      .pipe(finalize(() => this.isSending = false))
      .subscribe({
        next: (res) => {
          alert(res.message);
          this.serverMessage = null;
          form.reset();
        },
        error: (err) => {
          console.error('Mesajınız gönderilmedi:', err);
          this.serverMessage = 'Mesajınız gönderilirken bir hata oluştu!';
        }
      });
  }
}
