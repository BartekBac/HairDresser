import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Visit } from 'src/app/shared/models/Visit';
import { Opinion } from 'src/app/shared/models/Opinion';

@Component({
  selector: 'app-client-visits',
  templateUrl: './client-visits.component.html',
  styleUrls: ['./client-visits.component.css']
})
export class ClientVisitsComponent implements OnInit {

  @Input() visits: Visit[] = [];
  @Output() addedOpinion = new EventEmitter<Opinion>();

  constructor() {}

  ngOnInit() {}

  onAddedOpinion(opinion: Opinion) {
    this.addedOpinion.emit(opinion);
  }

}
