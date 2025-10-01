import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { ProfilComponent } from './profil/profil.component';
import { ProfilRoutingModule } from './profil-routing.module';



@NgModule({
  declarations: [ProfilComponent],
  imports: [
    CommonModule,
    ProfilRoutingModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class ProfilModule { }
