import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Salon } from 'src/app/shared/models/Salon';

@Component({
  selector: 'app-client-salons-list-element',
  templateUrl: './salons-list-element.component.html',
  styleUrls: ['./salons-list-element.component.css']
})
export class ClientSalonsListElementComponent implements OnInit {

  @Input() salon: Salon;
  @Input() isSelected = false;
  @Output() removedSalon = new EventEmitter<Salon>();

  constructor() { }

  ngOnInit() { }

  /*onSelect(event: any) {
    this.isSelected = true;
  }*/

}
