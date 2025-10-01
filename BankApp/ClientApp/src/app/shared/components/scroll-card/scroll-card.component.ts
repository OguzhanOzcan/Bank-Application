import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-scroll-card',
  templateUrl: './scroll-card.component.html',
  styleUrls: ['./scroll-card.component.css']
})
export class ScrollCardComponent implements OnInit {

  @Input() title: string = '';

  items: string[] = [];

  constructor() { }

  ngOnInit(): void {
    this.setItemsByTitle();
  }

  private setItemsByTitle(): void {
    switch (this.title) {
      case 'Bankalar':
        this.items = [
          'Türkiye Vakıflar Bankası T.A.O',
          'Türkiye Cumhuriyeti Ziraat Bankası A.Ş',
          'Türkiye Halk Bankası A.Ş',
          'Türkiye Garanti Bankası A.Ş',
          'Türkiye Akbank T.A.Ş.',
          'Türkiye İş Bankası A.Ş.',
          'Yapı ve Kredi Bankası A.Ş.'
        ];
        break;
      case 'Popüler Olan Aramalar':
        this.items = [
          '10000 TL 12 ay vade kredi',
          '20000 TL 18 ay vade kredi',
          '150000 TL 24 ay vade kredi',
          '36000 TL 24 ay vade kredi',
          '400000 TL 24 ay vade kredi',
          '55000 TL 24 ay vade kredi'
        ];
        break;
      default:
        this.items = [];
    }
  }
}
