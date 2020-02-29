import { Component, AfterViewInit } from '@angular/core';
import * as L from 'leaflet';
import { Constants } from '../../constants/Constants';

@Component({
  selector: 'app-view-map',
  templateUrl: './view-map.component.html',
  styleUrls: ['./view-map.component.css']
})
export class ViewMapComponent implements AfterViewInit {

  private readonly maxZoom = 19;
  private map;

  constructor() { }

  ngAfterViewInit() {
    this.initMap();
  }

  private initMap(): void {
    this.map = L.map('map', {
      center: [ 39.8282, -98.5795 ],
      zoom: 3
    });
    const tiles = L.tileLayer(Constants.LMAP_TITLE_LAYER_URL_TEMPLATE, {
      maxZoom: this.maxZoom,
      attribution: Constants.LMAP_TITLE_LAYER_OPTIONS_ATTRIBUTION
    });
    tiles.addTo(this.map);
    this.setCurrentPosition();
  }

  private setCurrentPosition() {
    navigator.geolocation.getCurrentPosition((position) => {
    /* TODO: Salon data to recive:
        salon name
        salon coord: lat, lng
        salon id
    */

      this.map.flyTo([position.coords.latitude, position.coords.longitude], 12);
      /*var myIcon = L.icon({
        iconUrl: '../../../../assets/images/marker-icon.png'
      });*/

      const marker = L.marker([position.coords.latitude, position.coords.longitude],
        {title: 'New salon'}).addTo(this.map).on('click', (e) => {
          console.log(e.latlng);
      });
      /*const popup = L.popup()
            .setContent('<p>Hello world!<br />This is a nice popup.</p>');*/
      //marker.bindPopup(popup);
    });
  }

  addMarker(position: Position, title: string, onClickFunction: (content: any) => any, iconUrl = '') {

  }

}
