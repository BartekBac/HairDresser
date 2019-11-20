import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Salon } from 'src/app/shared/models/Salon';
import { Router } from '@angular/router';
import { Visit } from 'src/app/shared/models/Visit';

@Component({
  selector: 'app-client-salons',
  templateUrl: './client-salons.component.html',
  styleUrls: ['./client-salons.component.css']
})
export class ClientSalonsComponent implements OnInit {

  @Input() salons: Salon[];
  @Output() removedSalon = new EventEmitter<Salon>();
  @Output() addedVisit = new EventEmitter<Visit>();

  selectedSalon: Salon = null;

  constructor(
    private router: Router
  ) { }

  ngOnInit() {
  }

  redirectAddSalon() {
    this.router.navigate(['/client/add-salon']);
  }

  onRemovedSalon(removedSalon: Salon) {
    this.selectedSalon = null;
    this.removedSalon.emit(removedSalon);
  }

  onSalonSelected(selectedSalon: Salon) {
    this.selectedSalon = selectedSalon;
  }

  onAddedVisit(visit: Visit) {
    this.addedVisit.emit(visit);
  }

}
