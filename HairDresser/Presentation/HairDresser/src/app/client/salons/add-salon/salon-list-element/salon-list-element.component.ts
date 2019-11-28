import { Component, OnInit, Input } from '@angular/core';
import { Salon } from 'src/app/shared/models/Salon';

@Component({
  selector: 'app-add-salon-list-element',
  templateUrl: './salon-list-element.component.html',
  styleUrls: ['./salon-list-element.component.css']
})
export class SalonListElementComponent implements OnInit {

  @Input() salon: Salon;
  displayRatingFooter = false;

  constructor() { }

  ngOnInit() {
  }

}
