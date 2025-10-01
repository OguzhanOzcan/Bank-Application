import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ScrollCardComponent } from './components/scroll-card/scroll-card.component';

@NgModule({
  declarations: [
    ScrollCardComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    ScrollCardComponent
  ]
})
export class SharedModule { }
