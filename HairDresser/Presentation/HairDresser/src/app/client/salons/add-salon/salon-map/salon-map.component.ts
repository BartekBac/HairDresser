import { Component, OnInit, ViewChild } from '@angular/core';

declare var google: any;

@Component({
  selector: 'app-salon-map',
  templateUrl: './salon-map.component.html',
  styleUrls: ['./salon-map.component.css']
})
export class SalonMapComponent implements OnInit {

  options: any;
  overlays: any[];
  selectedPosition: any;
  markerTitle = '';
  draggable = true;
  dialogVisible = false;

  map: google.maps.Map;

  constructor() { }

  ngOnInit() {
    this.options = {
      center: {lat: 50.890257, lng: 20.707417},
      zoom: 12
    };
  }

  setMap(event) {
    this.map = event.map;
    setTimeout(() => { this.setCurrentPosition(); }, 200);
  }

  private setCurrentPosition() {
    navigator.geolocation.getCurrentPosition((position) => {
      const startPos = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
      this.map.setCenter(startPos);
    });
  }

  handleMapClick(event) {
    this.selectedPosition = event.latLng;
    this.dialogVisible = true;
  }

  addMarker() {
    this.overlays.push(new google.maps.Marker(
      {position: {lat: this.selectedPosition.lat(), lng: this.selectedPosition.lng()},
       title: this.markerTitle,
        draggable: this.draggable
      }));
    this.markerTitle = null;
    this.dialogVisible = false;
  }

  handleOverlayClick(event) {
    let isMarker = event.overlay.getTitle != undefined;
    console.log(isMarker);
  }

}
