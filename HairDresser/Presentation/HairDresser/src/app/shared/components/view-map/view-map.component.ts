import { Component, AfterViewInit, Input } from '@angular/core';
import * as L from 'leaflet';
import { Constants } from '../../constants/Constants';
import { MapMarker } from './models/MapMarker';

@Component({
  selector: 'app-view-map',
  templateUrl: './view-map.component.html',
  styleUrls: ['./view-map.component.css']
})
export class ViewMapComponent implements AfterViewInit {

  @Input() markers: MapMarker[];

  private readonly maxZoom = 19;
  private readonly defaultStaticCoords = {latitude: 51.55, longitude: 19.08};
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
    this.markers.forEach(marker => {
      this.addMarker(marker.latitude, marker.longitude, marker.title, marker.onClickFunction);
    });
    this.map.on('geosearch_showlocation', function (result) {
      L.marker([result.x, result.y]).addTo(this.map);
    });
  }

  private setCurrentPosition() {
    navigator.geolocation.getCurrentPosition(
      (position) => {
        this.map.flyTo([position.coords.latitude, position.coords.longitude], 12);
      },
      (error) => {
        this.map.flyTo([this.defaultStaticCoords.latitude, this.defaultStaticCoords.longitude], 6);
      },
      {timeout: 2000});
  }

  addMarker(latitude: number, longitude: number, title: string, onClickFunction: (content: any) => any) {
    const marker = L.marker([latitude, longitude],
      {title}).addTo(this.map).on('click', onClickFunction);
  }

}
