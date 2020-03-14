import { Component, Input, AfterViewInit, EventEmitter, Output } from '@angular/core';
import { Location } from '../../models/Location';
import { Constants } from '../../constants/Constants';
import * as L from 'leaflet';

@Component({
  selector: 'app-form-map',
  templateUrl: './form-map.component.html',
  styleUrls: ['./form-map.component.css']
})
export class FormMapComponent implements AfterViewInit {

  @Input() salonLocation: Location;
  @Output() selectedLocation = new EventEmitter<Location>();

  private readonly maxZoom = 19;
  private readonly defaultStaticCoords: Location = {latitude: 51.55, longitude: 19.08};

  private map;
  private marker;

  constructor() { }

  ngAfterViewInit() {}

  initMap(): void {
    if (this.map == null) {
      this.map = L.map('map', {
        center: [this.defaultStaticCoords.latitude, this.defaultStaticCoords.longitude],
        zoom: 6
      });
      this.addMarker(this.defaultStaticCoords.latitude, this.defaultStaticCoords.longitude);
      const tiles = L.tileLayer(Constants.LMAP_TITLE_LAYER_URL_TEMPLATE, {
        maxZoom: this.maxZoom,
        attribution: Constants.LMAP_TITLE_LAYER_OPTIONS_ATTRIBUTION
      });
      tiles.addTo(this.map);
    }
    this.setCurrentPosition();
  }

  private setCurrentPosition() {
    if (this.salonLocation.latitude === 0 && this.salonLocation.longitude === 0) {
      navigator.geolocation.getCurrentPosition(
        (position) => {
          this.map.flyTo([position.coords.latitude, position.coords.longitude], 12);
          this.moveMarker(position.coords.latitude, position.coords.longitude);
        },
        (error) => {
          this.map.flyTo([this.defaultStaticCoords.latitude, this.defaultStaticCoords.longitude], 6);
          this.moveMarker(this.defaultStaticCoords.latitude, this.defaultStaticCoords.longitude);
        },
        {timeout: 1000});
    } else {
      this.map.flyTo([this.salonLocation.latitude, this.salonLocation.longitude], 12);
      this.moveMarker(this.salonLocation.latitude, this.salonLocation.longitude);
    }
  }

  addMarker(latitude: number, longitude: number) {
    this.marker = L.marker([latitude, longitude],
      {title: 'Drag marker to select location', draggable: true})
      .addTo(this.map)
      .on('dragend', () => {
        const selectedLatLng = this.marker.getLatLng();
        const location: Location = {latitude: selectedLatLng.lat, longitude: selectedLatLng.lng};
        this.selectedLocation.emit(location);
      });
  }

  moveMarker(latitude: number, longitude: number) {
    this.marker.setLatLng([latitude, longitude]);
  }

}
