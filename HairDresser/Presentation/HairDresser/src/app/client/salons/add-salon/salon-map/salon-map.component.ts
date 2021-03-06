import { Component, OnInit, Input } from '@angular/core';
import { MapMarker } from 'src/app/shared/components/view-map/models/MapMarker';
import { Salon } from 'src/app/shared/models/Salon';
import { ClientService } from 'src/app/shared/services/client.service';
import { MessageService } from 'primeng/primeng';
import { Functions } from 'src/app/shared/constants/Functions';

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

  markers: MapMarker[] = [];

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
    this.salons.forEach(salon => {
      if (Functions.isLocationSet(salon.location)) {
        this.markers.push({
          latitude: salon.location.latitude,
          longitude: salon.location.longitude,
          title: salon.name,
          onClickFunction: () => this.markerAction(salon.id)
        });
      }
    });
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
