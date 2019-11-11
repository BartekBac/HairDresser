import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-overlay-div',
  templateUrl: './overlay-div.component.html',
  styleUrls: ['./overlay-div.component.css']
})
export class OverlayDivComponent implements OnInit {

  @Input() buttonPaddingTop = '0px';
  @Input() buttonPaddingRight = '0px';
  @Input() contentPaddingTop = '0px';
  @Input() contentPaddingRight = '35px';
  @Input() contentWidth = '100%';
  @Input() buttonClasses = '';
  @Input() buttonIcon = 'pi pi-exclamation-circle';

  displayOverlay = false;

  constructor() { }

  ngOnInit() {
  }

}
