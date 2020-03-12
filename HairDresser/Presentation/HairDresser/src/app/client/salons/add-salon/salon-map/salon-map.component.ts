import { Component, OnInit, Input } from '@angular/core';
import { MapMarker } from 'src/app/shared/components/view-map/models/MapMarker';
import { Salon } from 'src/app/shared/models/Salon';
import { ClientService } from 'src/app/shared/services/client.service';
import { MessageService } from 'primeng/primeng';

@Component({
  selector: 'app-salon-map',
  templateUrl: './salon-map.component.html',
  styleUrls: ['./salon-map.component.css']
})
export class SalonMapComponent implements OnInit {

  @Input() salons: Salon[] = [];
  @Input() userId: string = null;

  display = false;
  selectedSalonId: number;
  salon: Salon;

  markers: MapMarker[];

  markerAction(salonId: string) {
    console.log('Selected salon: ' + salonId);
    this.salon = this.salons.find(s => s.id === salonId);
    console.log(this.salon);
    this.showSidebar();
  }

  constructor(
    private clientService: ClientService,
    private toastService: MessageService) { }

  ngOnInit() {
    this.markers = [
      { latitude: 50.1400188,
        longitude: 18.8703222,
        title: 'Test2',
        onClickFunction: () => this.markerAction('28d5d061-6d2c-4569-903d-9334a89696ef')},
        { latitude: 50.1400188,
          longitude: 18.8803222,
          title: 'Test2',
          onClickFunction: () => this.markerAction('6ca41f45-bce9-40a6-b374-5428e9eb1309') }
    ];
  }

  showSidebar() {
    this.display = true;
  }

  addToFavourites(salon: Salon) {
    this.clientService.addFavouriteSalon(this.userId, salon.id).subscribe(
      res => {
        this.toastService.add({severity: 'success', summary: 'Action succeeded', detail: 'Salon added to favourites list.'});
        this.salons = this.salons.filter(s => s.id !== salon.id);
      },
      err => {this.toastService.add({severity: 'error', summary: 'Action failed', detail: err.error});}
    );
  }

}
