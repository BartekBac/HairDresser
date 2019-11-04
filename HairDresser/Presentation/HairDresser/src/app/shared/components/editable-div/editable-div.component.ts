import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-editable-div',
  templateUrl: './editable-div.component.html',
  styleUrls: ['./editable-div.component.css']
})
export class EditableDivComponent implements OnInit {

  @Input() iconPaddingTop = '0px';
  @Input() iconPaddingRight = '0px';
  @Input() openDialogFlag = false;
  @Output() openDialogFlagChange = new EventEmitter();

  protected editIconVisible = false;


  constructor() { }

  ngOnInit() {
  }

  showDialog() {
    this.openDialogFlag = true;
    this.openDialogFlagChange.emit(this.openDialogFlag);
  }

  toggleEditIcon(show: boolean) {
    this.editIconVisible = show;
  }

}
