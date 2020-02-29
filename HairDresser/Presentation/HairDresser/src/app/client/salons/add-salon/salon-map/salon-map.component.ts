import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-salon-map',
  templateUrl: './salon-map.component.html',
  styleUrls: ['./salon-map.component.css']
})
export class SalonMapComponent implements OnInit {

  display = false;

  constructor() { }

  ngOnInit() {
  }

  showSidebar() {
    this.display = true;
  }

}
