import { Component, OnInit, Input } from '@angular/core';
import { Visit } from 'src/app/shared/models/Visit';

@Component({
  selector: 'app-client-visits',
  templateUrl: './client-visits.component.html',
  styleUrls: ['./client-visits.component.css']
})
export class ClientVisitsComponent implements OnInit {

  @Input() visits: Visit[] = [];

  constructor() {}

  ngOnInit() {}

}
