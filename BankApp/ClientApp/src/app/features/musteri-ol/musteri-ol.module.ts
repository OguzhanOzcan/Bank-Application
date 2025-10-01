import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MusteriOlRoutingModule } from './musteri-ol-routing.module';
import { MusteriOlComponent } from './musteri-ol/musteri-ol.component';

@NgModule({
  declarations: [
    MusteriOlComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    MusteriOlRoutingModule
  ]
})
export class MusteriOlModule { }
