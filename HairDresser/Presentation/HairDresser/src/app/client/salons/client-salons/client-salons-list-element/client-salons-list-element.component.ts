import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Salon } from 'src/app/shared/models/Salon';

@Component({
  selector: 'app-client-salons-list-element',
  templateUrl: './client-salons-list-element.component.html',
  styleUrls: ['./client-salons-list-element.component.css']
})
export class ClientSalonsListElementComponent implements OnInit {

  @Input() salon: Salon;
  @Output() removedSalon = new EventEmitter<Salon>();

  constructor() { }

  ngOnInit() { }

}
