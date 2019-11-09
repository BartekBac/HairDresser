import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Salon } from 'src/app/shared/models/Salon';

@Component({
  selector: 'app-client-salons',
  templateUrl: './client-salons.component.html',
  styleUrls: ['./client-salons.component.css']
})
export class ClientSalonsComponent implements OnInit {

  @Input() salons: Salon[];
  @Output() removedSalon = new EventEmitter<Salon>();

  constructor() { }

  ngOnInit() {
  }

  redirectAddSalon() {
    console.log('redirect');
  }

  onRemovedSalon(removedSalon: Salon) {
    this.removedSalon.emit(removedSalon);
  }

}
