import { Component, Input, AfterViewInit, EventEmitter, Output } from '@angular/core';
import { Location } from '../../models/Location';
import { Constants } from '../../constants/Constants';
import * as L from 'leaflet';
import { Functions } from '../../constants/Functions';

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
    console.log('from init');
    this.setCurrentPosition();
  }

  private getMarkerLocation(): Location {
    const selectedLatLng = this.marker.getLatLng();
    const location: Location = {latitude: selectedLatLng.lat, longitude: selectedLatLng.lng};
    return location;
  }

  private setCurrentPosition() {
    if (!Functions.isLocationSet(this.salonLocation)) {
      navigator.geolocation.getCurrentPosition(
        (position) => {
          this.map.flyTo([position.coords.latitude, position.coords.longitude], 12);
          this.moveMarker(position.coords.latitude, position.coords.longitude);
          this.selectedLocation.emit(this.getMarkerLocation());
        },
        (error) => {
          this.map.flyTo([this.defaultStaticCoords.latitude, this.defaultStaticCoords.longitude], 6);
          this.moveMarker(this.defaultStaticCoords.latitude, this.defaultStaticCoords.longitude);
          this.selectedLocation.emit(this.getMarkerLocation());
        },
        {timeout: 1000});
    } else {
      this.map.flyTo([this.salonLocation.latitude, this.salonLocation.longitude], 12);
      this.moveMarker(this.salonLocation.latitude, this.salonLocation.longitude);
      this.selectedLocation.emit(this.getMarkerLocation());
    }
  }

  addMarker(latitude: number, longitude: number) {
    this.marker = L.marker([latitude, longitude],
      {title: 'Drag marker to select location', draggable: true})
      .addTo(this.map)
      .on('dragend', () => {
        this.selectedLocation.emit(this.getMarkerLocation());
      });
  }

  moveMarker(latitude: number, longitude: number) {
    this.marker.setLatLng([latitude, longitude]);
  }

}
