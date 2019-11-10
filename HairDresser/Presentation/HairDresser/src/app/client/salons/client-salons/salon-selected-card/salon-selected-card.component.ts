import { Component, OnInit, Input } from '@angular/core';
import { Salon } from 'src/app/shared/models/Salon';

@Component({
  selector: 'app-client-salon-selected-card',
  templateUrl: './salon-selected-card.component.html',
  styleUrls: ['./salon-selected-card.component.css']
})
export class ClientSalonSelectedCardComponent implements OnInit {

  @Input() salon: Salon;

  constructor() { }

  ngOnInit() {
  }

}
