import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Opinion } from 'src/app/shared/models/Opinion';
import { Functions } from 'src/app/shared/constants/Functions';

@Component({
  selector: 'app-opinion-list-element',
  templateUrl: './opinion-list-element.component.html',
  styleUrls: ['./opinion-list-element.component.css']
})
export class OpinionListElementComponent implements OnInit {

  @Input() opinion: Opinion;

  constructor() { }

  ngOnInit() {}

  getRateColor(): string {
    return Functions.getOpinionRateColor(this.opinion.rate);
  }

  copyToClipboard(item) {
    let listener = (e: ClipboardEvent) => {
        e.clipboardData.setData('text/plain', (item));
        e.preventDefault();
    };

    document.addEventListener('copy', listener);
    document.execCommand('copy');
    document.removeEventListener('copy', listener);
  }

}
