import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ContactComponent } from './contact/contact.component';
import { ContactRoutingModule } from './contact-routing.module';

@NgModule({
  declarations: [ContactComponent],
  imports: [
    FormsModule,
    CommonModule,
    HttpClientModule,
    ContactRoutingModule
  ]
})
export class ContactModule { }
