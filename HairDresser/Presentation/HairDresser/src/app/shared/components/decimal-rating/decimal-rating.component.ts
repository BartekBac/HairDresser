import { Component, OnInit, Input } from '@angular/core';
import { Functions } from '../../constants/Functions';

@Component({
  selector: 'app-decimal-rating',
  templateUrl: './decimal-rating.component.html',
  styleUrls: ['./decimal-rating.component.css']
})
export class DecimalRatingComponent implements OnInit {

  @Input() rate: number;
  @Input() showHeader = false;
  @Input() showFooter = true;

  constructor() { }

  ngOnInit() {}

  getRateColor(): string {
    return Functions.getOpinionRateColor(this.rate);
  }

}
