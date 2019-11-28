import { Component, OnInit, Input } from '@angular/core';
import { Opinion } from 'src/app/shared/models/Opinion';

@Component({
  selector: 'app-worker-opinions',
  templateUrl: './worker-opinions.component.html',
  styleUrls: ['./worker-opinions.component.css']
})
export class WorkerOpinionsComponent implements OnInit {

  @Input() opinions: Opinion[];

  constructor() { }

  ngOnInit() {
  }

}
