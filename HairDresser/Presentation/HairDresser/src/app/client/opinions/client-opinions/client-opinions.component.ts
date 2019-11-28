import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Opinion } from 'src/app/shared/models/Opinion';

@Component({
  selector: 'app-client-opinions',
  templateUrl: './client-opinions.component.html',
  styleUrls: ['./client-opinions.component.css']
})
export class ClientOpinionsComponent implements OnInit {

  @Input() opinions: Opinion[] = [];
  @Output() deletedOpinion = new EventEmitter<Opinion>();

  constructor() { }

  ngOnInit() {}

  onDeleteOpinion(opinion: Opinion) {
    this.deletedOpinion.emit(opinion);
  }

}
